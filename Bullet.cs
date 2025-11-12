using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    internal class Bullet
    {
        Vector2 pos;
        Vector2 size;

        public Bullet(Vector2 pos, Vector2 size)
        {
            this.pos = pos;
            this.size = size;
        }
    }
}