using System;

namespace LB
{
    class MoneyPrinter
    {
        public String print(String operation, String currency, int amount) {
            if (operation.Equals("add"))
                operation = "добавлено";
            else
                operation = "извлечено";
            return "Было " + operation + ": " + amount + " " + currency;
        }
    }
}
