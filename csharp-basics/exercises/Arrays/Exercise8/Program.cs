namespace Exercise8;

internal class Program
{
    private static void Main(string[] args)
    {
        var random = new Random();
        var words = new List<string>
        {
            "Suns", "Dators", "Maize", "Skola", "Pūce",
            "Auto", "Telefons", "Krēsls", "Kafija", "Lācis"
        };

        var allowedMisses = 5;
        var missedLetters = string.Empty;
        var word = words[random.Next(words.Count)];
        var wordForDisplay = new string('_', word.Length).ToCharArray();

        while (wordForDisplay.Contains('_') && allowedMisses > 0)
        {
            Console.WriteLine("Guess the word.");
            Console.WriteLine($"Word: {new string(wordForDisplay)}");
            Console.WriteLine($"Misses: {missedLetters} {missedLetters.Length}/5");
            Console.WriteLine();
            Console.WriteLine("Guess: ");

            var input = Console.ReadLine();
            Console.WriteLine();

            if (input.Length != 1 || !char.IsLetter(input[0]))
            {
                Console.WriteLine("Invalid input. Please enter a single letter.");
                continue;
            }

            if (word.ToLower().Contains(char.ToLower(input[0])))
            {
                for (var i = 0; i < word.Length; i++)
                    if (char.ToLower(word[i]) == char.ToLower(input[0]))
                    {
                        wordForDisplay[i] = word[i];
                    }
            }
            else
            {
                missedLetters += input[0];
                allowedMisses--;
                if (allowedMisses <= 0)
                {
                    Console.WriteLine("Sorry, you lost!");
                }
            }

            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-");
        }

        if (!wordForDisplay.Contains('_'))
        {
            Console.WriteLine("You won!");
        }

        Console.WriteLine(word);
    }
}