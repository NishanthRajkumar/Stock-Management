using System.Text.Json;

namespace StockManagement;

/// <summary>
/// Encapsulates the stock portfolio of a personal account
/// </summary>
public class StockPortfolio
{
    public string AccountName { get; set; }
    public Dictionary<string, Stock> Stocks { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StockPortfolio"/> class.
    /// <para>Default Constructor</para>
    /// </summary>
    public StockPortfolio()
    {
        Stocks = new();
        AccountName = "";
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StockPortfolio"/> class.
    /// <para>Initializes with name of account</para>
    /// </summary>
    public StockPortfolio(string name)
    {
        Stocks = new();
        AccountName = name;
    }

    /// <summary>
    /// Buys a stock.
    /// </summary>
    public void Buy()
    {
        string Symbol = UserInput.GetName("Enter Symbol of stock to Buy: ");
        int amount = UserInput.GetPositiveInt("Enter amount of shares: ");
        AddShares(amount, Symbol);
    }

    /// <summary>
    /// Sells this instance.
    /// </summary>
    public void Sell()
    {
        string Symbol = UserInput.GetName("Enter Symbol of stock to Sell: ");
        int amount = UserInput.GetPositiveInt("Enter amount of shares: ");
        RemoveShares(amount, Symbol);
    }

    /// <summary>
    /// Displays the stock.
    /// </summary>
    public void DisplayStock()
    {
        string name = UserInput.GetName("Enter symbol of stock to display: ");
        if (Stocks.ContainsKey(name))
            Stocks[name].Display();
        else
            Console.WriteLine("Stock does not exist in your portfolio!");
    }

    /// <summary>
    /// Displays the complete report of the portfolio
    /// </summary>
    public void PortfolioReport()
    {
        Console.WriteLine("----------Portfolio Report----------");
        foreach (Stock stock in Stocks.Values)
            stock.Display();
    }

    /// <summary>
    /// Total value of the portfolio.
    /// </summary>
    /// <returns></returns>
    public double ValueOfPortfolio()
    {
        double totalStockValue = 0;
        foreach (Stock stock in Stocks.Values)
            totalStockValue += stock.StockValue;
        return totalStockValue;
    }

    /// <summary>
    /// Saves the protfollio to account file.
    /// </summary>
    public void SaveToFile()
    {
        var option = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize<StockPortfolio>(this, option);
        File.WriteAllText(Menu.PATH + AccountName + ".json", jsonString);
    }

    /// <summary>
    /// Adds the shares to the portfolio
    /// </summary>
    public void AddShares(int amount, string Symbol)
    {
        if (CompanyList.companyList.ContainsKey(Symbol) is false)
        {
            Console.WriteLine("Symbol Does not exist!");
            return;
        }
        if (amount > CompanyList.companyList[Symbol].NoOfShares)
        {
            Console.WriteLine("Amount exceeds the company share count!\n Failed To buy");
            return;
        }
        CompanyList.companyList[Symbol].NoOfShares -= amount;
        if (Stocks.ContainsKey(Symbol))
            Stocks[Symbol].NoOfShares += amount;
        else
        {
            Stock stock = new()
            {
                NoOfShares = amount,
                StockSymbol = Symbol,
                StockName = CompanyList.companyList[Symbol].Name
            };
            Stocks.Add(Symbol, stock);
        }
        Console.WriteLine("Bought Successfully!");
    }

    /// <summary>
    /// Removes the shares from the portfolio
    /// </summary>
    public void RemoveShares(int amount, string Symbol)
    {
        if (CompanyList.companyList.ContainsKey(Symbol) is false)
        {
            Console.WriteLine("Symbol Does not exist!");
            return;
        }
        if (Stocks.ContainsKey(Symbol))
        {
            if (amount > Stocks[Symbol].NoOfShares)
            {
                Console.WriteLine("Amount exceeds the share count in portfolio!\n Failed To Sell");
                return;
            }
            Stocks[Symbol].NoOfShares -= amount;
            Console.WriteLine("Sold Successfully!");
            CompanyList.companyList[Symbol].NoOfShares += amount;
        }
        else
            Console.WriteLine("This portfolio does not have the stock to sell!");
    }
}

/// <summary>
/// Encapsulates the details of a stock
/// </summary>
public class Stock
{
    // Properties
    public string StockName { get; set; }
    public string StockSymbol { get; set; }
    public int NoOfShares { get; set; }
    public double SharePrice
    {
        get { return CompanyList.companyList[StockSymbol].SharePrice; }
    }
    public double StockValue
    {
        get { return NoOfShares * SharePrice; }
    }

    /// <summary>
    /// Displays the stock details
    /// </summary>
    public void Display()
    {
        Console.WriteLine("\nStock Name: " + StockName);
        Console.WriteLine("Stock Symbol: " + StockSymbol);
        Console.WriteLine("No of Shares: " + NoOfShares);
        Console.WriteLine("Share Price: " + SharePrice);
        Console.WriteLine("Stock Value: " + StockValue);
    }
}