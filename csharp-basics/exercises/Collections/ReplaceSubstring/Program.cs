using System.Linq;

namespace ReplaceSubstring
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var words = new[] { "near", "speak", "tonight", "weapon", "customer", "deal", "lawyer" };

            var transformedWords = words.Select(word => word.Replace("ea", "*")).ToArray();
        }
    }
}