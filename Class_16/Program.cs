using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Class_16
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Product[] products = new Product[n];  // создаем масив из 5ти товаров

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара");
                int code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара");
                string name = Console.ReadLine();
                Console.WriteLine("Введите цену товара");
                double price = Convert.ToInt32(Console.ReadLine());
                products[i] = new Product() { codeProduct = code, nameProduct = name, priceProduct = price };
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(products, options);

            using (StreamWriter sw=new StreamWriter("../../../Product.json")) // с помощью ../ поднимаемся на 1 уровень в верх (папки) 
            {
                sw.WriteLine(jsonString);
            }
        }
    }
}
