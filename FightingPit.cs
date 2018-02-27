using System;
using System.Threading;
using csharp_combat.Combatants;
using csharp_combat.Weapons;

namespace csharp_combat
{
    public class FightingPit 
    {
        private static IFightable[] fighterOptions = {
            new BubbaTheBruiser(),
            new Link()
        };

        private static IStrikable[] weaponOptions = {
            new MasterSword()
        };

        private static string[] descriptions = {
            "Fearless", "Lonesome", "Amazing", "Pathetic"
        };

        private static string[] messages = {
            "Ah! A good choice!",
            "Excellent",
            "Heh heh...I hope you brought help!",
            "The hour of your doom nears..."
        };

        private const int SleepTime = 2000;

        public FightingPit()
        {

        }

        public void Run()
        {
            Console.Clear();
            PrintGreeting();

            IFightable fighter1 = AskUserForFighter();
            IStrikable fighter1Weapon = AskUserForWeapon();
            fighter1.Weapon = fighter1Weapon;

            
            Console.WriteLine();
            PrintMessage($"Who dare challenge this {GetRandomString(descriptions).ToLower()} fighter?");
            Console.WriteLine();

            IFightable fighter2 = AskUserForFighter();
            IStrikable fighter2Weapon = AskUserForWeapon();
            fighter2.Weapon = fighter2Weapon;

            Fight(fighter1, fighter2);            
        }

        private void Fight(IFightable fighter1, IFightable fighter2)
        {
            Console.WriteLine("The carnage BEGINS!");
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();

            bool autoPlayMode = false;

            while(!fighter1.IsDead && !fighter1.IsDead)
            {

                if (autoPlayMode)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                Console.Clear();

                PlayAttack(fighter1, fighter2);
                Console.WriteLine();

                Thread.Sleep(TimeSpan.FromSeconds(2));

                PlayAttack(fighter2, fighter1);
                Console.WriteLine();

                Console.WriteLine($"This leaves {fighter1} with {fighter1.Health} hit points and {fighter2} with {fighter2.Health} hit points remaining.");
                Console.WriteLine();

                if(!autoPlayMode)
                {                    
                    autoPlayMode = (Console.ReadKey().Key == ConsoleKey.Escape);
                }                
            }
        }

        private void PlayAttack(IFightable attacker, IFightable defender)
        {
            Console.WriteLine($"{attacker} strikes with {attacker.Weapon}");
            int damageDealt = attacker.DealDamage();

            Console.WriteLine($"A hit of {damageDealt} points!");
            int actualDamage = defender.TakeDamage(damageDealt, attacker.DamageType);
            if (actualDamage < damageDealt)
            {
                Console.WriteLine($"But what moves! {defender} only took {actualDamage} actual damage.");
            }
            else if (actualDamage > damageDealt)
            {
                Console.WriteLine($"{defender} actually took {actualDamage} damage from that hit!");
            }
        }

        private string GetRandomString(string[] strings)
        {
            Random rng = new Random();
            int index = rng.Next(strings.Length);

            return strings[index];
        }

        private IStrikable AskUserForWeapon()
        {
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("Choose a weapon!!");

                for (int i = 0; i < weaponOptions.Length; i++)
                {
                    Console.WriteLine($" {i}: {weaponOptions[i]}");
                }

                Console.Write("What will they fight with? ");                
                if (int.TryParse(Console.ReadLine(), out int choice) && choice < weaponOptions.Length)
                {
                    Console.WriteLine();
                    PrintMessage(GetRandomString(messages));
                    return weaponOptions[choice];
                }
                else 
                {
                    Console.WriteLine();
                    PrintError("What are you? Daft? Pick an instrument of destruction!");
                    
                }
            }
        }

        private void PrintError(string message)
        {            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private IFightable AskUserForFighter()
        {
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("Choose a fighter!!");

                for (int i = 0; i < fighterOptions.Length; i++)
                {
                    Console.WriteLine($" {i}: {fighterOptions[i]}");
                }

                Console.Write("Who will you choose? ");                
                if (int.TryParse(Console.ReadLine(), out int choice) && choice < fighterOptions.Length)
                {
                    return fighterOptions[choice];
                }
                else 
                {
                    Console.WriteLine();
                    PrintError("What are you? Daft? Pick a fighter!");
                }

            }
        }


        private void PrintGreeting()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to the fighting pit!");
            Console.WriteLine("Today we'll see titans clash in the ultimate fighting arena!");
            Console.WriteLine("So who will be the fighters today?");
            Console.WriteLine();
        }

        private void PrintMessage(string message)
        {
            for(int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(25);
            }
            Console.Write("\n");
        }
    }
}