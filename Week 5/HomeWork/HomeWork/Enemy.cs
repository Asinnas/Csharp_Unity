using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Enemy : Character
    {
        private Random rnd = new Random();
        public Enemy(int x, int y) : base(x, y, 1.5, 1, 5) { }

        public override void Move(char direction = ' ')
        {
            int r = rnd.Next(4);
            switch (r)
            {
                case 0: PosX = Math.Max(0, PosX - 1); break;
                case 1: PosX = Math.Min(PosX + 1, 4); break;
                case 2: PosY = Math.Max(0, PosY - 1); break;
                case 3: PosY = Math.Min(PosY + 1, 4); break;
            }
        }
    }
}
