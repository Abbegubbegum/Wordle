
public static class Game
{
    public const int WIDTH = 600;
    public const int HEIGHT = 800;
    public static int WORD_LENGTH = 5;

    public static Font font = Raylib.GetFontDefault();

    public static List<BoxRow> rows = new List<BoxRow>();

    public static string unguessedLetters = "abcdefghijklmnopqrstuvwxyz";

    public static int currentRow = 0;

    private static string playerInput = "";

    public static void Initialize()
    {
        Console.WriteLine("Word Count?");
        playerInput = Console.ReadLine();

        while (!int.TryParse(playerInput, out WORD_LENGTH) || WORD_LENGTH <= 2)
        {
            Console.WriteLine("Invalid Input, try again");
            playerInput = Console.ReadLine();
        }

        Raylib.InitWindow(WIDTH, HEIGHT, "Wordle");
        WordHandler.FetchNewWord();
        KeyboardTextManager.StartListening();

        for (int i = 0; i < 7; i++)
        {
            rows.Add(new BoxRow(50 + i * (Box.scl + Box.margin * 2)));
        }


    }

    public static void Run()
    {
        while (!Raylib.WindowShouldClose())
        {
            //LOGIC
            if (currentRow >= rows.Count)
                OnFail();
            KeyboardTextManager.Update();
            rows[currentRow].Update();

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                if (rows[currentRow].ValidateWord())
                {
                    KeyboardTextManager.ResetText();
                    currentRow++;
                }
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
            {
                OnFail();
            }


            //RENDER
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);
            foreach (var row in rows)
            {
                row.Draw();
            }

            Raylib.DrawTextRec(Raylib.GetFontDefault(), unguessedLetters, new Rectangle(100, 50 + 7 * (Box.scl + Box.margin * 2), 4 * (Box.scl + Box.margin) + Box.scl, Box.scl * 2), 40, 10, true, Color.BLACK);

            Raylib.EndDrawing();
        }
    }

    private static void OnFail()
    {
        Console.WriteLine($"FAIL! The word was {WordHandler.CurrentWord}");
        Reset();
    }

    public static void OnCorrectGuess()
    {
        Console.WriteLine($"Correct Guess! The word was {WordHandler.CurrentWord}");
        Reset();
    }

    private static void Reset()
    {
        WordHandler.FetchNewWord();
        KeyboardTextManager.ResetText();
        currentRow = 0;
        unguessedLetters = "abcdefghijklmnopqrstuvwxyz";
        foreach (var row in rows)
        {
            row.Reset();
        }
    }
}