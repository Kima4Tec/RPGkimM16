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
            int damageIndex = 0;

                //creating list of players
                List<Player> playerList = new List<Player>();
                playerList.Add(new Player("Ridder Richard", 100, 0, PlayerType.MENNESKE));
                playerList.Add(new Player("Ophelia", 200, 0, PlayerType.ELVER));


                //Creating monster list
                List<NPC> nPCList = new List<NPC>();
                NPC monster = new NPC("Ochphred", 50, 10, MonsterType.ORK);
                NPC monster1 = new NPC("Flytobus", 175, 20, MonsterType.DRAGE);
                nPCList.Add(monster);
                nPCList.Add(monster1);
            Random rndMonster = new Random();
            int monsterIndex = rndMonster.Next(0,nPCList.Count);

            //Find damagebonus if monster is dragon
            if (monsterIndex == 1)
            {
                Random findDamageBonus = new Random();
                damageIndex = findDamageBonus.Next(0, 30);
            }



                Console.WriteLine("Hvilken karakter vil du være? Tryk et af numrene:");
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
                    Console.WriteLine($"Du er {playerList[charChoice].Name}");
                    Console.WriteLine($"Et godt valg. Held og lykke på din rejse.");
                }

                else
                {
                    charChoice = 0;
                    Console.WriteLine($"Det kan du ikke vælge. Du er {playerList[charChoice].Name}");
                }

                playerList[0]._equipment.Add(new Equipment("næverne", 1.25, 5));
                playerList[0]._equipment.Add(new Equipment("Excalibur", 10, 10));
                playerList[0]._equipment.Add(new Equipment("Mountain Axe", 20.5, 20));
            playerList[1]._equipment.Add(new Equipment("næverne", 1.25, 5));
            playerList[1]._equipment.Add(new Equipment("Langbue", 15, 10));
            playerList[1]._equipment.Add(new Equipment("Det lysende sværd", 12.1, 23));

            Console.WriteLine();
                Console.WriteLine("Dette er dine våben. Hvilket vil du bruge?");
                Console.WriteLine(playerList[charChoice].ToString());
 
                ConsoleKeyInfo keyInf = Console.ReadKey(true);
                char key2 = keyInf.KeyChar;
                if (int.TryParse(key2.ToString(), out weaponChoice) && weaponChoice >= 0 && weaponChoice < playerList[charChoice]._equipment.Count)
                {Console.WriteLine($"Du har valgt {playerList[charChoice]._equipment[weaponChoice].Name}");
                Console.WriteLine("Et godt valg. Pas godt på dig selv");
                }
                else
                {
                    weaponChoice = 0;
                    Console.WriteLine("Det kan du ikke vælge. Du bruger dine næver.");
                }
            Console.WriteLine("Du hopper op på din hest og rider ind i skoven.");
            Console.WriteLine();
            Console.WriteLine($"Pludselig bliver du skubbet ned af hesten. Da du rejser dig op, står {nPCList[monsterIndex].Name} lige foran dig.\n" +
                $"Det er en {nPCList[monsterIndex].MonsterType}");
                Console.WriteLine("Kampen kan begynde.");
                Console.WriteLine($"{playerList[charChoice].Name} HP: {playerList[charChoice].HP}, {nPCList[monsterIndex].Name} HP: {nPCList[monsterIndex].HP}");


                Console.WriteLine($"{playerList[charChoice].Name} rammer {nPCList[monsterIndex].Name}. Bæstet vrider sig i smerte.\n");
                nPCList[monsterIndex].HP -= playerList[charChoice].Damage(playerList[charChoice]._equipment[weaponChoice].AttackBonus);
                Console.WriteLine($"{playerList[charChoice].Name} HP: {playerList[charChoice].HP}, {nPCList[monsterIndex].Name} HP: {nPCList[monsterIndex].HP}");

                Console.WriteLine($"Monstret langer ud efter {playerList[charChoice].Name} og rammer");
                playerList[charChoice].HP -= playerList[charChoice].Damage(damageIndex);
                Console.WriteLine($"{playerList[charChoice].Name} HP: {playerList[charChoice].HP}, {nPCList[monsterIndex].Name} HP: {nPCList[monsterIndex].HP}");

                Console.WriteLine("Det er en drabelig kamp, der forløber sådan:");
            while (!(playerList[charChoice].IsDead() || nPCList[monsterIndex].IsDead()))
            {
                nPCList[monsterIndex].HP -= playerList[charChoice].Damage(playerList[charChoice]._equipment[weaponChoice].AttackBonus);
                Console.WriteLine($"{nPCList[monsterIndex].Name} mister {playerList[charChoice].Damage(playerList[charChoice]._equipment[weaponChoice].AttackBonus)} HP");
                playerList[charChoice].HP -= playerList[charChoice].Damage(damageIndex);
                Console.WriteLine($"{playerList[charChoice].Name} mister {playerList[charChoice].Damage(damageIndex)} HP");

            }
            Console.WriteLine();

            if (playerList[charChoice].IsDead()) { Console.WriteLine($"{playerList[charChoice].Name} får et dræbende slag og dør"); }
            if (nPCList[monsterIndex].IsDead()) { Console.WriteLine($"{nPCList[monsterIndex].Name} bliver ramt lige i hjertet og dør."); }









            ////Question to user
            //Console.WriteLine("Er du klar?: (J/N)");
            //    ConsoleKeyInfo key = Console.ReadKey();
            //    char keyPress = key.KeyChar;
            //    Console.WriteLine();
            //    if (keyPress == 'j' || keyPress == 'N')
            //    {
            //        // Getting  hitpoints for the player and monster
            //        Console.WriteLine($"Player HP: {playerList[charChoice].HP}, Monster HP: {monster.HP}");

            //        //output to user
            //        Console.WriteLine($"Player: {playerList[charChoice].Name} swings at the {monster.Name} right in front of him");

            //        //check whether monster is still alive
            //        if (monster.HP > 0)
            //        {
            //            monster.HP -= playerList[charChoice].Damage(playerList[charChoice]._equipment[weaponChoice].AttackBonus);
            //        }

            //        //check whether player is still alive
            //        if (playerList[charChoice].HP > 0)
            //        {
            //            playerList[charChoice].HP -= playerList[charChoice].Damage(0);
            //        }
            //    }
            //}
            ////when dead write a text

        }
    }
    }

