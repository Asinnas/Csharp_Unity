using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class GridManager
    {
        public Tile[,] Grid = new Tile[10, 10];

        public void SpawnTile()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    Grid[i, j] = new Tile(i, j);
        }

        public void UpdateGrid(Player player, List<Enemy> enemyList)
        {
            foreach (var tile in Grid)
                tile.Occupant = null;

            Grid[player.PosX, player.PosY].Occupant = player;

            foreach (Enemy e in enemyList)
                if (e.Health > 0)
                    Grid[e.PosX, e.PosY].Occupant = e;
        }

        public void DrawGrid()
        {
            Console.WriteLine("---------------------");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Grid[i, j].Occupant == null)
                        Console.Write("X ");
                    else if (Grid[i, j].Occupant is Player)
                        Console.Write("0 ");
                    else
                        Console.Write("1 ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("---------------------");
        }
    }
}
