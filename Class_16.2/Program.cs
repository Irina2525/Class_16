using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Class_16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty; // константа Empty равносильна пустым ковычкам 
            using (StreamReader sr = new StreamReader("../../../Product.json"))
            {
                 jsonString = sr.ReadToEnd();
            }
            Product [] products= JsonSerializer.Deserialize<Product[]>(jsonString);// превращаем строку jsonString в массив  <Product[]>

            Product maxProduct = products[0];
            foreach (Product p in products)
            {
                if (p.priceProduct > maxProduct.priceProduct)
                {
                    maxProduct = p;
                }
            }
            Console.WriteLine($"{maxProduct.codeProduct} {maxProduct.nameProduct} {maxProduct.priceProduct}");
            Console.ReadKey();
        }
    }
}
