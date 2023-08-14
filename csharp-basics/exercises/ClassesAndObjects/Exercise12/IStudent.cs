namespace Exercise12;

internal interface IStudent
{
    string[] TestsTaken { get; }
    void TakeTest(ITestPaper paper, string[] answers);
}