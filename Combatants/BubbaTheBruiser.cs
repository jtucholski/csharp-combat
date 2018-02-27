using System;
using csharp_combat.Weapons;

namespace csharp_combat.Combatants
{
    public class BubbaTheBruiser : Fighter
    {
        private const int StartingHealth = 100;
        private const int DamageModifier = 0;

        public BubbaTheBruiser() : base(StartingHealth, DamageModifier)
        {
        }

        public override int TakeDamage(int damage, DamageType type)
        {
            // Bubba Doesn't Like Ice
            if (type == DamageType.Ice)
            {
                damage *= 2;
            }

            return base.TakeDamage(damage, type);
        }
        
        public override string ToString()
        {
            return "Bubba the Bruiser";
        }
    }
}