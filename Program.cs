using System.Net.NetworkInformation;
using System.Numerics;
using Raylib_cs;

namespace Main;

internal static class Program
{
    const int screenWidth = 1400;
    const int screenHeight = 800;

    [System.STAThread]
    public static void Main()
    {
        Raylib.InitWindow(screenWidth, screenHeight, "Hello World");

        Player player = new Player(new Vector2(screenWidth / 2, screenHeight / 2));

        while (!Raylib.WindowShouldClose())
        {
            float delta = Raylib.GetFrameTime();
            Vector2 mousePos = Raylib.GetMousePosition();

            player.Update(mousePos, delta);

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            player.Draw();

            Raylib.EndDrawing();
        }
        
        player.Unload();

        Raylib.CloseWindow();
    }
}