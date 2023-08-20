using System;
using System.Collections.Generic;
using System.Linq;

namespace VideoStore
{
    internal class VideoStore
    {
        private readonly List<Video> _inventory;
        
        public VideoStore()
        {
            _inventory = new List <Video>();
        }

        public void AddToInventory(string title)
        {
            _inventory.Add(new Video(title));
        }

        public void CheckOut(string title)
        {
            foreach (var t in _inventory.Where(t => t.Title == title))
            {
                t.BeingCheckedOut();
                break;
            }
        }

        public void ReturnVideo(string title)
        {
            foreach (var t in _inventory.Where(t => t.Title == title))
            {
                t.BeingReturned();
                break;
            }
        }

        public void ReceiveRating(string title, double rating)
        {
            foreach (var t in _inventory.Where(t => t.Title == title))
            {
                t.ReceiveRating(rating);
                break;
            }
        }

        public void ListAvailableVideos()
        {
            Console.WriteLine();
            foreach (var t in _inventory)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();
        }
    }
}
