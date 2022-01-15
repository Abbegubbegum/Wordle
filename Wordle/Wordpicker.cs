
public static class Wordpicker
{
    private const string path = @"Dictionary.txt";
    private static new List<string> wordlist;
    private static Random r = new Random();

    public static string CurrentWord { get; private set; } = "";


    public static void Initialize()
    {
        wordlist = File.ReadAllLines(path).ToList();
        FetchNewWord();
    }

    public static void FetchNewWord()
    {
        int index = r.Next(wordlist.Count);
        CurrentWord = wordlist[index];
        wordlist.RemoveAt(index);
    }
}
