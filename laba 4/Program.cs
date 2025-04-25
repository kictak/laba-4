using System;
using System.IO;
using System.Text.RegularExpressions;

namespace laba_4
{
    internal class Program
    {
        #region Тесты
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("C:\\test_data.txt");

            Console.WriteLine("Какую проверку запустить? (1(ааа..),2(5 символов),3(email),4()");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AAACheck(input);
                    break;
                case 2:
                    FiveCheack(input);
                    break;
                case 3:
                    EmailCheack(input);
                    break;
                case 4:
                    // Перебираем все строки и проверяем каждую на координаты
                    foreach (string line in input)
                    {
                        Coordinates(line); // Теперь передаем одну строку, а не массив
                    }
                    break;
                default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }
        }
        #endregion

        #region 1.Написать регулярное выражение, которые проверят строки на соответствие: «a», «aaaaaa», «a aa a». 

        static void AAACheck(string[] lines)
        {
            Regex regex = new Regex(@"^[a\s]+$");
            Console.WriteLine("\n=== Первая проверка ===");

            foreach (string line in lines)
            {
                bool isMatch = regex.IsMatch(line);
                Console.WriteLine($"\"{line}\" — {(isMatch ? "Подходит" : "Не подходит")}");
            }
        }

        #endregion

        #region 2.Написать регулярное выражение, заставляющее вводить не менее 5 алфавитно-цифровых символов.

        static void FiveCheack(string[] lines)
        {
            Regex regex = new Regex(@"[a-zA-Z0-9]{5,}"); //1 вариант [a-zA-Z0-9] второй вариант включающтй Unicode [\p{L}\p{Nd}] p[L] все буквы, в том числе и заглавные p[Nd] все цифры
            Console.WriteLine("\n=== Вторая проверка ===");

            foreach (string line in lines)
            {
                bool isMatch = regex.IsMatch(line);
                Console.WriteLine($"\"{line}\" — {(isMatch ? "Подходит" : "Не подходит")}");
            }
        }

        #endregion

        #region 3.Написать регулярное выражение, которое проверят email простого вида (например, test@test.test).

        static void EmailCheack(string[] lines)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9](?:[a-zA-Z0-9._%+-]*[a-zA-Z0-9])?@[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.[a-zA-Z]{2,}$");
            Console.WriteLine("\n=== Вторая проверка ===");

            foreach (string line in lines)
            {
                bool isMatch = regex.IsMatch(line);
                Console.WriteLine($"\"{line}\" — {(isMatch ? "Подходит" : "Не подходит")}");
            }
        }

        #endregion

        #region 4. b.Написать регулярное выражение, которые считывает из строки географические координаты городов
        static string Coordinates(string input)
        {
            Regex regex = new Regex(@"^([А-Яа-яЁё-]+)\s*:\s*(?:широта\s+)?([-+]?\d+\.?\d*)\s*,?\s*(?:долгота\s+)?([-+]?\d+\.?\d*)");
            Match match = regex.Match(input);

            if (match.Success)
            {
                return $"Город: {match.Groups[1].Value}\n" +
                       $"Широта: {match.Groups[2].Value}\n" +
                       $"Долгота: {match.Groups[3].Value}";
            }
            else
            {
                return "Не найдено";
            }
            #endregion







        }
    }
}
