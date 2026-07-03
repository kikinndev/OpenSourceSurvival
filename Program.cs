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

        float scale = 3;

        Sprite playerSprite = new Sprite("Resources/player_up.png", new Vector2(screenWidth / 2, screenHeight / 2), scale);
        Sprite playerHands = new Sprite("Resources/player_hands.png", new Vector2(screenWidth / 2, screenHeight / 2), scale);

        float speed = 200;

        while (!Raylib.WindowShouldClose())
        {
            float delta = Raylib.GetFrameTime();
            Vector2 direction = Vector2.Zero;
            Vector2 mousePos = Raylib.GetMousePosition();

            if (Raylib.IsKeyDown(KeyboardKey.W))
            {
                direction.Y -= 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.S))
            {
                direction.Y += 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                direction.X -= 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                direction.X += 1;
            }

            if (direction.LengthSquared() > 0)
            {
                direction = Vector2.Normalize(direction);
            }

            playerSprite.position += direction * speed * delta;
            playerHands.position = playerSprite.position;

            playerSprite.LookAt(mousePos, 100, delta);
            playerHands.LookAt(mousePos, 10, delta);

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            playerSprite.Draw();
            playerHands.Draw();

            Raylib.EndDrawing();
        }

        playerSprite.Unload();
        playerHands.Unload();

        Raylib.CloseWindow();
    }
}