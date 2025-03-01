using System.Globalization;
using System.Windows.Data;

namespace TestNET.Shared.Service;

public class IndexConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is FrameworkElement item)
        {
            ItemsControl itemsControl = ItemsControl.ItemsControlFromItemContainer(item);
            int index = itemsControl.ItemContainerGenerator.IndexFromContainer(item);
            return (index + 1).ToString();
            // Adjust index as needed (e.g., start from 1)
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();

    }
}

public class MultiBindConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return values.Clone();
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class TestUIDToSAQuestionConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values[1] is Test test && values[0] is string uid)
        {
            return test.Questions.FirstOrDefault(q => q.UniqueId == uid) switch
            {
                ShortAnswerQuestion sh => sh.Answer.Text,
                _ => ""
            };
        }
        return null;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class TestUIDToSAQuestionPOINTSConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values[1] is Test test && values[0] is string uid)
        {
            return test.Questions.FirstOrDefault(q => q.UniqueId == uid) switch
            {
                ShortAnswerQuestion sh => sh.Points,
                _ => 0
            };
        }
        return 0;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class TestUIDToSAQuestionBOOLConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values[1] is Test test && values[0] is string uid && values[2] is string s)
        {
            return test.Questions.FirstOrDefault(q => q.UniqueId == uid) switch
            {
                ShortAnswerQuestion sh => sh.Answer.Text == s,
                _ => false
            };
        }
        return null;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class TestUIDToMCQuestionConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values[1] is Test test && values[0] is string uid && int.TryParse(values[2].ToString(), out int index))
        {
            return test.Questions.FirstOrDefault(q => q.UniqueId == uid) switch
            {
                MultipleChoiceQuestion mc => mc.PossibleAnswers[index - 1].IsCorrect,
                MultipleChoiceManyQuestion mcm => mcm.PossibleAnswers[index - 1].IsCorrect,
                _ => false
            };
        }
        return null;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class QTypeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var q = value as Question;

        if (q is ShortAnswerQuestion) return "SH";
        if (q is MultipleChoiceQuestion) return "MC";
        if (q is MultipleChoiceManyQuestion) return "MCM";
        return "unknown";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class SubmissionAttentionConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length != 2) return null;
        if (values[0] is string s && values[1] is bool b)
        {
            var requiresAttention = Application.Current.Resources["requiresAttention"];
            if (b) return $"{s} - {requiresAttention}";
            else return s;
        }
        return null;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class TestUIDPointsConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length != 2) return null;
        if (values[0] is Test t && values[1] is string s )
        {
            return (t.Questions.Where(x=> x.UniqueId == s).FirstOrDefault()?.Points ?? 0) * (parameter is not null && float.TryParse(parameter.ToString(), out float f) ? f : 1);
        }
        return 0;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class MultiBoolConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return values.All(x => x is bool b && b);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class FloatRangeValidationRule : ValidationRule
{
    public float MinValue { get; set; }
    public float MaxValue { get; set; }
        

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value is string strValue && float.TryParse(strValue, out float parsedValue))
        {
            if (parsedValue < MinValue || parsedValue > MaxValue)
            {
                return new ValidationResult(false, $"Value must be between {MinValue} and {MaxValue}");
            }
            return ValidationResult.ValidResult;
        }
        return new ValidationResult(false, "Invalid number");
    }
}

public class PointsOutOfMaxConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length == 2 && values[0] is float points && values[1] is float max)
            return $@"{points}/{max}";
        return "0";
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
