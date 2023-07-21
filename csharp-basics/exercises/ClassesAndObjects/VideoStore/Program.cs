using System;

namespace VideoStore
{

    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose the operation you want to perform ");
                Console.WriteLine("Choose 0 for EXIT");
                Console.WriteLine("Choose 1 to fill video store");
                Console.WriteLine("Choose 2 to rent video (as user)");
                Console.WriteLine("Choose 3 to return video (as user)");
                Console.WriteLine("Choose 4 to list inventory");

                int n = Convert.ToByte(Console.ReadLine());

                switch (n)
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
                    default:
                        return;
                }
            }
        }

        private static void ListInventory()
        {

        }

        private static void FillVideoStore()
        {

        }

        private static void RentVideo()
        {

        }

        private static void ReturnVideo()
        {

        }
    }
}
