
public class BoxRow
{
    public Box[] row = new Box[Game.WORD_LENGTH];
    public bool currentRow = false;

    public BoxRow(int x, int y)
    {
        for (int i = 0; i < Game.WORD_LENGTH; i++)
        {
            row[i] = new Box(x + i * (Box.scl + Box.margin), y);
        }
    }



    public void Update()
    {
        for (int i = 0; i < Game.WORD_LENGTH; i++)
        {
            row[i].character = string.Empty;
        }
        for (int i = 0; i < KeyboardTextManager.Text.Length; i++)
        {
            row[i].character = KeyboardTextManager.Text[i].ToString();
        }

    }

    public void Draw()
    {
        foreach (var box in row)
        {
            box.Draw();
        }
    }

    public bool ValidateWord()
    {
        string inputWord = string.Empty;

        foreach (var box in row)
        {
            inputWord += box.character;
        }

        if (inputWord == WordHandler.CurrentWord)
        {
            Game.OnCorrectGuess();
            return false;
        }

        if (inputWord.Length < Game.WORD_LENGTH)
        {
            Console.WriteLine("För kort");
            return false;
        }

        if (!WordHandler.wordlist.Contains(inputWord))
        {
            Console.WriteLine("Finns inte i ordlistan");
            return false;
        }



        for (int i = 0; i < row.Length; i++)
        {
            Game.unguessedLetters = Game.unguessedLetters.Replace(row[i].character, "");

            if (row[i].character == WordHandler.CurrentWord[i].ToString())
            {
                row[i].c = Color.GREEN;
            }
            else if (WordHandler.CurrentWord.Contains(row[i].character))
            {
                row[i].c = Color.YELLOW;
            }
            else
            {
                row[i].c = Color.GRAY;
            }
        }

        return true;
    }

    public void Reset()
    {
        foreach (var box in row)
        {
            box.Reset();
        }
    }
}