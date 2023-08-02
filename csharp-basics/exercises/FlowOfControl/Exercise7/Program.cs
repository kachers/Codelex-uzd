namespace Exercise7;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(Game());
    }

    private static string Game()
    {
        var move = GetMove();
        var randomMove = RandomMove();
        var winner = "";
        if (move.Equals(randomMove))
        {
            Console.WriteLine("Game is tie!");
            winner = " It's a Tie";
            return winner;
        }

        if ((move.Contains("Rock") && randomMove.Contains("Scissors")) ||
            (move.Contains("Paper") && randomMove.Contains("Rock")) ||
            (move.Contains("Scissors") && randomMove.Contains("Paper")))
        {
            Console.WriteLine("The winner is :");
            winner = " You";
            return winner;
        }

        Console.WriteLine("The winner is:");
        winner = " Opponent";
        return winner;
    }

    public static string GetMove()
    {
        Console.WriteLine("Choose your move - \n 1 = Rock\n 2 = Paper\n 3 = Scissors");
        var input = int.Parse(Console.ReadLine());
        var move = "";

        switch (input)
        {
            case 1:
            {
                Console.WriteLine("You chose: Rock");
                move = "Rock";
                break;
            }

            case 2:
            {
                Console.WriteLine("You chose: Paper");
                move = "Paper";
                break;
            }

            case 3:
            {
                Console.WriteLine("You chose: Scissors");
                move = "Scissors";
                break;
            }

            default:
            {
                Console.WriteLine("Invalid input.");
                break;
            }
        }

        return move;
    }

    public static string RandomMove()
    {
        var rnd = new Random();
        var random = rnd.Next(1, 3);
        var randomMove = "";
        switch (random)
        {
            case 1:
            {
                Console.WriteLine("Your opponent chose: Rock");
                randomMove = "Rock";
                break;
            }

            case 2:
            {
                Console.WriteLine("Your opponent chose: Paper");
                randomMove = "Paper";
                break;
            }

            case 3:
            {
                Console.WriteLine("Your opponent chose: Scissors");
                randomMove = "Scissors";
                break;
            }

            default:
            {
                Console.WriteLine("Invalid input.");
                break;
            }
        }

        return randomMove;
    }
}