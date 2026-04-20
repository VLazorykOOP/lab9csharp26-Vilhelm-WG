public class TextFile
{
    public static void RunTask_2()
    {
        string filePath = "text.txt";

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Акула собака екран телефон ідея кіт університет машина");
        }

        HashSet<char> vowels = new HashSet<char>("аеєиіїоуюяАЕЄИІЇОУЮЯaeiouyAEIOUY");

        Queue<string> vowelQueue = new Queue<string>();
        Queue<string> consonantQueue = new Queue<string>();

        string text = File.ReadAllText(filePath);
        char[] separators = new char[] { ' ', '\n', '\r', '\t', ',', '.', '!', '?' };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            char firstLetter = word[0];

            if (char.IsLetter(firstLetter))
            {
                if (vowels.Contains(firstLetter))
                {
                    vowelQueue.Enqueue(word);
                }
                else
                {
                    consonantQueue.Enqueue(word);
                }
            }
        }

        Console.WriteLine("=== Слова на голосну літеру (Queue) ===");
        while (vowelQueue.Count > 0)
        {
            Console.WriteLine(vowelQueue.Dequeue());
        }

        Console.WriteLine("\n=== Слова на приголосну літеру (Queue) ===");
        while (consonantQueue.Count > 0)
        {
            Console.WriteLine(consonantQueue.Dequeue());
        }
    }
}