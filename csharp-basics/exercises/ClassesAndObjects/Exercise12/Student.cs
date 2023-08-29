using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise12
{
    internal class Student: IStudent
    {
        private readonly List<string> _takenTests;

        public Student()
        {
            _takenTests = new List<string>();
        }

        public string[] TestsTaken {get{return _takenTests.Count == 0? new string[]{"No tests taken"}: _takenTests.ToArray();}}

        public void TakeTest(ITestPaper paper, string[] answers)
        {
            var correctAnswers = 0;
            for (var i = 0; i < paper.MarkScheme.Length; i++)
                if (paper.MarkScheme[i] == answers[i])
                    correctAnswers++;

            double percentage = (double)correctAnswers / paper.MarkScheme.Length * 100;
            string result = percentage >= int.Parse(paper.PassMark.TrimEnd('%')) ? "Passed" : "Failed";

            _takenTests.Add($"{paper.Subject}: {result}! ({percentage:0#}%)");
        }
    }
}
