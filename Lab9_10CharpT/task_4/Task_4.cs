using System.Collections;

public class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }

    public Song(string title, string artist)
    {
        Title = title;
        Artist = artist;
    }

    public override string ToString()
    {
        return $"\"{Title}\" - {Artist}";
    }
}

public class Task_4
{
    static Hashtable catalog = new Hashtable();

    public static void RunTask4()
    {
        Console.WriteLine("=== Завдання 4: Каталог Компакт-Дисків (Hashtable) ===\n");

        AddDisk("Rock Classics");
        AddSongToDisk("Rock Classics", new Song("Bohemian Rhapsody", "Queen"));
        AddSongToDisk("Rock Classics", new Song("Hotel California", "Eagles"));
        AddSongToDisk("Rock Classics", new Song("We Will Rock You", "Queen"));

        AddDisk("Pop Hits 2000s");
        AddSongToDisk("Pop Hits 2000s", new Song("Toxic", "Britney Spears"));
        AddSongToDisk("Pop Hits 2000s", new Song("Bye Bye Bye", "NSYNC"));

        ViewCatalog();
        SearchByArtist("Queen");

        Console.WriteLine("\n--- Видаляємо пісню 'Toxic' та диск 'Pop Hits 2000s' ---");
        RemoveSongFromDisk("Pop Hits 2000s", "Toxic");
        RemoveDisk("Pop Hits 2000s");

        ViewCatalog();
    }

    public static void AddDisk(string diskName)
    {
        if (!catalog.ContainsKey(diskName))
        {
            catalog.Add(diskName, new ArrayList());
            Console.WriteLine($"[+] Диск '{diskName}' успішно додано.");
        }
        else
        {
            Console.WriteLine($"[!] Диск '{diskName}' вже існує в каталозі.");
        }
    }

    public static void RemoveDisk(string diskName)
    {
        if (catalog.ContainsKey(diskName))
        {
            catalog.Remove(diskName);
            Console.WriteLine($"[-] Диск '{diskName}' повністю видалено.");
        }
        else
        {
            Console.WriteLine($"[!] Диск '{diskName}' не знайдено.");
        }
    }

    public static void AddSongToDisk(string diskName, Song song)
    {
        if (catalog.ContainsKey(diskName))
        {
            ArrayList songsList = (ArrayList)catalog[diskName];
            songsList.Add(song);
        }
        else
        {
            Console.WriteLine($"[!] Диск '{diskName}' не існує. Спочатку створіть його.");
        }
    }

    public static void RemoveSongFromDisk(string diskName, string songTitle)
    {
        if (catalog.ContainsKey(diskName))
        {
            ArrayList songsList = (ArrayList)catalog[diskName];
            Song songToRemove = null;

            foreach (Song s in songsList)
            {
                if (s.Title == songTitle)
                {
                    songToRemove = s;
                    break;
                }
            }

            if (songToRemove != null)
            {
                songsList.Remove(songToRemove);
                Console.WriteLine($"[-] Пісню '{songTitle}' видалено з диска '{diskName}'.");
            }
        }
    }

    public static void ViewCatalog()
    {
        Console.WriteLine("\n--- Вміст всього каталогу ---");
        if (catalog.Count == 0)
        {
            Console.WriteLine("Каталог порожній.");
            return;
        }

        foreach (DictionaryEntry entry in catalog)
        {
            string diskName = (string)entry.Key;
            Console.WriteLine($"Диск: [{diskName}]");
            ViewDiskContent(diskName);
        }
        Console.WriteLine("-----------------------------");
    }

    public static void ViewDiskContent(string diskName)
    {
        if (catalog.ContainsKey(diskName))
        {
            ArrayList songsList = (ArrayList)catalog[diskName];
            if (songsList.Count == 0)
            {
                Console.WriteLine("  (Диск порожній)");
            }
            else
            {
                foreach (Song s in songsList)
                {
                    Console.WriteLine($"  - {s.ToString()}");
                }
            }
        }
    }

    public static void SearchByArtist(string targetArtist)
    {
        Console.WriteLine($"\n--- Результати пошуку для виконавця: '{targetArtist}' ---");
        bool foundAny = false;

        foreach (DictionaryEntry entry in catalog)
        {
            string diskName = (string)entry.Key;
            ArrayList songsList = (ArrayList)entry.Value;

            foreach (Song s in songsList)
            {
                if (s.Artist.Equals(targetArtist, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Знайдено: \"{s.Title}\" (на диску [{diskName}])");
                    foundAny = true;
                }
            }
        }

        if (!foundAny)
        {
            Console.WriteLine("На жаль, записів цього виконавця не знайдено.");
        }
    }
}