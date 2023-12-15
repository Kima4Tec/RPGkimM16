using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGkimM16
{
    public abstract class Base
    {
        public string name;
        public int hP;
        public int xP;

        public string Name { get => name; set => name = value; }
        public int HP { get => hP; set => hP = value; }
        public int XP { get => xP; set => xP = value; }

        public abstract void Attack();

        //Damage is calculated randomly
        public int Damage(int bonus) 
        {
            Random takeHit = new Random();
            int Hit = takeHit.Next(0, 10);
            return Hit + bonus;
        }

        //bool to check if dead
        public bool IsDead() 
        {
            if (HP > 0) return false;
            else 
                return true;
        }


    }
}
