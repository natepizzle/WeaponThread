using System;
using System.Collections.Generic;
using VRageMath;

namespace WeaponThread
{
    partial class Weapons
    {
        internal List<Session.WeaponDefinition> Weapon = new List<Session.WeaponDefinition>();
        internal void ConfigFiles(params Session.WeaponDefinition[] defs)
        {
            foreach (var def in defs) Weapon.Add(def);
        }

        internal Session.WeaponDefinition[] ReturnDefs()
        {
            var weaponDefinitions = new Session.WeaponDefinition[Weapon.Count];
            for (int i = 0; i < Weapon.Count; i++) weaponDefinitions[i] = Weapon[i];
            Weapon.Clear();
            return weaponDefinitions;
        }

        internal Session.Randomize Random(float start, float end)
        {
            return new Session.Randomize { Start = start, End = end };
        }

        internal Vector4 Color(float red, float green, float blue, float alpha)
        {
            return new Vector4(red, green, blue, alpha);
        }

        internal Vector3D Vector(double x, double y, double z)
        {
            return new Vector3D(x, y, z);
        }

        internal Session.MountPoint MountPoint(string subTypeId, string subPartId)
        {
            return new Session.MountPoint { SubtypeId = subTypeId, SubpartId = subPartId };
        }

        internal string[] Names(params string[] names)
        {
            return names;
        }
    }
}
