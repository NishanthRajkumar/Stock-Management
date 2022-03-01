using System.Text.Json;

namespace StockManagement;

/// <summary>
/// Handles the list of company shares
/// </summary>
public static class CompanyList
{
    // Path where the list of company shares file is stored
    const string PATH = @"C:\Users\Nishanth\Desktop\codingclub\RFP\Assignments\StockManagement\StockManagement\CompanySharesList.json";

    public static Dictionary<string, Company> companyList;

    /// <summary>
    /// Initializes the <see cref="CompanyList"/> class.
    /// <para>Reads from file the latest details stored</para>
    /// </summary>
    static CompanyList()
    {
        GetFile();
    }

    /// <summary>
    /// Gets the file details
    /// </summary>
    public static void GetFile()
    {
        string list = File.ReadAllText(PATH);
        companyList = JsonSerializer.Deserialize<Dictionary<string, Company>>(list);
    }

    /// <summary>
    /// Saves the details to file.
    /// </summary>
    public static void SaveFile()
    {
        var option = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize<Dictionary<string, Company>>(companyList, option);
        File.WriteAllText(PATH, jsonString);
    }

    /// <summary>
    /// Displays the list of company shares
    /// </summary>
    public static void Display()
    {
        Console.WriteLine("List of Companies: ");
        foreach (var company in companyList)
            company.Value.Display();
    }
}

/// <summary>
/// Encapsulates the details of a company
/// </summary>
public class Company
{
    public string Name { get; set; }
    public string Symbol { get; set; }
    public double NoOfShares { get; set; }
    public double SharePrice { get; set; }

    /// <summary>
    /// Displays the company details
    /// </summary>
    public void Display()
    {
        Console.WriteLine("\nName: " + Name);
        Console.WriteLine("Symbol: " + Symbol);
        Console.WriteLine("No of shares: " + NoOfShares);
        Console.WriteLine("Share price: " + SharePrice);
    }
}