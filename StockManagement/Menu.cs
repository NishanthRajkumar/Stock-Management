namespace StockManagement;

/// <summary>
/// This class is the entry point of the stock management app
/// </summary>
public static class Menu
{
    // Path where the account files are stored
    public const string PATH = @"C:\Users\Nishanth\Desktop\codingclub\RFP\Assignments\StockManagement\StockManagement\Accounts\";

    /// <summary>
    /// Main menu of the Stock management system
    /// </summary>
    public static void MainMenu()
    {
        int option;
        do
        {
            Console.WriteLine("----------Stock Management System----------");
            Console.WriteLine("Menu Otions:");
            Console.WriteLine("1. Commercial Account");
            Console.WriteLine("2. New Personal Account");
            Console.WriteLine("3. Existing Personal Account");
            Console.WriteLine("4. Exit");
            option = UserInput.GetPositiveInt("Enter Option: ");
            Console.Clear();
            switch (option)
            {
                case 1:
                    CommercialAccount.MainMenu();
                    break;
                case 2:
                    NewPersonal();
                    break;
                case 3:
                    ExistingPersonal();
                    break;
                case 4:
                    CompanyList.SaveFile();
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
    /// Opens an existing account file
    /// </summary>
    private static void ExistingPersonal()
    {
        string name = UserInput.GetName("Enter Name of account: ");
        if (File.Exists(PATH + name + ".json"))
            PersonalAccount.MainMenu(name);
        else
            Console.WriteLine("Account does not exist");
    }

    /// <summary>
    /// Creates new personal account file.
    /// </summary>
    private static void NewPersonal()
    {
        string name;
        while (true)
        {
            name = UserInput.GetName("Enter Name of account to create: ");
            if (File.Exists(PATH + name + ".json"))
                Console.WriteLine("Account Name already exists");
            else
                break;
        }
        StockPortfolio newAccount = new(name);
        newAccount.SaveToFile();
        PersonalAccount.MainMenu(name);
    }
}
