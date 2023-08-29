namespace Exercise12;

internal class Testpaper : ITestPaper
{
    public Testpaper(string subject, string[] markScheme, string passMark)
    {
        Subject = subject;
        MarkScheme = markScheme;
        PassMark = passMark;
    }

    public string Subject { get; }
    public string[] MarkScheme { get; }
    public string PassMark { get; }

}