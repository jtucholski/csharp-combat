using System;
using csharp_combat.Weapons;
using csharp_combat.Combatants;


namespace csharp_combat.Combatants
{
    public abstract class Fighter : IFightable
    {
        public IStrikable Weapon { get; set; }
        public int Health { get; set; }
        private int DamageModifier { get; set; }
        public DamageType DamageType { get => Weapon.GetDamageType(); }
        public bool IsDead { get => Health <= 0; }



        public Fighter(int health, int damageModifier)
        {
            this.Health = health;
            this.DamageModifier = damageModifier;
        }

        public int DealDamage()
        {
            return Weapon.DealDamge() + DamageModifier;
        }

        public virtual int TakeDamage(int damage, DamageType type)
        {
            Health -= damage;
            return damage;
        }


    }
}