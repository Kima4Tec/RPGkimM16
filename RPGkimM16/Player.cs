using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPGkimM16
{
    enum PlayerType { ELVER, HUMAN}

    internal class Player : Base
    {
List<Equipment> _equipment = new List<Equipment>();


        PlayerType playerType;

        internal PlayerType PlayerType { get => playerType; set => playerType = value; }


        public Player()
        {
        }

        public Player(string name, int hp, int xp, PlayerType type)
        {
            Name = name;
            HP = hP;
            XP = xP;
            PlayerType = playerType;
        }

        public void AddWeapon(Equipment equipment)
        {
            _equipment.Add(equipment);
        }


        public override void Attack()
        {
            Console.WriteLine($"{Name} is attacking!");
        }

        //public override string ToString()
        //{
        //    string playerWeapons = "Knuckles\n";  // Default weapon, assuming there's always at least one weapon


        //    foreach (var weapon in _equipment)
        //    {
        //        playerWeapons += weapon.ToString() + "\n";
        //    }

        //    return playerWeapons;
        //}


    }
}
