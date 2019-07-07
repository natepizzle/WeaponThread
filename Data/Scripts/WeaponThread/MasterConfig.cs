using System.Collections.Generic;
using static WeaponThread.Session;
namespace WeaponThread
{
    partial class Weapons
    {
        internal Weapons(ref WeaponDefinition[] weaponDefinitions)
        {
            // file convention Name.cs
            // call method Name();
            // See Example.cs for details.
            // Add each of your WeaponName entries below

            Gatling();
            Missile();
            Torpedo();
            
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
