using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using _17ProjLinqLambda.Entities;

namespace _17ProjLinqLambda
{
    class Program
    {
        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);

            }
        }


        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Electronics", Tier = 1 };

            List<Product> products = new List<Product>()
            {
                new Product(){ Id = 1, Name = "Computer", Price = 1100.00, Category = c2},
                new Product(){ Id = 2, Name = "Hammer", Price = 90.00, Category = c1},
                new Product(){ Id = 3, Name = "Tv", Price = 1700.00, Category = c3},
                new Product(){ Id = 4, Name = "Notebook", Price = 1300.00, Category = c2},
                new Product(){ Id = 5, Name = "Saw", Price = 80.00, Category = c1},
                new Product(){ Id = 6, Name = "Tablet", Price = 700.00, Category = c2},
                new Product(){ Id = 7, Name = "Camera", Price =700.00, Category = c3},
                new Product(){ Id = 8, Name = "printer", Price = 350.00, Category = c3},
                new Product(){ Id = 9, Name = "MacBook", Price = 1800.00, Category = c2},
                new Product(){ Id = 10, Name = "Sound Bar", Price = 700.00, Category = c3},
                new Product(){ Id = 11, Name = "Level", Price = 70.00, Category = c1}

            };

            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900);

            Print("TIER 1 AND PRICE < 900 ", r1);

            var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            Print("NAMES OF PRODUCTS FROM TOOLS ", r2);

            var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            Print("NAMES STARTED WHIT 'C' AND ANONYMOUS OBJECT ", r3);

            var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME", r4);

            var r5 = r4.Skip(2).Take(4);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME, SKIP 2 TAKE 4", r5);

            var r6 = products.First();
            Console.WriteLine();
            Console.WriteLine("FIRST TEST1: " + r6);
             
        }
    }
}
