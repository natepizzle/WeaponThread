using System.Collections.Generic;
using static WeaponThread.Session;
namespace WeaponThread
{
    partial class Weapons
    {
        internal Weapons(ref WeaponDefinition[] weaponDefinitions)
        {
            // file convention: Name.cs
            // add procedure: Weapon.Add(Name);
            // See Example.cs file for weapon property details.
            // Add each of your WeaponName entries below
            //
            // Don't edit above this line

            Weapon.Add(Gatling);
            Weapon.Add(Missile);
            Weapon.Add(Torpedo);
            
            //
            // Don't edit below this line
            //
            weaponDefinitions = new WeaponDefinition[Weapon.Count];
            for (int i = 0; i < Weapon.Count; i++) weaponDefinitions[i] = Weapon[i];
            Weapon.Clear();
        }

        internal List<WeaponDefinition> Weapon = new List<WeaponDefinition>();
    }
}
