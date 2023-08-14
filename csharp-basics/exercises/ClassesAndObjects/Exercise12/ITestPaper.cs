namespace Exercise12;

public interface ITestPaper
{
    string[] MarkScheme { get; }
    string PassMark { get; }
    string Subject { get; }

    public void TakeTest(ITestPaper paper, string[] answers);
}