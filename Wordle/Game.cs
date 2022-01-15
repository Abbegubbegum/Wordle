
public static class Game
{
    public const int WIDTH = 600;
    public const int HEIGHT = 800;

    public static void Initialize()
    {
        Raylib.InitWindow(WIDTH, HEIGHT, "Worlde");
        Wordpicker.Initialize();
    }

    public static void Run()
    {
        while (!Raylib.WindowShouldClose())
        {
            //LOGIC



            Renderer.RenderFrame();
        }
    }
}