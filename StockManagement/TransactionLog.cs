using MyDataStructureLibrary;

namespace StockManagement;

public static class TransactionLog
{
    private static string path = @"C:\Users\Nishanth\Desktop\codingclub\RFP\Assignments\StockManagement\StockManagement\Transactions.txt";
    private static QueueList<string> log;

    static TransactionLog()
    {
        log = new QueueList<string>();
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
                log.Enqueue(line);
        }
    }

    public static void EnterLog(string message)
    {
        log.Enqueue($"{DateTime.Now}: " + message);
    }

    public static void Display()
    {
        log.Display();
    }

    public static void SaveToFile()
    {
        string[] lines = new string[log.Size()];
        for (int i = 0; i < lines.Length; i++)
            lines[i] = log.Dequeue();
        File.WriteAllLines(path, lines);
    }
}
