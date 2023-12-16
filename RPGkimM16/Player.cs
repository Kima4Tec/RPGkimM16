using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPGkimM16
{
    enum PlayerType { ELVER, MENNESKE }

    internal class Player : Base
    {

        public List<Equipment> _equipment = new List<Equipment>();
        PlayerType playerType;

        internal PlayerType PlayerType { get => playerType; set => playerType = value; }

        public Player() { }

        //Constructor with parameters
        public Player(string name, int hp, int xp, PlayerType type)
        {
            Name = name;
            HP = hp;
            XP = xp;
            PlayerType = type;
        }
        //Adding equipments method with parameter
        public void AddWeapon(Equipment equipment)
        {
            _equipment.Add(equipment);
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name} is attacking!");
        }

        public override string ToString()
        {
            string playerWeapons = "\n";
            int i = 0;  
            foreach (var weapon in _equipment)
            {
                playerWeapons += "[" + i + "]" + " " + weapon.ToString() + "\n";
                i++;

            }

            return playerWeapons;
        }
        public string GetPlayerInfo()
        {
            return $"Navn: {Name}, HP: {HP}, XP: {XP}, Type: {PlayerType}";
        }


    }
}
