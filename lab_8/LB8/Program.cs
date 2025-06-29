using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var films = FilmBase.Load();

        while (true)
        {
            Console.WriteLine("\n\tКаталог фильмов");
            Console.WriteLine("1\tВсе фильмы");
            Console.WriteLine("2\tУдалить");
            Console.WriteLine("3\tДобавить");
            Console.WriteLine("4\tСортировать");
            Console.WriteLine("0\tВыход");
            Console.Write("Выберите действие: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Ошибка, введите число.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    FilmBase.ViewAll(films);
                    break;

                case 3:
                    try
                    {
                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Название: ");
                        string title = Console.ReadLine();
                        Console.Write("Режиссёр: ");
                        string director = Console.ReadLine();
                        Console.Write("Год: ");
                        int year = int.Parse(Console.ReadLine());
                        Console.Write("Жанр: ");
                        string genre = Console.ReadLine();
                        Console.Write("Рейтинг: ");
                        double rating = double.Parse(Console.ReadLine());
                        Console.Write("Длительность (мин): ");
                        double duration = double.Parse(Console.ReadLine());

                        var newFilm = new Film(id, title, director, year, genre, rating, duration);
                        FilmBase.Add(films, newFilm);
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка при вводе данных.");
                    }
                    break;

                case 2:
                    Console.Write("Введите ID для удаления: ");
                    if (int.TryParse(Console.ReadLine(), out int delId))
                        FilmBase.Delete(films, delId);
                    else
                        Console.WriteLine("Неверный ID.");
                    break;

                case 4:
                    ShowSorted(films);
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Недопустимый пункт меню.");
                    break;
            }
        }
    }

    static void ShowSorted(List<Film> films)
    {
        Console.WriteLine("\n\tЗАПРОСЫ");
        Console.WriteLine("1.\tСортировать по жанру");
        Console.WriteLine("2.\tСортировать по режиссёру");
        Console.WriteLine("3.\tСортировать по рейтингу");
        Console.WriteLine("4.\tСредняя длительность");
        Console.Write("Выберите запрос: ");

        if (!int.TryParse(Console.ReadLine(), out int q))
        {
            Console.WriteLine("Неверный ввод.");
            return;
        }

        switch (q)
        {
            case 1:
                Console.Write("Жанр: ");
                foreach (var f in FilmBase.SortByGenre(films, Console.ReadLine()))
                    Console.WriteLine(f);
                break;

            case 2:
                Console.Write("Режиссёр: ");
                string dir = Console.ReadLine();
                Console.Write("Год: ");
                if (int.TryParse(Console.ReadLine(), out int yr))
                    foreach (var f in FilmBase.SortByDirectorAfterYear(films, dir, yr))
                        Console.WriteLine(f);
                break;

            case 3:
                var maxRate = FilmBase.ShowMaxRating(films);
                Console.WriteLine(maxRate.HasValue ? $"Максимальный рейтинг: {maxRate:F1}" : "Нет данных.");
                break;

            case 4:
                var aDuration = FilmBase.AverageDuration(films);
                Console.WriteLine(aDuration.HasValue ? $"Средняя длительность: {aDuration:F1} мин." : "Нет данных.");
                break;

            default:
                Console.WriteLine("Неверный запрос.");
                break;
        }
    }
}
