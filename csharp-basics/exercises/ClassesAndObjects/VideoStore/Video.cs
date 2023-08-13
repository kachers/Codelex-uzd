using System;
using System.Collections.Generic;
using System.Linq;

namespace VideoStore
{
    internal class Video
    {

        private readonly List<double> _ratings;

        public Video(string title)
        {
            Title = title;
            IsAvailable = true;
            _ratings = new List<double>();
        }

        public string Title { get; }
        public bool IsAvailable { get; private set; }
        public double AverageRating => _ratings.Any() ? _ratings.Average() : 0;

        public void BeingCheckedOut()
        {
            if (IsAvailable) IsAvailable = false;
        }

        public void BeingReturned()
        {
            if (!IsAvailable) IsAvailable = true;
        }

        public void ReceiveRating(double rating)
        {
            _ratings.Add(rating);
        }

        public override string ToString()
        {
            return $"Title: {Title} | Average Rating: {AverageRating} | Available: {IsAvailable}";
        }
    }
}
