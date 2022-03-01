using System.Text.Json;

namespace StockManagement;

/// <summary>
/// Personal account system menu
/// </summary>
internal static class PersonalAccount
{
    /// <summary>
    /// Main menu of the personal account page
    /// </summary>
    /// <param name="name">The name of the account file</param>
    public static void MainMenu(string name)
    {
        int option;
        string accounDetails = File.ReadAllText(Menu.PATH + name + ".json");
        var options = new JsonSerializerOptions { WriteIndented = true };
        StockPortfolio myPortfolio = JsonSerializer.Deserialize<StockPortfolio>(accounDetails, options);
        do
        {
            Console.WriteLine($"----------Personal Account [{name}]----------");
            Console.WriteLine("Menu Otions:");
            Console.WriteLine("1. Buy a Stock");
            Console.WriteLine("2. Sell a Stock");
            Console.WriteLine("3. Get total Stock value");
            Console.WriteLine("4. Display a stock of yours");
            Console.WriteLine("5. Display all your stocks");
            Console.WriteLine("6. Exit");
            option = UserInput.GetPositiveInt("Enter Option: ");
            Console.Clear();
            switch (option)
            {
                case 1:
                    myPortfolio.Buy();
                    break;
                case 2:
                    myPortfolio.Sell();
                    break;
                case 3:
                    Console.WriteLine("Total Value of portflolio: " + myPortfolio.ValueOfPortfolio());
                    break;
                case 4:
                    myPortfolio.DisplayStock();
                    break;
                case 5:
                    myPortfolio.PortfolioReport();
                    break;
                case 6:
                    myPortfolio.SaveToFile();
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid Option!!!");
                    break;
            }
            if (option == 6)
                break;
            Console.WriteLine("Press Any Key to Conitnue...");
            Console.ReadKey();
            Console.Clear();
        } while (option != 6);
    }
}
