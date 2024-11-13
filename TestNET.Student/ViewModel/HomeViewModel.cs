﻿using TestNET.Student.Service;

namespace TestNET.Student.ViewModel;

public partial class HomeViewModel : BaseViewModel
{
    [ObservableProperty]
    INavigationService navigation;
    TestService testService;

    public HomeViewModel(INavigationService navigation, TestService testService)
    {
        Navigation = navigation;
        this.testService = testService;
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    [NotifyPropertyChangedFor(nameof(CanStart))]
    string firstName;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    [NotifyPropertyChangedFor(nameof(CanStart))]
    string lastName;

    public string FullName { get => $"{FirstName} {LastName}"; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanStart))]
    string code;

    public bool CanStart { get => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(Code) && IsNotGettingTest; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotGettingTest))]
    [NotifyPropertyChangedFor(nameof(CanStart))]
    bool isGettingTest;

    public bool IsNotGettingTest { get => !IsGettingTest; }

    [RelayCommand]
    async void GoToTestOverview(string name)
    {
        IsGettingTest = true;
        Test test = await Task.Run(() => testService.GetTest(name));
        if (test == null)
            return;
        Navigation.NavigateTo<TestOverviewViewModel, Test>(test);
        IsGettingTest = false;
    }
}
