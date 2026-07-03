using System.Net.NetworkInformation;
using System.Numerics;
using Raylib_cs;

namespace Main;

internal static class Program
{
    const int screenWidth = 1400;
    const int screenHeight = 800;

    const int GL_ONE_MINUS_DST_COLOR = 0x0307;
    const int GL_ONE_MINUS_SRC_ALPHA = 0x0303;
    const int GL_FUNC_ADD = 0x8006;

    [System.STAThread]
    public static void Main()
    {
        Raylib.InitWindow(screenWidth, screenHeight, "Hello World");

        Player player = new Player(new Vector2(screenWidth / 2, screenHeight / 2));

        Raylib.HideCursor();
        Sprite crosshair = new Sprite("Resources/crosshair.png", new Vector2(0, 0), 1);

        while (!Raylib.WindowShouldClose())
        {
            float delta = Raylib.GetFrameTime();
            Vector2 mousePos = Raylib.GetMousePosition();

            crosshair.position = mousePos;

            player.Update(mousePos, delta);

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            Raylib.DrawCircle(100, 100, 50, Color.Red);

            player.Draw();

            Rlgl.SetBlendFactors(GL_ONE_MINUS_DST_COLOR, GL_ONE_MINUS_SRC_ALPHA, GL_FUNC_ADD);
            Raylib.BeginBlendMode(BlendMode.Custom);
            crosshair.Draw();
            Raylib.EndBlendMode();

            Raylib.EndDrawing();
        }
        
        player.Unload();
        crosshair.Unload();

        Raylib.CloseWindow();
    }
}