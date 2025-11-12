using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace gigi_a3
{
    public class Player
    {
        public Vector2 pos;
        public Vector2 size;
        public Player(Vector2 pos, Vector2 size)
        {
            this.pos = pos;
            this.size = size;
        }
        public void update()
        {
            drawPlayer();
        }
        public void drawPlayer()
        {
            float eyeRadius = size.X / 4.0f;
            float pupilRadius = eyeRadius / 2.0f;

            Vector2 eyeCenterLeft = new Vector2(pos.X + size.X / 4, pos.Y + size.Y / 4 + 2);
            Vector2 mouseDirectionLeft = Input.GetMousePosition() - eyeCenterLeft;

            Vector2 eyeCenterRight = new Vector2(pos.X + size.X * 3 / 4, pos.Y + size.Y / 4 + 2);
            Vector2 mouseDirectionRight = Input.GetMousePosition() - eyeCenterRight;

            // Body
            Draw.FillColor = Color.Blue;
            Draw.Rectangle(pos.X, pos.Y, size.X, size.Y);

            // Eyes
            Draw.FillColor = Color.White;
            Draw.Circle(eyeCenterLeft.X, eyeCenterLeft.Y, eyeRadius);
            Draw.Circle(eyeCenterRight.X, eyeCenterRight.Y, eyeRadius);

            // Pupils
            Draw.FillColor = Color.Black;

            Vector2 leftPupilOffset = Vector2.Normalize(mouseDirectionLeft) * MathF.Min(mouseDirectionLeft.Length(), eyeRadius - pupilRadius);
            Vector2 rightPupilOffset = Vector2.Normalize(mouseDirectionRight) * MathF.Min(mouseDirectionRight.Length(), eyeRadius - pupilRadius);

            Draw.Circle(eyeCenterLeft.X + leftPupilOffset.X, eyeCenterLeft.Y + leftPupilOffset.Y, pupilRadius);
            Draw.Circle(eyeCenterRight.X + rightPupilOffset.X, eyeCenterRight.Y + rightPupilOffset.Y, pupilRadius);
        }
    }
}