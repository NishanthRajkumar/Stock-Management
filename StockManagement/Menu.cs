namespace StockManagement;

internal static class Menu
{
    public static void List()
    {
        int option;
        StockPortfolio myPortfolio = new StockPortfolio();
        do
        {
            Console.WriteLine("----------Stock Portfolio----------");
            Console.WriteLine("Menu Otions:");
            Console.WriteLine("1. Add Stock");
            Console.WriteLine("2. Add Multiple stocks");
            Console.WriteLine("3. Get total Stock value");
            Console.WriteLine("4. Display a stock");
            Console.WriteLine("5. Display all stocks");
            Console.WriteLine("6. Exit");
            option = UserInput.GetPositiveInt("Enter Option: ");
            Console.Clear();
            switch (option)
            {
                case 1:
                    myPortfolio.AddStock();
                    break;
                case 2:
                    myPortfolio.AddMultipleStocks();
                    break;
                case 3:
                    Console.WriteLine("Total Value of portflolio: " + myPortfolio.TotalValue);
                    break;
                case 4:
                    myPortfolio.DisplayStock();
                    break;
                case 5:
                    myPortfolio.PortfolioReport();
                    break;
                case 6:
                    Console.WriteLine();
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
