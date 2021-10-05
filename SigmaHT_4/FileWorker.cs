using System;
using System.IO;

namespace SigmaHT_4
{
    class FileWorker
    {
        public string Text { get; set; }

        public FileWorker(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                Text = reader.ReadToEnd();
            }
        }
        public Storage GetProducts()
        {
            string[] products = Text.Replace("\r\n","\n").Split('\n');

            Storage storage = new Storage(products.Length);
            Product product = new Product();

            for (int i = 0; i < products.Length; i++)
            {
                switch (products[i].Split(' ')[0])
                {
                    case "Ordinary:": product = new Product(); break;
                    case "Meat:": product = new Meat(); break;
                    case "Dairy:": product = new Dairy_products(); break;
                }
                try
                {
                    product.Parse(products[i]);
                }
                catch (ArgumentException)
                {
                    throw;
                }
          
                storage[i] = product;
            }

            return storage;
        }
    }
}
