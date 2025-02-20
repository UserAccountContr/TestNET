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
                ShortAnswerQuestion sh => sh.Answer.Text
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
                MultipleChoiceQuestion mc => mc.PossibleAnswers[index - 1].IsCorrect
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
