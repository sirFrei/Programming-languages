using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class FilmBase
{
    private const string DbFileName = "films.db";

    public static List<Film> Load()
    {
        var films = new List<Film>();
        if (!File.Exists(DbFileName))
            return films;

        try
        {
            using var stream = File.Open(DbFileName, FileMode.Open, FileAccess.Read);
            using var reader = new BinaryReader(stream);

            int count = reader.ReadInt32();              
            for (int i = 0; i < count; i++)
            {
                int id = reader.ReadInt32();
                string title = reader.ReadString();
                string director = reader.ReadString();
                int year = reader.ReadInt32();
                string genre = reader.ReadString();
                double rating = reader.ReadDouble();
                double duration = reader.ReadDouble();

                films.Add(new Film(id, title, director, year, genre, rating, duration));
            }
        }
        catch
        {
            Console.WriteLine("Ошибка при чтении файла базы данных.");
        }

        return films;
    }

    public static void Save(List<Film> films)
    {
        try
        {
            using var stream = File.Open(DbFileName, FileMode.Create, FileAccess.Write);
            using var writer = new BinaryWriter(stream);

            writer.Write(films.Count);                   
            foreach (var f in films)
            {
                writer.Write(f.Id);
                writer.Write(f.Title);
                writer.Write(f.Director);
                writer.Write(f.Year);
                writer.Write(f.Genre);
                writer.Write(f.Rating);
                writer.Write(f.DurationMinutes);
            }
        }
        catch
        {
            Console.WriteLine("Ошибка при сохранении файла базы данных.");
        }
    }

    public static void ViewAll(List<Film> films)
    {
        if (!films.Any())
        {
            Console.WriteLine("База данных пуста.");
            return;
        }
        films.ForEach(f => Console.WriteLine(f));
    }

    public static void Add(List<Film> films, Film newFilm)
    {
        if (films.Any(f => f.Id == newFilm.Id))
        {
            Console.WriteLine("Фильм с таким ID уже существует.");
            return;
        }
        films.Add(newFilm);
        Save(films);
        Console.WriteLine("Фильм добавлен.");
    }

    public static void Delete(List<Film> films, int id)
    {
        var film = films.FirstOrDefault(f => f.Id == id);
        if (film == null)
        {
            Console.WriteLine("Фильм не найден.");
            return;
        }
        films.Remove(film);
        Save(films);
        Console.WriteLine("Фильм удалён.");
    }


    public static IEnumerable<Film> SortByGenre(List<Film> films, string genre) =>
        films.Where(f => f.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));

    public static IEnumerable<Film> SortByDirectorAfterYear(List<Film> films, string director, int year) =>
        films.Where(f => f.Director.Equals(director, StringComparison.OrdinalIgnoreCase) && f.Year > year);

    public static double? ShowMaxRating(List<Film> films) =>
        films.Any() ? films.Max(f => f.Rating) : null;

    public static double? AverageDuration(List<Film> films) =>
        films.Any() ? films.Average(f => f.DurationMinutes) : null;
}
