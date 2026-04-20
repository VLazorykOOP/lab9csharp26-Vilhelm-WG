using System.Collections;

public class CompareRowArrayList
{
    public static void RunTask_3Row()
    {
        string filePath = "t.txt";

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Перший рядок\nДругий рядок\nТретій рядок");
        }

        Console.WriteLine("=== Завдання 3: Зворотні рядки (ArrayList) ===\n");
        
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            ArrayList charList = new ArrayList(line.ToCharArray());
            charList.Reverse();

            foreach (char c in charList)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }
    }
}