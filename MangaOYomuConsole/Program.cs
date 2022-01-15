using System;
using MangaOYomu;

namespace MangaOYomuConsole
{
    class Program
    {
        static void Main()
        {
            //вызывается несуществующий метод
            //DeleteFlight(1);
            while (true)
            {
                var command = Console.ReadLine();
                Execute(command);
            }
        }

        private static void Execute(string command)
        {
            switch (command)
            {
                case "put":
                    Add(command);
                    break;
                case "get":
                    Get(command);
                    break;
                case "update":
                    Update(command);
                    break;
                case "delete":
                    Remove(command);
                    break;
                default:
                    Console.WriteLine($"Unknown command");
                    break;
            }
        }

        private static void Add(string command)
        {
            //некорректно обьявлена переменная temp, объявить переменные и поместить в них элементы массива 
            string[] temp = Console.ReadLine().Trim().Split(' ');
            //переменная не соответствует code convention
            bool t = false;
            switch (command)
            {
                case "MangaTitles":
                    t = DataAccess.AddNewMangaTitle(temp[0], temp[1], int.Parse(temp[2]), decimal.Parse(temp[3]),
                         temp[4], int.Parse(temp[5]), int.Parse(temp[6]), int.Parse(temp[7]), int.Parse(temp[8]), int.Parse(temp[9]), int.Parse(temp[10]));
                    break;
                case "Publisher":
                    t = DataAccess.AddNewPublisher(temp[0]);
                    break;
                case "Artist":
                    t = DataAccess.AddNewArtist(temp[0]);
                    break;
                case "Author":
                    t = DataAccess.AddNewAuthor(temp[0]);
                    break;
                case "Genres":
                    t = DataAccess.AddNewGenre(temp[0], temp[1]);
                    break;
                default:
                    Console.WriteLine($"Unknown command");
                    break;
            }

            Output(t);
        }
        //хорошее решение
        private static void Get(string command)
        {
            switch (command)
            {
                case "MangaTitles":
                    foreach (var a in DataAccess.GetMangaTitles())
                        Console.WriteLine($"{a.Name} {a.Description}");
                    break;
                case "Artists":
                    foreach (var a in DataAccess.GetArtists())
                        Console.WriteLine($"{a.Name}");
                    break;
                case "Publishers":
                    foreach (var a in DataAccess.GetPublishers())
                        Console.WriteLine($"{a.Name}");
                    break;
                case "Authors":
                    foreach (var a in DataAccess.GetAuthors())
                        Console.WriteLine($"{a.Name}");
                    break;
                case "MangaTypes":
                    foreach (var a in DataAccess.GetMangaTypes())
                        Console.WriteLine($"{a.Name}");
                    break;
                case "AgeStatus":
                    foreach (var a in DataAccess.GetAgeStatuses())
                        Console.WriteLine($"{a.Name}");
                    break;
                case "TitleStatus":
                    foreach (var a in DataAccess.GetTitleStatuses())
                        Console.WriteLine($"{a.Name}");
                    break;
                case "Genres":
                    foreach (var a in DataAccess.GetGenres())
                        Console.WriteLine($"{a.Name} {a.Description}");
                    break;
                default:
                    Console.WriteLine($"Unknown command");
                    break;
            }
        }
        private static void Remove(string command)
        {
            int n = int.Parse(Console.ReadLine());
            switch (command)
            {
                case "Genres":
                    DataAccess.DeleteGenre(n);
                    break;
                default:
                    Console.WriteLine($"Unknown command");
                    break;
            }
        }

        private static void Update(string command)
        {
            string[] temp = Console.ReadLine().Split(' ');
            switch (command)
            {
                case "Genres":
                    DataAccess.UpdateGenres(int.Parse(temp[0]), DataAccess.GetGenre(temp[0]));
                    break;
            }
        }

        public static void Output(bool t)
        {
            Console.WriteLine(t ? "OK" : "NOT OK");
        }
    }
}
