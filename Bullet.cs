using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Bullet
    {
        public Vector2 pos;
        public Vector2 vel;

        float speed = 500f;

        public void Update()
        {
            Movement();
            DrawBullet();
        }
        public void DrawBullet()
        {
            Draw.FillColor = Color.Gray;
            Draw.LineSize = 2;
            Draw.Circle(pos, 7f);
        }
        public void Movement()
        {
            pos += speed * vel * Time.DeltaTime;
        }
    }
}