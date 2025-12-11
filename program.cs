using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktik19
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== ЗАДАНИЕ 1: Удаление дубликатов ===");
            List<string> names = new List<string> { "Анна", "Пётр", "Анна", "Ольга", "Пётр", "Иван" };
            List<string> uniqueNames = Task1.RemoveDuplicates(names);
            Console.WriteLine($"Результат: {string.Join(", ", uniqueNames)}");

            Console.WriteLine("\n=== ЗАДАНИЕ 2: Частота слов ===");
            string text = "Мама мыла раму мама мыла";
            Dictionary<string, int> wordFrequency = Task2.CountWords(text);
            foreach (var pair in wordFrequency)
            {
                Console.WriteLine($"{pair.Key} = {pair.Value}");
            }

            Console.WriteLine("\n=== ЗАДАНИЕ 3: Склад ===");
            Warehouse warehouse = new Warehouse();

            // Добавляем на склад 6 товаров
            warehouse.AddProduct("Молоко", 10);
            warehouse.AddProduct("Хлеб", 15);
            warehouse.AddProduct("Яйца", 20);
            warehouse.AddProduct("Сахар", 8);
            warehouse.AddProduct("Масло", 12);
            warehouse.AddProduct("Чай", 5);

            // Продаем 
            warehouse.SellProduct("Молоко");
            warehouse.SellProduct("Молоко");
            warehouse.SellProduct("Хлеб");
            warehouse.SellProduct("Яйца");
            warehouse.SellProduct("Вода"); 

            warehouse.PrintStock();
            warehouse.PrintSales();

            Console.WriteLine("\n=== ЗАДАНИЕ 4: Группировка студентов по баллам ===");
            List<Student> students = new List<Student>
        {
            new Student { Name = "Анна", Score = 93 },
            new Student { Name = "Петр", Score = 93 },
            new Student { Name = "Ольга", Score = 95 },
            new Student { Name = "Юлия", Score = 73 },
            new Student { Name = "Мария", Score = 73 }
        };

            Dictionary<int, List<string>> groupedStudents = Task4.GroupStudentsByScore(students);

            foreach (var group in groupedStudents)
            {
                Console.WriteLine($"{group.Key}: {string.Join(", ", group.Value)}");
            }

            Console.WriteLine("\n=== ЗАДАНИЕ 5: Кэш запросов ===");
            QueryCache cache = new QueryCache();

            Console.WriteLine("Добавляем 'погода'");
            cache.AddQuery("погода");
            cache.PrintCache();

            Console.WriteLine("\nДобавляем 'курс'");
            cache.AddQuery("курс");
            cache.PrintCache();

            Console.WriteLine("\nДобавляем 'новости'");
            cache.AddQuery("новости");
            cache.PrintCache();

            Console.WriteLine("\nДобавляем 'погода' (уже есть)");
            cache.AddQuery("погода");
            cache.PrintCache();

            Console.WriteLine("\nДобавляем 'спорт' (новый, кэш полный)");
            cache.AddQuery("спорт");
            cache.PrintCache();
        }
    }
}
