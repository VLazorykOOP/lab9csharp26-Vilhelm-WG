public class Compare_row
{
    public static bool IsReverse(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;

        Stack<char> stack = new Stack<char>();

        foreach (char c in s1)
        {
            stack.Push(c);
        }

        foreach (char c in s2)
        {
            if (stack.Pop() != c)
            {
                return false;
            }
        }

        return true;
    }

    public static void RunTask1()
    {
        Console.WriteLine("=== Завдання 1: Перевірка на зворотні рядки ===");
        string string1 = "apple";
        string string2 = "elppa";

        if (IsReverse(string1, string2))
            Console.WriteLine($"Рядок '{string2}' є оберненим до '{string1}'.");
        else
            Console.WriteLine("Рядки не є зворотними.");
    }
}