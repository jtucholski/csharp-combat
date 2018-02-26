using System;
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

            System.Threading.Thread.Sleep(SleepTime);

            Console.WriteLine();
            Console.WriteLine($"Who dare challenge this {GetRandomString(descriptions).ToLower()} fighter?");
            Console.WriteLine();

            IFightable fighter2 = AskUserForFighter();
            IStrikable fighter2Weapon = AskUserForWeapon();
            fighter2.Weapon = fighter2Weapon;
            
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
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine(GetRandomString(messages));
                    return weaponOptions[choice];
                }
                else 
                {
                    Console.WriteLine("What are you? Daft? Pick an instrument of destruction!");
                }
            }
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
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    return fighterOptions[choice];
                }
                else 
                {
                    Console.WriteLine("What are you? Daft? Pick a fighter!");
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
    }
}