using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPGkimM16
{
    enum PlayerType { HUMAN, ELVER }
    internal class Player : Base
    {
        //field for enums
        PlayerType playerType;

        //property to get the enums
        public PlayerType PlayerType { get => playerType; set => playerType = value; }

        public Player()
        {
        }

        public Player(string name, int hp, int xp, PlayerType type)
        {
            Name = name;
            HP = hp;
            XP = xp;
            PlayerType = type;
        }

        public override int Attack(int attackBonus)
        {
            return base.Attack(attackBonus);
        }
    }
}
