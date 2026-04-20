using System.Collections;

public class TextFileArrayList
{
    public static void RunTask2TextFile()
    {
        string filePath = "text.txt";

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Акула собака екран телефон ідея кіт університет машина");
        }

        Console.WriteLine("=== Завдання 4: Голосні та Приголосні (ArrayList) ===\n");

        string text = File.ReadAllText(filePath);
        char[] separators = new char[] { ' ', '\n', '\r', '\t', ',', '.', '!', '?' };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        string vowels = "аеєиіїоуюяАЕЄИІЇОУЮЯaeiouyAEIOUY";

        ArrayList vowelWords = new ArrayList();
        ArrayList consonantWords = new ArrayList();

        foreach (string word in words)
        {
            char firstLetter = word[0];

            if (char.IsLetter(firstLetter))
            {
                if (vowels.Contains(firstLetter))
                {
                    vowelWords.Add(word);
                }
                else
                {
                    consonantWords.Add(word);
                }
            }
        }

        Console.WriteLine("--- Слова на голосну ---");
        foreach (object word in vowelWords) 
        {
            Console.WriteLine(word.ToString());
        }

        Console.WriteLine("\n--- Слова на приголосну ---");
        foreach (object word in consonantWords)
        {
            Console.WriteLine(word.ToString());
        }
    }
}