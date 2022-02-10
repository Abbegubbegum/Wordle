
public static class WordHandler
{
    private const string path = @"dictionary.txt";
    public static List<string> wordlist;
    private static Random r = new();

    public static string CurrentWord { get; private set; } = "";


    public static bool LoadFile()
    {
        try
        {
            wordlist = File.ReadAllLines(path).ToList();
        }
        catch
        {
            Console.WriteLine($"No dictionary file found, there needs to be a dictionary file named {path} in your directory");
            return false;
        }

        return true;
        // Console.WriteLine(CurrentWord);
    }

    public static void FetchNewWord()
    {
        if (wordlist.Count == 0)
        {
            Console.WriteLine("Word List is empty");
            Raylib.CloseWindow();
            return;
        }

        wordlist.Remove(CurrentWord);
        CurrentWord = wordlist[r.Next(wordlist.Count)];

        while (CurrentWord.Length != Game.WORD_LENGTH)
        {
            wordlist.Remove(CurrentWord);
            CurrentWord = wordlist[r.Next(wordlist.Count)];
        }
    }
}
