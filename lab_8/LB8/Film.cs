using System;

public class Film
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Director { get; set; }

    public int Year { get; set; }

    public string Genre { get; set; }

    public double Rating { get; set; }

    public double DurationMinutes { get; set; }

    public Film(int id, string title, string director, int year, string genre, double rating, double durationMinutes)
    {
        Id = id;
        Title = title;
        Director = director;
        Year = year;
        Genre = genre;
        Rating = rating;
        DurationMinutes = durationMinutes;
    }

    public override string ToString()
    {
        return $"{Id}: \"{Title}\" ({Year}), реж. {Director}, жанр {Genre}, рейтинг {Rating:F1}, длительность {DurationMinutes:F0} мин.";
    }
}
