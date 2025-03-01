[CmdletBinding(PositionalBinding=$false)]
param (
    [switch]$OnlyBuild=$false
)

$appName = "TestNET.Teacher" # Replace with your application project name.
$appName2 = "TestNET.Student" # Replace with your application project name.
$projDir = "TestNET.Teacher" # Replace with your project directory (where .csproj resides).
$projDir2 = "TestNET.Student" # Replace with your project directory (where .csproj resides).

Set-StrictMode -version 2.0
$ErrorActionPreference = "Stop"

Write-Output "Working directory: $pwd"

# Find MSBuild.
$msBuildPath = & "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe" `
    -latest -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe `
    -prerelease | select-object -first 1
Write-Output "MSBuild: $((Get-Command $msBuildPath).Path)"

# Load current Git tag.
$tag = $(git describe --tags)
Write-Output "Tag: $tag"

# Parse tag into a three-number version.
$version = $tag.Split('-')[0].TrimStart('v')
$version = "$version.0"
Write-Output "Version: $version"

# Clean output directory.
$publishDir = "bin/publish"
$outDir = "$projDir/$publishDir"
$outDir2 = "$projDir2/$publishDir"
if (Test-Path $outDir) {
    Remove-Item -Path $outDir -Recurse
}
if (Test-Path $outDir2) {
    Remove-Item -Path $outDir2 -Recurse
}

# Publish the application.
Push-Location $projDir
try {
    Write-Output "Restoring:"
    dotnet restore -r win-x86
    Write-Output "Publishing:"
    $msBuildVerbosityArg = "/v:m"
    if ($env:CI) {
        $msBuildVerbosityArg = ""
    }
    & $msBuildPath /target:publish /p:PublishProfile=GitHubTeacherProfile `
        /p:ApplicationVersion=$version /p:Configuration=Release `
        /p:PublishDir=$publishDir /p:PublishUrl=$publishDir `
        $msBuildVerbosityArg

    # Measure publish size.
    $publishSize = (Get-ChildItem -Path "$publishDir/Application Files" -Recurse |
        Measure-Object -Property Length -Sum).Sum / 1Mb
    Write-Output ("Published size: {0:N2} MB" -f $publishSize)
}
finally {
    Pop-Location
}

Push-Location $projDir2
try {
    Write-Output "Restoring:"
    dotnet restore -r win-x86
    Write-Output "Publishing:"
    $msBuildVerbosityArg = "/v:m"
    if ($env:CI) {
        $msBuildVerbosityArg = ""
    }
    & $msBuildPath /target:publish /p:PublishProfile=GitHubStudentProfile `
        /p:ApplicationVersion=$version /p:Configuration=Release `
        /p:PublishDir=$publishDir /p:PublishUrl=$publishDir `
        $msBuildVerbosityArg

    # Measure publish size.
    $publishSize = (Get-ChildItem -Path "$publishDir/Application Files" -Recurse |
        Measure-Object -Property Length -Sum).Sum / 1Mb
    Write-Output ("Published size: {0:N2} MB" -f $publishSize)
}
finally {
    Pop-Location
}

if ($OnlyBuild) {
    Write-Output "Build finished."
    exit
}

# Clone `gh-pages` branch.
$ghPagesDir = "gh-pages"
if (-Not (Test-Path $ghPagesDir)) {
    git clone $(git config --get remote.origin.url) -b gh-pages `
        --depth 1 --single-branch $ghPagesDir
}

Push-Location $ghPagesDir
try {
    # Remove previous application files.
    Write-Output "Removing previous files..."
    if (Test-Path "./$projDir/Application Files") {
        Remove-Item -Path "./$projDir/Application Files" -Recurse
    }
    if (Test-Path "./$projDir/$appName.application") {
        Remove-Item -Path "./$projDir/$appName.application"
    }
    if (Test-Path "./$projDir/$appName.setup.exe") {
        Remove-Item -Path "./$projDir/setup.exe"
    }
    if (Test-Path "./$projDir/setup.exe") {
        Remove-Item -Path "./$projDir/setup.exe"
    }
    if (Test-Path "./$projDir2/Application Files") {
        Remove-Item -Path "./$projDir2/Application Files" -Recurse
    }
    if (Test-Path "./$projDir2/$appName2.application") {
        Remove-Item -Path "./$projDir2/$appName2.application"
    }
    if (Test-Path "./$projDir2/$appName2.setup.exe") {
        Remove-Item -Path "./$projDir2/$appName2.setup.exe"
    }
    if (Test-Path "./$projDir2/setup.exe") {
        Remove-Item -Path "./$projDir2/setup.exe"
    }

    # Copy new application files.
    Write-Output "Copying new files..."
    if (!(Test-Path "./$projDir")){
        New-Item -ItemType Directory -Path "./$projDir"
    }
    Push-Location $projDir
    Rename-Item -Path "../../$outDir/setup.exe" -NewName "$appName.setup.exe"
    Copy-Item -Path "../../$outDir/Application Files","../../$outDir/$appName.application","../../$outDir/$appName.setup.exe" `
        -Destination . -Recurse
    Pop-Location
    if (!(Test-Path "./$projDir2")){
        New-Item -ItemType Directory -Path "./$projDir2"
    }
    Push-Location $projDir2
    Rename-Item -Path "../../$outDir2/setup.exe" -NewName "$appName2.setup.exe"
    Copy-Item -Path "../../$outDir2/Application Files","../../$outDir2/$appName2.application","../../$outDir2/$appName2.setup.exe" `
        -Destination . -Recurse

    # Stage and commit.
    Write-Output "Staging..."
    git add -A
    Write-Output "Committing..."
    git commit -m "Update to v$version"

    # Push.
    git push
} finally {
    Pop-Location
}