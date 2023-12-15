using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGkimM16
{
    //different monster types
    enum MonsterType { DRAGON, ORC }
    internal class NPC : Base
    {
        MonsterType monsterType;
        internal MonsterType MonsterType { get => monsterType; set => monsterType = value; }
        //constructor
        public NPC()
        {
        }
        //constructor with parameters
        public NPC(string name, int hp, int xp, MonsterType type)
        {
            Name = name;
            HP = hp;
            XP = xp;
            MonsterType = type;
        }

//showing text
        public override void Attack()
        {
            Console.WriteLine($"{Name} is attacking!");
        }


    }
}
