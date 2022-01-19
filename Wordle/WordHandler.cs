
public static class WordHandler
{
    private const string path = @"engelska-ord.txt";
    public static List<string> wordlist;
    private static Random r = new Random();

    public static string CurrentWord { get; private set; } = "";


    public static void Initialize()
    {
        wordlist = File.ReadAllLines(path).ToList();
        FetchNewWord();
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
