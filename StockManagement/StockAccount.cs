using System.Text.Json;

namespace StockManagement;

/// <summary>
/// This class is primarily used by financial institutes to manage customer accounts
/// </summary>
public class StockAccount
{
    public string fileName;
    public StockPortfolio portfolio;

    /// <summary>
    /// Initializes a new instance of the <see cref="StockAccount"/> class.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    public StockAccount(string fileName)
    {
        this.fileName = fileName;
        string accountDetails = File.ReadAllText(StockManagement.Menu.PATH + fileName + ".json");
        portfolio = JsonSerializer.Deserialize<StockPortfolio>(accountDetails);
    }

    /// <summary>
    /// Value of the account
    /// </summary>
    /// <returns></returns>
    public double ValueOf()
    {
        return portfolio.ValueOfPortfolio();
    }

    /// <summary>
    /// Buys the specified amount of shares of a stock
    /// </summary>
    /// <param name="amount">The amount of shares</param>
    /// <param name="Symbol">The symbol of the stock</param>
    public void Buy(int amount, string Symbol)
    {
        portfolio.AddShares(amount, Symbol);
    }

    /// <summary>
    /// Sells the specified amount of shares of a stock
    /// </summary>
    /// <param name="amount">The amount of shares</param>
    /// <param name="Symbol">The symbol of the stock</param>
    public void Sell(int amount, string Symbol)
    {
        portfolio.RemoveShares(amount, Symbol);
    }

    /// <summary>
    /// Saves to file.
    /// </summary>
    public void SaveToFile()
    {
        portfolio.SaveToFile();
    }

    /// <summary>
    /// Prints the report of the account
    /// </summary>
    public void PrintReport()
    {
        portfolio.PortfolioReport();
    }
}
