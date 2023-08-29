namespace Exercise4;

internal class Program
{
    private static void Main(string[] args)
    {
        var movie1 = new Movie("Casino Royale", "Eon Productions", "PG13");
        var movie2 = new Movie("Glass", "Buena Vista International", "PG13");
        var movie3 = new Movie("Spider-Man: Into the Spider-Verse", "Columbia Pictures");
        Movie[] movies = { movie1, movie2, movie3 };

        Console.WriteLine("Movies with a Rating of 'PG':");
        var pgMovies = Movie.GetPg(movies);
        foreach (var movie in pgMovies)
        {
            Console.WriteLine($"Title: {movie.GetTitle()}, Studio: {movie.GetStudio()}, Rating: {movie.GetRating()}");
        }
    }
}