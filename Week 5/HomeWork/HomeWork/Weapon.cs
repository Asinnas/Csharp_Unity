using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Weapon
    {
        public string Name { get; set; }
        public double Damage { get; set; }
        public int RangeAttack { get; set; }

        public Weapon(string name, double damage, int range)
        {
            Name = name;
            Damage = damage;
            RangeAttack = range;
        }
    }
}
