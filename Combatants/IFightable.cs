using System;
using csharp_combat.Weapons;

namespace csharp_combat.Combatants
{
    /**
    * Fightable
    * 
    * Defines a fighter's methods used in the FightingPit. A fighter is expected to have
    * health that will dwindle as they takeDamage(). They are given a weapon at the start
    * and their dealDamage() would, in theory, use that weapon to deal damage.
    */
    public interface IFightable
    {
        /**
        Calculate how much damage a strike from this IFightable will deal and return it.
        */
        int DealDamage();

        /*
        Return how much health this IFightable currently has. 
         */
        int Health { get; }

        /**
        Apply this much damage to the IFightable. It may take all or some of the damage depending
        on how they take damage and what type of damage it is.
         */
        int TakeDamage(int damage, DamageType type);

        /*
        Gets the type of damage this IFightable currently deals. It could be from the weapon
        or some other means.
         */
        DamageType DamageType { get; }

        /**
        Is the IFightable out of the fight?
         */
        bool IsDead { get; }

        /**
        Assign or get the IFightable's weapon.
         */
        IStrikable Weapon { get; set; }        
    }
}
