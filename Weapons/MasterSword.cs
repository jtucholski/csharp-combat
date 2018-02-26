using System;

namespace csharp_combat.Weapons
{
    public class MasterSword : Sword
    {
        public override DamageType GetDamageType()
        {
            return DamageType.Slashing;
        }
        
        public override string ToString()
        {
            return "The Master Sword";
        }

        public MasterSword() : base(8, 2) { }
    }
}