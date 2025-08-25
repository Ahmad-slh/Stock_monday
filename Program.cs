using System;
public delegate void PriceChangeHandler(string symbol, decimal newPrice);

public class mystock
{
    public string Symbol { get; private set; }
    private decimal price;
    public event PriceChangeHandler? PriceChanged;

    public decimal Price
    {
        get { return price; }
        set
        {
            if (price != value)
            {
                price = value;
            
                Console.WriteLine($"Price of {Symbol} changed to {price}");
                PriceChanged?.Invoke(Symbol, price);
            }
        }
    }

    public mystock(string symbol, decimal initPrice)
    {
        Symbol = symbol;
        Price = initPrice;
    }
}

public class EmailNotifier
{
    public void OnPriceChanged(string symbol, decimal newPrice)
    {
        Console.WriteLine($"Email Alert: Stock {symbol} new price is {newPrice}");
    }
}

public class SMSNotifier
{
    public void OnPriceChanged(string symbol, decimal newPrice)
    {
        Console.WriteLine($"SMS Alert: Stock {symbol} new price is {newPrice}");
    }
}

public class Logger
{
    public void OnPriceChanged(string symbol, decimal newPrice)
    {
        Console.WriteLine($"Log: Stock {symbol} updated to {newPrice}");
    }
}

class program
{
    public static void Main()
    {
        mystock mstf = new mystock("MSFT", 100);
        EmailNotifier email = new EmailNotifier();
        SMSNotifier sms = new SMSNotifier();
        Logger logger = new Logger();

        mstf.PriceChanged += email.OnPriceChanged;
        mstf.PriceChanged += sms.OnPriceChanged;
        mstf.PriceChanged += logger.OnPriceChanged;

        mstf.Price = 105;
    }
}
