using System;

namespace csharp_combat.Weapons
{
    public abstract class Sword : IStrikable
    {

        private int DieFaces { get; set; }
        private int NumberOfDice { get; set; }
        private Random rng = new Random();

        public Sword(int dieFaces, int numberOfDice)
        {
            this.NumberOfDice = numberOfDice;
            this.DieFaces = dieFaces;
        }

        public int DealDamge()
        {
            int damage = 0;
            for (int i = 0; i < NumberOfDice; i++)
            {
                damage += rng.Next(DieFaces) + 1;
            }

            return damage;
        }

        public abstract DamageType GetDamageType();        
    }
}