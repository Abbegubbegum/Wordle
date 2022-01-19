
public static class KeyboardTextManager
{
    public static string Text { get; private set; } = "";
    private static bool listening = false;

    private static int currentUnicodeKey = 0;
    private static char currentKey;

    public static void Update()
    {
        if (listening)
        {
            currentUnicodeKey = Raylib.GetKeyPressed();

            if (currentUnicodeKey != 0 && currentUnicodeKey != 257 && currentUnicodeKey != 258 && currentUnicodeKey != 259 && Text.Length < Game.WORD_LENGTH)
            {
                // Console.WriteLine(currentUnicodeKey);
                currentKey = Convert.ToChar(currentUnicodeKey);
                Text += currentKey;
                Text = Text.ToLower();
                // Text = currentUnicodeKey.ToString();
            }
            else if (currentUnicodeKey == 259)
            {
                try
                {
                    Text = Text.Remove(Text.Length - 1);
                }
                catch
                {

                }
            }
        }
    }

    public static void StartListening()
    {
        listening = true;
    }

    public static void StopListening()
    {
        listening = false;
    }

    public static void ResetText()
    {
        Text = "";
    }
}
