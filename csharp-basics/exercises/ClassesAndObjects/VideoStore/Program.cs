using System;

namespace VideoStore;

internal class Program
{
    private static VideoStore _videoStore;

    public static void Main(string[] args)
    {
        _videoStore = new VideoStore();
        var userChoice = 0;
        while (true)
        {
            userChoice = GetMenu();
            switch (userChoice)
            {
                case 0:
                    return;
                case 1:
                    FillVideoStore();
                    break;
                case 2:
                    RentVideo();
                    break;
                case 3:
                    ReturnVideo();
                    break;
                case 4:
                    ListInventory();
                    break;
                case 5:
                    RateVideo();
                    break;
                default:
                    return;
            }
        }
    }

    public static int GetMenu()
    {
        Console.WriteLine("Choose the operation you want to perform ");
        Console.WriteLine("Choose 1 to fill video store");
        Console.WriteLine("Choose 2 to rent video (as user)");
        Console.WriteLine("Choose 3 to return video (as user)");
        Console.WriteLine("Choose 4 to list inventory");
        Console.WriteLine("Choose 5 to rate a video");
        Console.WriteLine("Choose 6 for EXIT");

        while (true)
        {
            var keyboard = Console.ReadKey();
            if (!char.IsDigit(keyboard.KeyChar))
            {
                Console.WriteLine("\nInvalid input. Please enter a valid integer.");
            }
            else
            {
                var userChoice = int.Parse(keyboard.KeyChar.ToString());
                if (userChoice < 1 || userChoice > 6)
                    Console.WriteLine("Invalid choice, please use number 1-6.");
                else
                    return userChoice;
            }
        }
    }

    private static void ListInventory()
    {
        _videoStore.ListAvailableVideos();
    }

    private static void FillVideoStore()
    {
        while (true)
        {
            Console.Write("\nProvide a movie title: ");
            var title = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(title))
            {
                _videoStore.AddToInventory(title);
                break;
            }

            Console.WriteLine("Invalid title. Please enter a non-empty title.");
        }
    }

    private static void RentVideo()
    {
        Console.Write("\nProvide a movie title: ");
        var title = Console.ReadLine();
        _videoStore.CheckOut(title);
    }

    private static void ReturnVideo()
    {
        Console.Write("\nProvide a movie title: ");
        var title = Console.ReadLine();
        _videoStore.ReturnVideo(title);
    }

    private static void RateVideo()
    {
        Console.Write("\nProvide a movie title: ");
        var title = Console.ReadLine();
        double rating;
        while (true)
        {
            Console.Write("\nProvide a rating 0-10: ");
            if (double.TryParse(Console.ReadLine(), out rating) && rating < 10 && rating > 0) break;
            Console.WriteLine("\nInvalid input. Please enter a valid number.");
        }

        _videoStore.ReceiveRating(title, rating);
    }
}