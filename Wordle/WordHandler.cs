
public static class WordHandler
{
    private const string path = @"dictionary.txt";
    public static List<string> wordlist;
    private static Random r = new Random();

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
        wordlist.Remove(CurrentWord);
        CurrentWord = string.Empty;
        while (CurrentWord.Length != 5)
        {
            CurrentWord = wordlist[r.Next(wordlist.Count)];
        }
    }
}
