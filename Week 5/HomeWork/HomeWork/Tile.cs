using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Tile
    {
        public Character Occupant { get; set; }
        public int PosX { get; }
        public int PosY { get; }

        public Tile(int x, int y)
        {
            PosX = x;
            PosY = y;
            Occupant = null;
        }

        public bool IsOccupied() => Occupant != null;
    }
}
