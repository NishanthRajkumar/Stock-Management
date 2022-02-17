namespace StockManagement;

internal class Stock
{
    // Stock information Attributes declared
    private readonly string stockName;
    private int noOfShares;
    private readonly double sharePrice;
    private double stockValue;

    public double StockValue
    {
        get { return stockValue; }
    }
    public string Name
    {
        get { return stockName; }
    }

    public Stock(string stockName, int noOfShares, double sharePrice)
    {
        this.stockName = stockName;
        this.noOfShares = noOfShares;
        this.sharePrice = sharePrice;
        UpdateStockValue();
    }

    public void UpdateStockValue()
    {
        stockValue = noOfShares * sharePrice;
    }

    public void AddShares(int noOfShares)
    {
        this.noOfShares += noOfShares;
        UpdateStockValue();
    }

    public void Display()
    {
        Console.WriteLine("\nStock Name: " + stockName);
        Console.WriteLine("No of Shares: " + noOfShares);
        Console.WriteLine("Share Price: " + sharePrice);
        Console.WriteLine("Stock Value: " + stockValue);
    }
}