namespace StockManagement;

/// <summary>
/// This class is used for input checks when entering contact info
/// </summary>
internal static class UserInput
{
    /// <summary>
    /// Reads the string.
    /// <para>To avoid null reference assignment warning</para>
    /// </summary>
    /// <returns>returns string</returns>
    public static string ReadString()
    {
        string input = Console.ReadLine();
        if (String.IsNullOrEmpty(input))
            return "";
        return input;
    }

    /// <summary>
    /// Gets a name.
    /// <para>Ensures the input is non-null string</para>
    /// </summary>
    /// <returns>The name entered by user</returns>
    public static string GetName(string message)
    {
        string input;
        do
        {
            Console.Write(message);
            input = ReadString();
        } while (input == null);
        return input;
    }

    /// <summary>
    /// Gets the positive int.
    /// <para>Ensures user input is positve integer</para>
    /// </summary>
    /// <returns>An integer >= 0</returns>
    public static int GetPositiveInt(string message)
    {
        int n;
        bool IS_INT32;
        do
        {
            do
            {
                Console.Write(message);
                IS_INT32 = Int32.TryParse(ReadString(), out n);
            } while (IS_INT32 is false);
        } while (n < 0);
        return n;
    }

    /// <summary>
    /// Ensures user inputs a postive double value.
    /// </summary>
    /// <returns>A positive double type value</returns>
    public static double GetPostiveValue(string message)
    {
        double value;
        bool IS_DOUBLE;
        do
        {
            do
            {
                Console.Write(message);
                IS_DOUBLE = Double.TryParse(ReadString(), out value);
            } while (IS_DOUBLE is false);
        } while (value < 0);
        return value;
    }
}