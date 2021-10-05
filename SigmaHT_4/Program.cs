using System;

namespace SigmaHT_4
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWorker fileWorker = new FileWorker(@"C:\Users\User\source\repos\SigmaHT_4\SigmaHT_4\Input.txt");

            Storage storage = new Storage();
            try
            {
                storage = fileWorker.GetProducts();
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine(storage);

            Console.WriteLine("\nEnter name of file to write all expired dairy products");

            storage.DeleteAllExpiredDairyProducts(Console.ReadLine());

            Console.WriteLine("Storage after deleting all expired dairy products:");

            Console.WriteLine(storage);
            
            Console.WriteLine("\nEnter first polinomial:");

            Polynomial polynomial1 = new Polynomial();
            try
            {
                polynomial1.Parse(Console.ReadLine());
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("Enter second polinomial:");

            Polynomial polynomial2 = new Polynomial();

            try
            {
                polynomial2.Parse(Console.ReadLine());
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("\nSum of polinomials: " + polynomial1.Add(polynomial2));
            Console.WriteLine("\nSubtractiong of first and second polinomals: " + polynomial1.Subtract(polynomial2));
            Console.WriteLine("\nMultyplying of polinominals: " + polynomial1.Multiply(polynomial2));

        }
    }
}
