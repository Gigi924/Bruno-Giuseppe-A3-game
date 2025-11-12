// Include the namespaces (code libraries) you need below.
using gigi_a3;
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:

        Player mainPlayer = new Player(new Vector2(385, 285), new Vector2(30, 30));

        

        Enemy[] enemies =
        {
            new Enemy(new Vector2(400, 10)),
            new Enemy(new Vector2(328, 10)),
            new Enemy(new Vector2(129, 10)),
            new Enemy(new Vector2(346, 10)),
            new Enemy(new Vector2(256, 10)),
            new Enemy(new Vector2(300, 10)),
            new Enemy(new Vector2(100, 10)),
            new Enemy(new Vector2(150, 10)),
            new Enemy(new Vector2(550, 10)),
            new Enemy(new Vector2(200, 10)),
            new Enemy(new Vector2(60, 10)),
            new Enemy(new Vector2(20, 10)),
            new Enemy(new Vector2(450, 10)),
            new Enemy(new Vector2(45, 10)),
        };

        Bullet[] bullets = new Bullet[10];
        int bulletIndex = 0;
        int magCurrent = 10;
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.TargetFPS = 60;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.Black);
            bulletCounter();

            mainPlayer.update();
            //player Inputs
            if (Input.IsMouseButtonPressed(MouseInput.Left))
            {
                SpawnBullet();
            }
            if (Input.IsKeyboardKeyPressed(KeyboardInput.R))
            {
                bulletIndex = 0;
                magCurrent = 10;
            }
            //bullet visuals
            for (int i = 0; i < bulletIndex; i++)
            {
                bullets[i].Update();
            }
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].Update(bullets, mainPlayer);
            }
        }
        public void SpawnBullet()
        {
            if (bulletIndex < bullets.Length)
            {
                Bullet bullet = new Bullet();
                Vector2 centerScreen = Window.Size / 2;
                bullet.pos = centerScreen;

                Vector2 ceterToMouse = Input.GetMousePosition() - centerScreen;
                bullet.angle = Vector2.Normalize(ceterToMouse);

                bullets[bulletIndex] = bullet;
                bulletIndex++;
                magCurrent--;
            }

        }
        public void bulletCounter()
        {
            Text.Color = Color.White;
            Text.Size = 15;
            Text.Draw($"remaining ammo:{magCurrent}/10", new Vector2(10, 10));
        }

    }

}