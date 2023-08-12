namespace Exercise4;

internal class Movie
{
    public string rating;
    private readonly string studio;
    private readonly string title;

    public Movie(string title, string studio, string rating)
    {
        this.title = title;
        this.studio = studio;
        this.rating = rating;
    }

    public Movie(string title, string studio)
    {
        this.title = title;
        this.studio = studio;
        rating = "PG";
    }

    public static Movie[] GetPG(Movie[] movies)
    {
        return movies.Where(movie => movie.rating == "PG").ToArray();
    }

    public string GetTitle()
    {
        return title;
    }

    public string GetStudio()
    {
        return studio;
    }

    public string GetRating()
    {
        return rating;
    }
}