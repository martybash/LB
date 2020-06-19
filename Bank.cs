using System;
using System.Collections.Generic;

namespace LB
{
    class Bank
    {
        Random rnd = new Random();
        private Dictionary<string, double> price = new Dictionary<string, double>();

        public Bank()
        {
            price.Add("EUR", 70.6);
            price.Add("RUB", 1.1);
            price.Add("USD", 60.9);
        }
        public Bank(Dictionary<string, double> price)
        {
            this.price = price;
        }


        public double Convert(int price, string title, string titleRes, double? course) 
        {
            if (course == null)
                course = rnd.Next(0, 40);
            if (course < 20)
                course *= -1;
            course /= 200;


            if (this.price.ContainsKey(title) && this.price.ContainsKey(titleRes)) 
            {
                return Math.Round(this.price[title] * price / 
                    (this.price[titleRes] + this.price[titleRes] * (double)course), 4);
            }
            else
            {
                throw new Exception("В банке нет указанной валюты");
            }
        }
    }
}
