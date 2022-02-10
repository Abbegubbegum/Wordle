
public class Box
{
    public const int scl = 70;
    public const int margin = 10;
    public Rectangle rec = new Rectangle(0, 0, 70, 70);
    public Color c = Color.BLANK;

    public string character = "";
    private const int textMarginX = 20;
    private const int textMarginY = 15;


    public Box(int x, int y)
    {
        rec.x = x;
        rec.y = y;
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(rec, c);
        Raylib.DrawRectangleLinesEx(rec, 2, Color.BLACK);

        Raylib.DrawText(character.ToUpper(), (int)(rec.x + textMarginX), (int)(rec.y + textMarginY), 50, Color.BLACK);
    }

    public void Reset()
    {
        character = "";
        c = Color.BLANK;
    }
}
