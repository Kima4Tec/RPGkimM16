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



        public string Name { get => name; set => name = value; }
        public double Weight { get => weight; set => weight = value; }
        public int AttackBonus { get => attackBonus; set => attackBonus = value; }



        public Equipment(string name, double weight, int attackBonus)
        {
            Name = name;
            Weight = weight;
            AttackBonus = attackBonus;

        }
        public override string ToString()
        {
            return $"Name: {Name}, Weight: {Weight}, Attack Bonus: {AttackBonus}";
        }

    }
}
