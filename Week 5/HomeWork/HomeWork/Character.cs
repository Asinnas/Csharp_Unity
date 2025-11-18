using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    abstract class Character
    {
        public int PosX { get; protected set; }
        public int PosY { get; protected set; }
        public double Damage { get; protected set; }
        public int RangeAttack { get; protected set; }
        public double Health { get; protected set; }

        public Character(int x, int y, double damage, int range, double health)
        {
            PosX = x;
            PosY = y;
            Damage = damage;
            RangeAttack = range;
            Health = health;
        }

        public abstract void Move(char direction = ' ');

        public void TakeDamage(double damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public virtual Character? CheckRangeAttack(Tile[,] grid)
        {
            int maxX = grid.GetLength(0);
            int maxY = grid.GetLength(1);

            List<Character> targetsInRange = new List<Character>();

            for (int i = -RangeAttack; i <= RangeAttack; i++)
            {
                for (int j = -RangeAttack; j <= RangeAttack; j++)
                {
                    int newX = PosX + i;
                    int newY = PosY + j;

                    if (newX >= 0 && newX < maxX && newY >= 0 && newY < maxY)
                    {
                        Character? target = grid[newX, newY].Occupant;
                        if (target != null && target != this)
                        {
                            targetsInRange.Add(target);
                        }
                    }
                }
            }

            if (targetsInRange.Count == 0) return null;

            // Tìm khoảng cách nhỏ nhất
            double minDist = targetsInRange.Min(t =>
                Math.Abs(t.PosX - PosX) + Math.Abs(t.PosY - PosY)
            );

            // Lọc những enemy có khoảng cách gần nhất
            var closestTargets = targetsInRange
                .Where(t => Math.Abs(t.PosX - PosX) + Math.Abs(t.PosY - PosY) == minDist)
                .ToList();

            // Random nếu có nhiều con gần như nhau
            Random rnd = new Random();
            return closestTargets[rnd.Next(closestTargets.Count)];
        }

        public virtual void Attack(Tile[,] grid)
        {
            Character? target = CheckRangeAttack(grid);
            if (target != null)
            {
                target.TakeDamage(Damage);
                Console.WriteLine($"{GetType().Name} gây {Damage} sát thương!");
            }
        }


    }
}
