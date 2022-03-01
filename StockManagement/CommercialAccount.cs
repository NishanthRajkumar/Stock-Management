namespace StockManagement;

/// <summary>
/// Commercial account system menu
/// </summary>
internal static class CommercialAccount
{
    /// <summary>
    /// Main menu of commercial account
    /// </summary>
    public static void MainMenu()
    {
        int option;
        do
        {
            Console.WriteLine("----------Commercial Account----------");
            Console.WriteLine("Menu Otions:");
            Console.WriteLine("1. View list of accounts");
            Console.WriteLine("2. Open an account file");
            Console.WriteLine("3. View List of company shares");
            Console.WriteLine("4. Exit");
            option = UserInput.GetPositiveInt("Enter Option: ");
            Console.Clear();
            switch (option)
            {
                case 1:
                    DisplayAllAccountFiles();
                    break;
                case 2:
                    OpenAccountFile();
                    break;
                case 3:
                    CompanyList.Display();
                    break;
                case 4:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid Option!!!");
                    break;
            }
            if (option == 4)
                break;
            Console.WriteLine("Press Any Key to Conitnue...");
            Console.ReadKey();
            Console.Clear();
        } while (option != 4);
    }

    /// <summary>
    /// Opens the account file.
    /// </summary>
    private static void OpenAccountFile()
    {
        string fileName = UserInput.GetName("Enter the name of account file to open: ");
        var files = Directory.GetFiles(Menu.PATH, "*.json").Select(Path.GetFileName).ToArray();
        if (files.Contains(fileName + ".json") is false)
        {
            Console.WriteLine("File does not exist");
            return;
        }
        StockAccountMenu(fileName);
    }

    /// <summary>
    /// Displays all account files.
    /// </summary>
    private static void DisplayAllAccountFiles()
    {
        Console.WriteLine("----------List of Account files----------");
        var files = Directory.GetFiles(Menu.PATH, "*.json").Select(Path.GetFileNameWithoutExtension).ToArray();
        foreach (var file in files)
            Console.WriteLine(file);
    }

    /// <summary>
    /// Opens the stock account menu
    /// </summary>
    /// <param name="name">The name.</param>
    private static void StockAccountMenu(string name)
    {
        int option;
        string symbol;
        int amount;
        StockAccount account = new(name);
        do
        {
            Console.WriteLine($"----------Stock Account [{name}]----------");
            Console.WriteLine("Menu Otions:");
            Console.WriteLine("1. Value of of account");
            Console.WriteLine("2. Buy shares");
            Console.WriteLine("3. Sell Shares");
            Console.WriteLine("4. Print report");
            Console.WriteLine("5. Exit");
            option = UserInput.GetPositiveInt("Enter Option: ");
            Console.Clear();
            switch (option)
            {
                case 1:
                    Console.WriteLine("Account Value: " + account.ValueOf());
                    break;
                case 2:
                    symbol = UserInput.GetName("Enter Symbol of stock to Buy: ");
                    amount = UserInput.GetPositiveInt("Enter amount of shares: ");
                    account.Buy(amount, symbol);
                    break;
                case 3:
                    symbol = UserInput.GetName("Enter Symbol of stock to Sell: ");
                    amount = UserInput.GetPositiveInt("Enter amount of shares: ");
                    account.Sell(amount, symbol);
                    break;
                case 4:
                    account.PrintReport();
                    break;
                case 5:
                    account.SaveToFile();
                    Console.WriteLine("Exiting.....");
                    break;
                default:
                    Console.WriteLine("Invalid Option!!!");
                    break;
            }
            if (option == 5)
                break;
            Console.WriteLine("Press Any Key to Conitnue...");
            Console.ReadKey();
            Console.Clear();
        } while (option != 5);
    }
}
