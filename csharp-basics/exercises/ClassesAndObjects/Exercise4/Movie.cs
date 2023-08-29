namespace Exercise4;

internal class Movie
{
    private string _rating;
    private readonly string _studio;
    private readonly string _title;

    public Movie(string title, string studio, string rating)
    {
        _title = title;
        _studio = studio;
        _rating = rating;
    }

    public Movie(string title, string studio)
    {
        _title = title;
        _studio = studio;
        _rating = "PG";
    }

    public static Movie[] GetPg(Movie[] movies)
    {
        return movies.Where(movie => movie._rating == "PG").ToArray();
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetStudio()
    {
        return _studio;
    }

    public string GetRating()
    {
        return _rating;
    }
}