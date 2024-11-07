using System.Collections.ObjectModel;

namespace TestNET.Shared.Model;

public class Test
{
    public string Name { get; set; }

    public ObservableCollection<Question> Questions { get; set; }

    public override string ToString() => Name;

    public void AddQuestion() => Questions.Add(new Question("q", "a"));

    public Test DeepCopy()
    {
        return new Test
        {
            Name = this.Name,
            Questions = new ObservableCollection<Question>(Questions.Select(x => x.DeepCopy()))
        };
    }
}
