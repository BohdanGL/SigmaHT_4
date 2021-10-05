using System;
using System.IO;

namespace SigmaHT_4
{
    class Storage
    {
        public Product[] Products { get; set; }


        public Storage(int numberOfProducts=0)
        {
            Products = new Product[numberOfProducts];

            for (int i = 0; i < Products.Length; i++)
            {
                Products[i] = new Product();
            }
        }

        public Product this[int index]
        {
            get { return Products[index]; }
            set { Products[index] = value; }
        }

        public override string ToString()
        {
            string output = "\nProducts in the storage:";

            for (int i = 0; i < Products.Length; i++)
            {
                output += $"\n\n--- {i + 1} product ---\n";
                output += Products[i];
            }

            return output;
        }

        public Product[] FindAllMeatProducts()
        {
            int count = 0;
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].GetType() == typeof(Meat))
                    count++;
            }

            Product[] products = new Meat[count];

            for (int i = 0, j = 0; i < products.Length; i++)
            {
                if (products[i].GetType() == typeof(Meat))
                {
                    products[j] = Products[i];
                    j++;
                }

            }

            return products;
        }

        public void DeleteAllExpiredDairyProducts(string filePath)
        {
            int count = 0;

            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].GetType() == typeof(Dairy_products)
                    && DateTime.Now > Products[i].ProductionDate.AddDays(Products[i].ExpirationDate))
                    count++;
                
            }

            Product[] products = new Product[Products.Length - count];

            for (int i = 0,j=0; i < Products.Length; i++)
            {
                if (Products[i].GetType() == typeof(Dairy_products)
                    && DateTime.Now > Products[i].ProductionDate.AddDays(Products[i].ExpirationDate))
                {
                    PrintToFile(filePath, Products[i]);
                    continue;
                }

                products[j] = Products[i];
                j++;
            }

            Products = products;

        }

        public void PrintToFile(string filePath, Product product)
        {
            StreamWriter streamWriter = new StreamWriter(filePath);

            streamWriter.WriteLine(product);

            streamWriter.Close();
        }

        public void ChangePriceForAllProducts(double percentage)
        {
            for (int i = 0; i < Products.Length; i++)
            {
                Products[i].ChangePrice(percentage);
            }
        }

    }
}
