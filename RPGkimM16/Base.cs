using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGkimM16
{
    internal abstract class Base
    {

        string name;
        int hP;
        int xP;

        public string Name { get { return name; } set { name = value; } }
        public int HP { get => hP; set => hP = value; }
        public int XP { get => xP; set => xP = value; }

        public bool IsDead()
        {
            if (HP > 0)
            {
                return false;
            }
            else { return true; }
        }

        public void DoDamage(int damage)
        {
            //influence HP and maybe XP - weapon bonus is called by a argument HP = a random number + a bonus
            this.HP = this.HP - (damage);
        }

        //Made abstract and to be used in player and NPC
        public virtual int Attack(int attackBonus)
        {
            //Getting a random number
            Random num = new Random();
            int checkHit = num.Next(0, 6);
            if (checkHit > 2)
            {
                int rndNr = num.Next(0, 15);
                //Calling DoDamage with a random number and a bonus - text output can be avoided in a real game
                Console.WriteLine($"{this.Name} hits and causes {rndNr + attackBonus} damage to the opponent.");
                int damage = rndNr + attackBonus;
                return damage;
            }
            else
            {
                Console.WriteLine($"{this.Name} does not hit.");
                return 0;
            }
        }
    }
}
