using System.Collections.Generic;
using static WeaponThread.Session;
namespace WeaponThread
{
    partial class Weapons
    {
        internal Weapons(out WeaponDefinition[] weaponDefinitions)
        {
            // file convention: Name.cs
            // add procedure: Add(Name1, Name2, Name3, etc..);
            // See Example.cs file for weapon property details.
            // Don't edit above this line

            Add(Missile, Torpedo, Gatling);
            
            // Don't edit below this line
            weaponDefinitions = ReturnDefs();
        }

        // Don't edit below
        internal List<WeaponDefinition> Weapon = new List<WeaponDefinition>();
        private void Add(params WeaponDefinition[] defs)
        {
            foreach (var def in defs) Weapon.Add(def);
        }

        private WeaponDefinition[] ReturnDefs()
        {
            var weaponDefinitions = new WeaponDefinition[Weapon.Count];
            for (int i = 0; i < Weapon.Count; i++) weaponDefinitions[i] = Weapon[i];
            Weapon.Clear();
            return weaponDefinitions;
        }
    }
}
