using System;
using System.Collections.Generic;

namespace LB
{
    public class Wallet
    {
        private Dictionary<string, int> account = new Dictionary<string, int>();
        private Bank Bank;
        private MoneyPrinter printer = new MoneyPrinter();

        public Wallet()
        {
            this.Bank = new Bank();
        }

        public Wallet(Dictionary<string, int> account)
        {
            this.account = account;
            this.Bank = new Bank();
        }
        public Wallet(Dictionary<string, int> account, Dictionary<string, double>? price)
        {
            this.account = account;
            if (price != null)
                this.Bank = new Bank(price);
            else
                this.Bank = new Bank();
        }

        public Dictionary<string, int> getAccount() {
            return account;
        }

        public void addMonney(string title, int price)
        {
            if (!account.ContainsKey(title))
                account.Add(title, price);
            else
            {
                int a = account[title];
                account[title] = a + price;
            }
        }

        public void removeMoney(string title, int price)
        {
            if (account.ContainsKey(title))
            {
                int a = account[title];
                if (a >= price) {
                    account[title] = a - price;
                    if (account[title] == 0)
                        account.Remove(title);
                    }
                else
                    throw new Exception("Операция не возможна");                
            }
            else
                throw new Exception("В кошельке нет указанной валюты");
        }

        public int getMoney(string title)
        {
            if (account.ContainsKey(title))
            {
                return account[title];
            }
            else
                return 0;
        }

        public int Count()
        {
            return account.Keys.Count;
        }

        public String price()
        {
            string temp = "{ ";
            foreach (KeyValuePair<string, int> el in account)
            {
                temp += el.Value + " " + el.Key + ", ";
            }
            if (temp.Length > 2) {
                temp = temp.Substring(0, temp.Length - 2);
                temp += " }";
            }
            else
                temp += "}"; 
            return temp;
        }

        public double getTotalMoney(string title)
        {
            return converting(title, null);
        }
        public double getTotalMoney(string title, double coef)
        {
            return converting(title, coef);
        }
        private double converting(string title, double? coef) {
            double temp = 0;
            foreach (var account in getAccount())
            {
                if (account.Key != title)
                {
                    temp += Bank.Convert(account.Value, account.Key, title, coef);
                }
                else
                    temp += account.Value;
            }
            return temp;
        }

        public string print( string operation, string title, int price) {
            return printer.print(operation, title, price);
        }
    }
}
