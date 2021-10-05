using System;

namespace SigmaHT_4
{
    static class ConsoleWorker
    {
        static public Storage GetProducts()
        {
            Console.WriteLine("Enter how many products you want to add:");

            int numOfProducts = int.Parse(Console.ReadLine());

            int choice;
            string name;
            double price, weight;
            int expirationDate;

            Storage storage = new Storage(numOfProducts);

            for (int i = 0; i < storage.Products.Length; i++)
            {
                Console.WriteLine($"\n--- {i + 1} product ---");
                Console.WriteLine("Choose product from the list:" +
                    "\n1 -- Meat\n2 -- Dairy_products\n3 -- Other product");
                choice = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter name:");
                name = Console.ReadLine();

                Console.WriteLine("Enter price:");
                price = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter weight:");
                weight = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter expiration date:");
                expirationDate = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter date of production:");
                string[] dateTime = Console.ReadLine().Split(':');
                int day, month, year;
                int.TryParse(dateTime[0], out day);
                int.TryParse(dateTime[1], out month);
                int.TryParse(dateTime[2], out year);
                DateTime productionDate = new DateTime(year, month, day);

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Choose category from the list:" +
                            "\n1 -- ExtraClass\n2 -- FirstClass\n3 -- SecondClass");
                        int category = int.Parse(Console.ReadLine());
                        MeatCategory meatCategory = MeatCategory.ExtraClass;
                        switch (category)
                        {
                            case 1: meatCategory = MeatCategory.ExtraClass; break;
                            case 2: meatCategory = MeatCategory.FisrtCalss; break;
                            case 3: meatCategory = MeatCategory.SecondClass; break;
                        }

                        Console.WriteLine("Choose kind of meat from the list:" +
                            "\n1 -- Mutton\n2 -- Veal\n3 -- Pork\n4 -- Chicken");
                        int kind = int.Parse(Console.ReadLine());
                        KindOfMeat kindOfMeat = KindOfMeat.Chicken;
                        switch (kind)
                        {
                            case 1: kindOfMeat = KindOfMeat.Mutton; break;
                            case 2: kindOfMeat = KindOfMeat.Veal; break;
                            case 3: kindOfMeat = KindOfMeat.Pork; break;
                            case 4: kindOfMeat = KindOfMeat.Chicken; break;
                        }

                        storage[i] = new Meat(name, price, weight, expirationDate, productionDate
                            , meatCategory, kindOfMeat); break;

                    case 2:

                        storage[i] = new Dairy_products(name, price, weight,
                            expirationDate, productionDate); break;

                    case 3: storage[i] = new Product(name, price, weight,
                        expirationDate, productionDate); break;
                }


            }

            return storage;
        }
    }
}
