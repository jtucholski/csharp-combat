using csharp_combat.Weapons;
using System;

namespace csharp_combat.Combatants
{
    public class Link : Rogue
    {
        public Link() : base (30, 3) { }

        public override string ToString()
        {
            return "Link the Elf";
        }
    }
}
