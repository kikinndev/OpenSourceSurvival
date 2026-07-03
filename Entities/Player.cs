using Raylib_cs;
using System.Data;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Main;

public class Player
{
    float speed = 200;

    Vector2 position;

    Sprite playerSprite;
    Sprite handsSprite;

    public Player(Vector2 position)
    {
        this.position = position;
        playerSprite = new Sprite("Resources/player_up.png", position, 3);
        handsSprite = new Sprite("Resources/player_hands.png", position, 3);
    }

    public void Update(Vector2 mousePos, float delta)
    {
        Vector2 direction = Vector2.Zero;

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

        position += direction * speed * delta;
        
        playerSprite.position = position;
        handsSprite.position = position;

        playerSprite.LookAt(mousePos, 100, delta);
        handsSprite.LookAt(mousePos, 10, delta);
    }

    public void Draw()
    {
        playerSprite.Draw();
        handsSprite.Draw();
    }

    public void Unload()
    {
        playerSprite.Unload();
        handsSprite.Unload();
    }
}