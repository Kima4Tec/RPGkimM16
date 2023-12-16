using System.Numerics;
using System.Reflection;
using System.Threading;
using System.Xml.Linq;

namespace RPGkimM16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating a player
            Player player = new Player("Peter", 100, 0, PlayerType.HUMAN);
            //Creating a weapon for the player
            Equipment weapon = new Equipment("Excalibur", 12.5, 10);

            Console.WriteLine("Press ENTER to start battle");
            Console.ReadLine();
            int i = 0;
            while (!player.IsDead())
            {
                NPC monster = GetMonster();
                i++;
                Battle(player, weapon, monster);
            }
            Console.WriteLine($"{player.Name} killed {i} monsters");
        }

        static NPC GetMonster()
        {
            NPC monster = new NPC("Orktip", 50, 0, MonsterType.ORC);
            //Creating a random monster
            Random rndMonster = new Random();
            int getRndMonster = rndMonster.Next(0, 4);
            if (getRndMonster == 1)
            {
                monster = new NPC("FireMouth", 125, 0, MonsterType.DRAGON);
            }
            if (getRndMonster == 2)
            {
                monster = new NPC("DarkWhisper", 75, 0, MonsterType.BEAST);
            }
            if (getRndMonster == 3)
            {
                monster = new NPC("Noone", 40, 0, MonsterType.UNDEAD);
            }
            return monster;

        }

        /// <summary>
        /// Method that can be called many time for many battles ahead
        /// </summary>
        /// <param name="player"></param>
        /// <param name="monster"></param>
        /// <param name="weapon"></param>
        static void Battle(Player player, Equipment weapon, NPC monster)
        {
            //while loop checking if monster or human is dead
            while (!(player.IsDead() || monster.IsDead()))
            {
                Console.WriteLine(monster.Name);
                //Player is being attacked - call method
                monster.DoDamage(player.Attack(weapon.AttackBonus + player.XP));
                player.XP++;
                //monster is being attacked
                player.DoDamage(monster.Attack(0));
            }
            //Status after fight
            if (player.IsDead())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Player died.");
                Console.WriteLine("GAME OVER.");
                Console.ResetColor();
            }
            else if (monster.IsDead())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Monster died.");
                Console.ResetColor();
                Console.WriteLine("Well done!");

                Console.WriteLine($"{player.Name}: HP {player.HP}, XP {player.XP}");
                Random rndDays = new Random();
                int passingDays = rndDays.Next(2, 10);
                player.HP += (passingDays);
                if (player.HP > 100)
                {
                    player.HP = 100;
                }
                Console.WriteLine($"{passingDays} days went by and {player.Name} were feeling better. HP: {player.HP}");
                Console.WriteLine("Press ENTER to meet the next monster");
                Console.ReadLine();
            }

        }
    }
}

