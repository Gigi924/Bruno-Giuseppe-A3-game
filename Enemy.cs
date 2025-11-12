using gigi_a3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    internal class Enemy
    {
        Vector2 pos;
        Vector2 size;
        Vector2 angle;
        float speed;
        bool alive;

        public Enemy(Vector2 pos)
        {
            this.pos = pos;
            this.size = new Vector2(20, 20);
            this.speed = 40f;
            this.alive = true;
        }
        public void Update(Bullet[] bullets, Player mainPlayer)
        {
            if (alive)
            {
                EnemyMovement();
                DrawEnemy();
                Collision(bullets, mainPlayer);
            }

        }
        public void DrawEnemy()
        {
            Draw.FillColor = Color.Red;
            Draw.Rectangle(pos, size);
        }
        public void EnemyMovement()
        {
            Vector2 centerScreen = Window.Size / 2;
            Vector2 ceterToEnemy = centerScreen - pos;

            angle = Vector2.Normalize(ceterToEnemy);
            pos += speed * angle * Time.DeltaTime;
        }
        public void Collision(Bullet[] bullets, Player mainPlayer)
        {
            float enemyTop = pos.Y;
            float enemyBottom = pos.Y + size.Y;
            float enemyLeft = pos.X;
            float enemyRight = pos.X + size.X;

            //hit box collision

            for (int i = 0; i < bullets.Length; i++)
            {
                Bullet hitBox = bullets[i];
                if (hitBox != null)
                {
                    float hitBoxTop = hitBox.pos.Y;
                    float hitBoxBottom = hitBox.pos.Y + 7f;
                    float hitBoxLeft = hitBox.pos.X;
                    float hitBoxRight = hitBox.pos.X + 7f;



                    bool isColliding = enemyRight > hitBoxLeft && enemyLeft < hitBoxRight && enemyBottom > hitBoxTop && enemyTop < hitBoxBottom;

                    if (isColliding)
                    {
                        alive = false;
                    }
                }
            }

            float playerTop = mainPlayer.pos.Y;
            float playerBottom = mainPlayer.pos.Y + mainPlayer.size.Y;
            float playerLeft = mainPlayer.pos.X;
            float playerRight = mainPlayer.pos.X + mainPlayer.size.X;

            bool playerIsColliding = enemyRight > playerLeft && enemyLeft < playerRight && enemyBottom > playerTop && enemyTop < playerBottom;

            if (playerIsColliding)
            {
                Window.ClearBackground(Color.Red);
            }


        }
    }
}