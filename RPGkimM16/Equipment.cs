using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGkimM16
{
    internal class Equipment
    {
        string name;
        double weight;
        int attackBonus;

        public Equipment(string name, double weight, int attackBonus)
        {
            Name = name;
            Weight = weight;
            AttackBonus = attackBonus;
        }

        public string Name { get { return name; } set { name = value; } }
        public double Weight { get => weight; set => weight = value; }
        public int AttackBonus { get => attackBonus; set => attackBonus = value; }
    }
}
