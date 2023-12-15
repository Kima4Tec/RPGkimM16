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
            int weaponChoice = 0;
            int charChoice = 0;
            {
                //creating list of players
                List<Player> playerList = new List<Player>();
                playerList.Add(new Player("Kim", 100, 0, PlayerType.HUMAN));
                playerList.Add(new Player("Ophelia", 200, 0, PlayerType.ELVER));




                //Creating monster list
                List<NPC> nPCList = new List<NPC>();
                NPC monster = new NPC("Ochphred", 50, 10, MonsterType.ORC);
                NPC monster1 = new NPC("Flytobus", 75, 20, MonsterType.DRAGON);
                nPCList.Add(monster);
                nPCList.Add(monster1);


                Console.WriteLine("Which character do you want to be? Press a number:");
                int j = 0;
                foreach (var item in playerList)
                {
                    Console.WriteLine("[" + j + "]" + " " + item.GetPlayerInfo());
                    j++;
                }


                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char key1 = keyInfo.KeyChar;
                if (int.TryParse(key1.ToString(), out charChoice) && charChoice >= 0 && charChoice < playerList.Count)
                {
                    Console.WriteLine($"You are {playerList[charChoice].Name}");
                }
                else
                {
                    charChoice = 0;
                    Console.WriteLine($"Invalid choice. You are by default {playerList[charChoice].Name}");
                }

                playerList[charChoice]._equipment.Add(new Equipment("knuckles", 1.25, 5));
                playerList[charChoice]._equipment.Add(new Equipment("Excalibur", 10, 10));
                playerList[charChoice]._equipment.Add(new Equipment("Mountain Axe", 20.5, 20));

                Console.WriteLine();
                Console.WriteLine("These are your weapons. Which one do you want to use?");
                Console.WriteLine(playerList[charChoice].ToString());
 
                ConsoleKeyInfo keyInf = Console.ReadKey(true);
                char key2 = keyInf.KeyChar;
                if (int.TryParse(key2.ToString(), out weaponChoice) && weaponChoice >= 0 && weaponChoice < playerList[charChoice]._equipment.Count)
                {
                    Console.WriteLine($"You are equipped with {playerList[charChoice]._equipment[weaponChoice].Name}");
                }
                else
                {
                    weaponChoice = 0;
                    Console.WriteLine("Invalid weapon choice. You are using your knuckles.");
                }

                Console.WriteLine("The fight can begin.");
                Console.WriteLine($"Player HP: {playerList[charChoice].HP}, Monster HP: {monster.HP}");


                while (!(playerList[charChoice].IsDead() || monster.IsDead()))
                {

                    //Question to user
                    Console.WriteLine("Are you ready?: (Y/N)");
                    ConsoleKeyInfo key = Console.ReadKey();
                    char keyPress = key.KeyChar;
                    Console.WriteLine();
                    if (keyPress == 'y' || keyPress == 'Y')
                    {
                        // Getting  hitpoints for the player and monster
                        Console.WriteLine($"Player HP: {playerList[charChoice].HP}, Monster HP: {monster.HP}");

                        //output to user
                        Console.WriteLine($"Player: {playerList[charChoice].Name} swings at the {monster.Name} right in front of him");

                        //check whether monster is still alive
                        if (monster.HP > 0)
                        {
                            monster.HP -= playerList[charChoice]._equipment[weaponChoice].AttackBonus;
                        }

                        //check whether player is still alive
                        if (playerList[charChoice].HP > 0)
                        {
                            playerList[charChoice].HP -= playerList[charChoice].Damage(0);
                        }
                    }
                }
                //when dead write a text
                if (playerList[charChoice].IsDead()) { Console.WriteLine($"{playerList[charChoice].Name} died"); }
                if (monster.IsDead()) { Console.WriteLine($"{monster.Name} died"); }
            }
        }
    }
}
