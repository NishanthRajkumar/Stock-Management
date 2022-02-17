namespace StockManagement;

internal class StockPortfolio
{
    private readonly Dictionary<string, Stock> stocks;

    public double TotalValue
    {
        get { return ComputeTotalValue(); }
    }

    public StockPortfolio()
    {
        stocks = new();
    }

    public void AddStock()
    {
        string name = UserInput.GetName("\nEnter name of stock to add: ");
        if (stocks.ContainsKey(name))
        {
            Console.WriteLine("Stock already exists in your portfolio.");
            stocks[name].AddShares(UserInput.GetPositiveInt("Enter no of shares to add: "));
        }
        else
        {
            int noOfShares = UserInput.GetPositiveInt("Enter no of share: ");
            double sharePrice = UserInput.GetPostiveValue("Enter Share price: ");
            stocks.Add(name, new Stock(name, noOfShares, sharePrice));
        }
        Console.WriteLine("Added Successfully!");
    }

    public void AddMultipleStocks()
    {
        int noOfStock = UserInput.GetPositiveInt("\nEnter no of stocks to add: ");
        for (int i = 0; i < noOfStock; i++)
            AddStock();
    }

    public void DisplayStock()
    {
        string name = UserInput.GetName("Enter name of stock to display: ");
        if (stocks.ContainsKey(name))
            stocks[name].Display();
        else
            Console.WriteLine("Stock does not exist in your portfolio!");
    }

    public void PortfolioReport()
    {
        foreach (Stock stock in stocks.Values)
            stock.Display();
    }

    private double ComputeTotalValue()
    {
        double totalStockValue = 0;
        foreach (Stock stock in stocks.Values)
            totalStockValue += stock.StockValue;
        return totalStockValue;
    }

    public double ValueOf()
    {
        return TotalValue;
    }

    private void Save()
    {
        throw new NotImplementedException();
    }

    private void Sell()
    {
        throw new NotImplementedException();
    }

    private void Buy()
    {
        throw new NotImplementedException();
    }
}