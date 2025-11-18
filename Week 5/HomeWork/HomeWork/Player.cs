using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Player : Character
    {
        public Weapon CurrentWeapon { get; private set; }

        public Player(int x, int y, Weapon weapon)
            : base(x, y, weapon.Damage, weapon.RangeAttack, 10)
        {
            CurrentWeapon = weapon;
        }

        public override void Move(char direction = ' ')
        {
            direction = char.ToUpper(direction);

            switch (direction)
            {
                case 'W': PosX = Math.Max(0, PosX - 1); break;
                case 'S': PosX = Math.Min(PosX + 1, 4); break;
                case 'A': PosY = Math.Max(0, PosY - 1); break;
                case 'D': PosY = Math.Min(PosY + 1, 4); break;
            }
        }

        public override void Attack(Tile[,] grid)
        {
            Character target = CheckRangeAttack(grid);
            if (target != null)
            {
                target.TakeDamage(CurrentWeapon.Damage);
                Console.WriteLine($"Player tấn công {target.GetType().Name}, gây {CurrentWeapon.Damage} sát thương!");
            }
        }
    }
}
