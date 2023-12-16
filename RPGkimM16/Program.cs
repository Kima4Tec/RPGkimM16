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

            //Creating list of players
            List<Player> playerList = new List<Player>();
            playerList.Add(new Player("Ridder Richard", 100, 0, PlayerType.MENNESKE));
            playerList.Add(new Player("Ophelia", 200, 0, PlayerType.ELVER));


            //Creating monster list
            List<NPC> nPCList = new List<NPC>();
            NPC monster = new NPC("Ochphred", 50, 10, MonsterType.ORK);
            NPC monster1 = new NPC("Flytobus", 175, 20, MonsterType.DRAGE);
            nPCList.Add(monster);
            nPCList.Add(monster1);

            //Getting a random monster
            Random rndMonster = new Random();
            int monsterIndex = rndMonster.Next(0, nPCList.Count);

            //Find damagebonus if monster is dragon
            if (monsterIndex == 1)
            {
                Random findDamageBonus = new Random();
                damageIndex = findDamageBonus.Next(0, 30);
            }


            //User interaction: Get user to choose character by number which is the index in the list
            //First the list is printed out. If choice is not valid, set a default.
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

            //Adding weapons to the list _equipment in Class Player, which fields and properties can be found in Class Equipment
            playerList[0]._equipment.Add(new Equipment("næverne", 1.25, 5));
            playerList[0]._equipment.Add(new Equipment("Excalibur", 10, 10));
            playerList[0]._equipment.Add(new Equipment("Mountain Axe", 20.5, 20));
            playerList[1]._equipment.Add(new Equipment("næverne", 1.25, 5));
            playerList[1]._equipment.Add(new Equipment("Langbue", 15, 10));
            playerList[1]._equipment.Add(new Equipment("Det lysende sværd", 12.1, 23));

            //Let user choose a weapon. Choice is the index of the list. Default is knuckles, if non-valid response
            Console.WriteLine();
            Console.WriteLine("Dette er dine våben. Hvilket vil du bruge?");
            Console.WriteLine(playerList[charChoice].ToString());

            ConsoleKeyInfo keyInf = Console.ReadKey(true);
            char key2 = keyInf.KeyChar;
            if (int.TryParse(key2.ToString(), out weaponChoice) && weaponChoice >= 0 && weaponChoice < playerList[charChoice]._equipment.Count)
            {
                Console.WriteLine($"Du har valgt {playerList[charChoice]._equipment[weaponChoice].Name}");
                Console.WriteLine("Et godt valg. Pas godt på dig selv");
            }
            else
            {
                weaponChoice = 0;
                Console.WriteLine("Det kan du ikke vælge. Du bruger dine næver.");
            }

            //The story begins
            Console.WriteLine("Du hopper op på din hest og rider ind i skoven.");
            Console.WriteLine();
            Console.WriteLine($"Pludselig bliver du skubbet ned af hesten. Da du rejser dig op, står {nPCList[monsterIndex].Name} lige foran dig.\n" +
                $"Det er en {nPCList[monsterIndex].MonsterType}");
            Console.WriteLine("Kampen kan begynde.");
            //Output of status of player and monster
            Console.WriteLine($"{playerList[charChoice].Name} HP: {playerList[charChoice].HP}, {nPCList[monsterIndex].Name} HP: {nPCList[monsterIndex].HP}");

            //Story
            Console.WriteLine($"{playerList[charChoice].Name} rammer {nPCList[monsterIndex].Name}. Bæstet vrider sig i smerte.\n");

            //Calling the method Damage() for how much damage the player does to the monster in Class Base with a parameter bonus,
            //which is a property of the players weapons, and can also be given to certain monsters like the dragon. The dragon
            //is getting a random number set in the variable damageIndex
            nPCList[monsterIndex].HP -= playerList[charChoice].Damage(playerList[charChoice]._equipment[weaponChoice].AttackBonus);
            Console.WriteLine($"{playerList[charChoice].Name} HP: {playerList[charChoice].HP}, {nPCList[monsterIndex].Name} HP: {nPCList[monsterIndex].HP}");

            //The monsters damage towards the player
            Console.WriteLine($"Monstret langer ud efter {playerList[charChoice].Name} og rammer");
            playerList[charChoice].HP -= playerList[charChoice].Damage(damageIndex);
            Console.WriteLine($"{playerList[charChoice].Name} HP: {playerList[charChoice].HP}, {nPCList[monsterIndex].Name} HP: {nPCList[monsterIndex].HP}");

            //The battle continues in a while loop, til one of them dies, checked in the bool IsDead in the Class Base
            Console.WriteLine("Det er en drabelig kamp, der forløber sådan:");
            while (!(playerList[charChoice].IsDead() || nPCList[monsterIndex].IsDead()))
            {
                nPCList[monsterIndex].HP -= playerList[charChoice].Damage(playerList[charChoice]._equipment[weaponChoice].AttackBonus);
                Console.WriteLine($"{nPCList[monsterIndex].Name} mister {playerList[charChoice].Damage(playerList[charChoice]._equipment[weaponChoice].AttackBonus)} HP");
                playerList[charChoice].HP -= playerList[charChoice].Damage(damageIndex);
                Console.WriteLine($"{playerList[charChoice].Name} mister {playerList[charChoice].Damage(damageIndex)} HP");

            }
            Console.WriteLine();
            //If player is dead, game over
            if (playerList[charChoice].IsDead()) 
            { 
                Console.WriteLine($"{playerList[charChoice].Name} får et dræbende slag og dør"); 
                Console.WriteLine("\nGAME OVER......");
            }
            //If monster dies, player gets XP points and restores full life. Made so it can be changed to percentage or maybe a random number.
            if (nPCList[monsterIndex].IsDead())
            {
                Console.WriteLine($"{nPCList[monsterIndex].Name} bliver ramt lige i hjertet og dør.");
                Console.WriteLine($"Efter at have hvilet sig og plejet sig, er {playerList[charChoice].Name} klar igen. XP er steget med 10");
                if (charChoice == 0)
                {
                    playerList[charChoice].HP = playerList[charChoice].HP + (100 - playerList[charChoice].HP);
                }
                if (charChoice == 1)
                {
                    playerList[charChoice].HP = playerList[charChoice].HP + (200 - playerList[charChoice].HP);
                }
                playerList[charChoice].HP = playerList[charChoice].HP + (100 - playerList[charChoice].HP);
                playerList[charChoice].XP = playerList[charChoice].XP + 10;
                Console.WriteLine("Status:");
                Console.WriteLine($"Navn: {playerList[charChoice].Name}, HP: {playerList[charChoice].HP}, XP: {playerList[charChoice].XP}, Type: {playerList[charChoice].PlayerType}");
            }


        }
    }
}

