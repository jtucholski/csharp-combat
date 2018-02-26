using System;
using csharp_combat.Weapons;
using csharp_combat.Combatants;


namespace csharp_combat.Combatants
{
    public class Rogue : Fighter
    {
        public Rogue(int health, int damageModifier) : base(health, damageModifier) { }

        public override int TakeDamage(int damage, DamageType type)
        {
            // Rogues can dodge a lot of damage. They dodge all hits over 80
            if (damage <= 20)
            {
                // They take half-damage on anything less than 20
                return base.TakeDamage(damage / 2, type);
            }

            return 0;
        }
    }
}