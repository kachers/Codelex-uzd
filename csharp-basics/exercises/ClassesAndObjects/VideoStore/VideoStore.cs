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

        public void CheckOut(Video video)
        {
            video.BeingCheckedOut();
        }

        public void ReturnVideo(Video video)
        {
            video.BeingReturned();
        }

        public void ReceiveRating(Video video, double rating)
        {
            video.ReceiveRating(rating);
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

        public Video SelectVideo(string title)
        {
            return _inventory.Where(t => t.Title == title).FirstOrDefault();
        }
    }
}
