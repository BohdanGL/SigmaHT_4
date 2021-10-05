using System;

namespace SigmaHT_4
{
    class Polynomial
    {
        private double[] coefficients;
        public double X { get; set; }
        public int Poryadok { get; set; }

        public Polynomial(int poryadok=-1)
        {
            Poryadok = poryadok;
            coefficients = new double[Poryadok + 1];
        }

        public double this[int index]
        {
            set 
            {
                if (value != 0 && Poryadok >= 0)
                    coefficients[index] = value;
                else if (value != 0 && Poryadok <= 0)
                {
                    Poryadok = 0;
                    coefficients = new double[Poryadok + 1];
                    coefficients[index] = value;
                }
                else if (value == 0 && Poryadok >= 0)
                {
                    double[] coefficients = new double[this.coefficients.Length - 1];

                    for (int i = 0, j = 0; i < this.coefficients.Length; i++, j++)
                    {
                        if (i == index)
                        {
                            j--;
                            continue;
                        }
                        coefficients[j] = this.coefficients[i];
                    }

                    this.coefficients = coefficients;
                }
                else if (value == 0 && Poryadok <= 0)
                    return;
            }
            get
            {
                return coefficients[index];
            }
        }

        public Polynomial Add(Polynomial polynomial)
        {
            int maxPoryadok = this.Poryadok > polynomial.Poryadok ?
                this.Poryadok : polynomial.Poryadok;

            Polynomial result = new Polynomial(maxPoryadok);

            for (int i = 0; i <= this.Poryadok; i++)
            {
                result[i] = this[i];
            }

            for (int i = 0; i <= polynomial.Poryadok; i++)
            {
                result[i] += polynomial[i];
            }

            return result;
        }

        public Polynomial Subtract(Polynomial polynomial)
        {
            int maxPoryadok = this.Poryadok > polynomial.Poryadok ?
                 this.Poryadok : polynomial.Poryadok;

            Polynomial result = new Polynomial(maxPoryadok);

            for (int i = 0; i <= this.Poryadok; i++)
            {
                result[i] = this[i];
            }

            for (int i = 0; i <= polynomial.Poryadok; i++)
            {
                result[i] -= polynomial[i];
            }

            return result;
        }

        public Polynomial Multiply(Polynomial polynomial)
        {
            Polynomial result = new Polynomial(this.Poryadok + polynomial.Poryadok);
           
            for (int i = 0; i <= Poryadok; i++)
            { 
                for (int j = 0; j <= polynomial.Poryadok; j++)
                {
                    result[i + j] += this[i] * polynomial[j];
                }
            }

            return result;
        }

        public void Parse(string polynom)   
        {
            string[] monomials = polynom.Replace(" ",String.Empty).Split('+');

            Poryadok = monomials.Length - 1;
            coefficients = new double[Poryadok + 1];

            for (int i = 0; i <= Poryadok; i++)
            {
                if (!double.TryParse(monomials[i].Split('x')[0], out coefficients[i]))
                    throw new ArgumentException("Bad coefficient");
            }
        }

        public override string ToString()
        {
            string polynom = "" + this[0];

            for (int i = 1; i <= Poryadok; i++)
            {
                polynom += $" + {this[i]}x^{i}";
            }

            return polynom;
        }
    }
}
