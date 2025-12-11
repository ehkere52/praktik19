using System;
using System.Collections.Generic;
using System.Linq;


static class Task1
{
    public static List<string> RemoveDuplicates(List<string> names)
    {
        List<string> result = new List<string>();

        foreach (string name in names)
        {
            if (!result.Contains(name))
            {
                result.Add(name);
            }
        }

        return result;
    }
}


static class Task2
{
    public static Dictionary<string, int> CountWords(string text)
    {
        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        string[] words = text.ToLower().Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            string cleanedWord = word.Trim();

            if (wordCount.ContainsKey(cleanedWord))
            {
                wordCount[cleanedWord]++;
            }
            else
            {
                wordCount[cleanedWord] = 1;
            }
        }

        return wordCount;
    }
}


class Warehouse
{
    private Dictionary<string, int> stock = new Dictionary<string, int>();
    private List<string> soldHistory = new List<string>();

    
    public void AddProduct(string product, int quantity)
    {
        if (stock.ContainsKey(product))
        {
            stock[product] += quantity;
        }
        else
        {
            stock[product] = quantity;
        }
    }

    
    public bool SellProduct(string product)
    {
        if (stock.ContainsKey(product) && stock[product] > 0)
        {
            stock[product]--;
            soldHistory.Add(product);
            return true;
        }
        else
        {
            Console.WriteLine($"Товара '{product}' нет в наличии");
            return false;
        }
    }

   
    public void PrintStock()
    {
        Console.WriteLine("Остатки:");
        foreach (var item in stock)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }

    
    public void PrintSales()
    {
        Console.WriteLine("\nПродано:");

        var salesCount = new Dictionary<string, int>();
        foreach (string product in soldHistory)
        {
            if (salesCount.ContainsKey(product))
            {
                salesCount[product]++;
            }
            else
            {
                salesCount[product] = 1;
            }
        }

        foreach (var sale in salesCount)
        {
            string times = sale.Value == 1 ? "раз" : "раза";
            Console.WriteLine($"{sale.Key}: {sale.Value} {times}");
        }
    }
}


class Student
{
    public string Name { get; set; }
    public int Score { get; set; }
}

static class Task4
{
    public static Dictionary<int, List<string>> GroupStudentsByScore(List<Student> students)
    {
        Dictionary<int, List<string>> grouped = new Dictionary<int, List<string>>();

        foreach (Student student in students)
        {
            if (!grouped.ContainsKey(student.Score))
            {
                grouped[student.Score] = new List<string>();
            }
            grouped[student.Score].Add(student.Name);
        }

        return grouped.OrderByDescending(g => g.Key)
                     .ToDictionary(g => g.Key, g => g.Value);
    }
}


class QueryCache
{
    private Dictionary<string, string> cache = new Dictionary<string, string>();
    private List<string> order = new List<string>();
    private readonly int maxSize = 3;

    public void AddQuery(string query)
    {
        string response = $"Ответ на запрос: {query}";

        if (cache.ContainsKey(query))
        {
            order.Remove(query);
            order.Add(query);
        }
        else
        {
            if (cache.Count >= maxSize)
            {
                string oldest = order[0];
                cache.Remove(oldest);
                order.RemoveAt(0);
            }

            cache[query] = response;
            order.Add(query);
        }
    }

    public void PrintCache()
    {
        Console.WriteLine("\nТекущий кэш:");
        foreach (string query in order)
        {
            Console.WriteLine($"{query}: {cache[query]}");
        }
    }
}
