using System.Threading;

namespace RPGkimM16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                //creating list of players
                Player player = new Player() { Name = "Kim", HP = 100, XP = 0, PlayerType = PlayerType.HUMAN };
                //creating list of equipment
                Equipment sword = new Equipment() { Name = "Excalibur", Weight = 2.5, AttackBonus = 10 };
                Equipment axe = new Equipment() { Name = "Mountain Axe", Weight = 20.5, AttackBonus = 20 };
                //Creating monster list
                NPC monster = new NPC() { Name = "Goblin", HP = 50, XP = 10, MonsterType = MonsterType.ORC };

                //adding weapons to the player
                player.AddWeapon(sword);
                player.AddWeapon(axe);
                //show weapon
                Console.WriteLine($"You are equiped with a sword.");


                while (!(player.IsDead() || monster.IsDead()))
                {

                    //Question to user
                    Console.WriteLine("Are you ready?: (Y/N)");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    char keyPressed = keyInfo.KeyChar;
                    Console.WriteLine();
                    if (keyPressed == 'y' || keyPressed == 'Y')
                    {
                        // Getting  hitpoints for the player and monster
                        Console.WriteLine($"Player HP: {player.HP}, Monster HP: {monster.HP}");

                        //output to user
                        Console.WriteLine($"Player: {player.Name} swings at the {monster.name} right in front of him");

                        //check whether monster is still alive
                        if (monster.HP >0)
                        {
                            monster.HP -= monster.Damage(sword.AttackBonus);
                        }

                        //check whether player is still alive
                        if (player.HP > 0)
                        {
                            player.HP -= player.Damage(0);
                        }
                    }
                }
                //when dead write a text
                if (player.IsDead()) { Console.WriteLine($"{player.Name} died"); }
                if (monster.IsDead()) { Console.WriteLine($"{monster.Name} died"); }
            }
        }
    }
}
