using System;
using System.Threading;

namespace TicTacToe
{
    class Program
    {
        private static char[,] _board = new char[3, 3];

        private static void Main(string[] args)
        {
            InitBoard();
            DisplayBoard();
            var counter = 0;
            var random = new Random();
            while (BoardHasAnyEmptyCell() && CheckGameResult() )
            {
                var player = counter % 2 == 0 ? 'x' : 'o';
                string[] coords = new string[2];
                if (counter % 2 == 0)
                {
                    Console.WriteLine("Ievadiet koordinates formata X Y.");
                    var input = Console.ReadLine();
                    coords = input.Split(' ');
                }

                else
                {
                    Thread.Sleep(2000);
                    coords[0] = random.Next(0, 3).ToString();
                    coords[1] = random.Next(0, 3).ToString();
                    Console.WriteLine($"{coords[0]} {coords[1]}");
                }
               
                var x = int.Parse(coords[0]);
                var y = int.Parse(coords[1]);
                if (x<=2&&y<=2&&x>=0&&y>=0&&_board[x, y] == ' ')
                {
                    _board[x, y] = player;
                    
                }

                counter++;
                DisplayBoard();
            }
        }

        private static bool CheckGameResult()
        {
            if ( _board[0, 0] == 'x' && _board[0, 1] == 'x' &&
                 _board[0, 2] == 'x' ||
                 _board[1, 0] == 'x' && _board[1, 1] == 'x' &&
                 _board[1, 2] == 'x' ||
                 _board[2, 0] == 'x' && _board[2, 1] == 'x' &&
                 _board[2, 2] == 'x' ||
                 _board[0, 0] == 'x' && _board[1, 0] == 'x' &&
                 _board[2, 0] == 'x' ||
                 _board[0, 1] == 'x' && _board[1, 1] == 'x' &&
                 _board[2, 1] == 'x' ||
                 _board[0, 2] == 'x' && _board[1, 2] == 'x' &&
                 _board[2, 2] == 'x' ||
                 _board[0, 0] == 'x' && _board[1, 1] == 'x' &&
                 _board[2, 2] == 'x' ||
                 _board[0, 2] == 'x' && _board[1, 1] == 'x' &&
                 _board[2, 0] == 'x')
            {
                Console.Beep();
                Console.WriteLine("Player using symbol 'x' won the Game.");
                Console.WriteLine("Press any key to close the app");
                Console.ReadKey();
                Console.WriteLine("\nGame is closing");
                Thread.Sleep(5000);
                return false;
            }

            else if (_board[0, 0] == 'o' && _board[0, 1] == 'o' &&
                     _board[0, 2] == 'o' ||
                     _board[1, 0] == 'o' && _board[1, 1] == 'o' &&
                     _board[1, 2] == 'o' &&
                     _board[2, 0] == 'o' && _board[2, 1] == 'o' &&
                     _board[2, 2] == 'o' ||
                     _board[0, 0] == 'o' && _board[1, 0] == 'o' &&
                     _board[2, 0] == 'o' ||
                     _board[0, 1] == 'o' && _board[1, 1] == 'o' &&
                     _board[2, 1] == 'o' ||
                     _board[0, 2] == 'o' && _board[1, 2] == 'o' &&
                     _board[2, 2] == 'o' ||
                     _board[0, 0] == 'o' && _board[1, 1] == 'o' &&
                     _board[2, 2] == 'o' ||
                     _board[0, 2] == 'o' && _board[1, 1] == 'o' &&
                     _board[2, 0] == 'o')
            {
                Console.Beep();
                Console.WriteLine("Player using symbol 'o' won the Game.");
                Console.WriteLine("Press any key to close the app");
                Console.ReadKey();
                Console.WriteLine("\nGame is closing");
                Thread.Sleep(5000);
                return false;
            }

            return true;
        }

        private static bool BoardHasAnyEmptyCell()
        {
            for (var r = 0; r < 3; r++)
            {
                for (var c = 0; c < 3; c++)
                {
                    if (_board[r, c] == ' ')
                    {
                        return true;
                    }
                }
            }
            Console.Beep();
            Console.WriteLine("The game is a tie.");
            Console.WriteLine("Press any key to close the app");
            Console.ReadKey();
            Console.WriteLine("\nGame is closing");
            Thread.Sleep(5000);
            return false;
        }

        private static void InitBoard()
        {
            for (var r = 0; r < 3; r++)
            {
                for (var c = 0; c < 3; c++)
                    _board[r, c] = ' ';
            }
        }

        private static void DisplayBoard()
        {
            Console.WriteLine("  0  " + _board[0, 0] + "|" + _board[0, 1] + "|" + _board[0, 2]);
            Console.WriteLine("    --+-+--");
            Console.WriteLine("  1  " + _board[1, 0] + "|" + _board[1, 1] + "|" + _board[1, 2]);
            Console.WriteLine("    --+-+--");
            Console.WriteLine("  2  " + _board[2, 0] + "|" + _board[2, 1] + "|" + _board[2, 2]);
            Console.WriteLine("    --+-+--");
        }
    }
}
