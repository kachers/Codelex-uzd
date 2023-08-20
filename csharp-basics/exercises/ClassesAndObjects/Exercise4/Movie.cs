namespace Exercise4;

internal class Movie
{
    public string Rating;
    private readonly string _studio;
    private readonly string _title;

    public Movie(string title, string studio, string rating)
    {
        _title = title;
        _studio = studio;
        Rating = rating;
    }

    public Movie(string title, string studio)
    {
        _title = title;
        _studio = studio;
        Rating = "PG";
    }

    public static Movie[] GetPg(Movie[] movies)
    {
        return movies.Where(movie => movie.Rating == "PG").ToArray();
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
        return Rating;
    }
}