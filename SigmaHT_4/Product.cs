using System;

namespace SigmaHT_4
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public int ExpirationDate { get; set; }
        public DateTime ProductionDate { get; set; }

        public Product()
        {

        }

        public Product(string name, double price, double weight, int expirationDate,DateTime productionDate)
        {
            Name = name;
            Price = price;
            Weight = weight;
            ExpirationDate = expirationDate;
            ProductionDate = productionDate;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;

            Product product = (Product)obj;
            return (this.Name == product.Name);
        }

        public override string ToString()
        {
            return $"Name: {Name}\nPrice: {Price}\nWeight: {Weight}\n" +
                $"Expiration date: {ExpirationDate}\nProduction date: {ProductionDate}\n";
        }

        virtual public void Parse(string s)
        {
            string[] values = s.Split(' ');

            Name = values[1];

            double price;
            if (!double.TryParse(values[2], out price))
                throw new ArgumentException("Bad data in price");
            Price = price;

            double weight;
            if(!double.TryParse(values[3], out weight))
                throw new ArgumentException("Bad data in weight");
            Weight = weight;

            int expirationDate;
            if(!int.TryParse(values[4], out expirationDate))
                throw new ArgumentException("Bad data in expiration date");
            ExpirationDate = expirationDate;

            string[] dateTime = values[5].Split(':');
            
            int day, month, year;
            if(!int.TryParse(dateTime[0], out day))
                throw new ArgumentException("Bad data in number of days");
            if(!int.TryParse(dateTime[1], out month))
                throw new ArgumentException("Bad data in number of months");
            if(!int.TryParse(dateTime[2], out year))
                throw new ArgumentException("Bad data in number of years");

            DateTime productionDate = new DateTime(year, month, day);
            ProductionDate = productionDate;
        }

        public virtual void ChangePrice(double percentage)
        {
            Price += percentage * Price / 100;
        }
    }
}
