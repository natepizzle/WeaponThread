using System.Collections.Generic;
using VRageMath;
using static WeaponThread.Session.ShieldDefinition;

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

        internal Session.ParticleOptions Options(bool loop, bool restart, float distance, float duration, float scale)
        {
            return new Session.ParticleOptions
            {
                Loop = loop,
                Restart = restart,
                MaxDistance = distance,
                MaxDuration = duration,
                Scale = scale, 
            };
        }

        internal Session.Detonate Options(bool detonateOnEnd, bool armOnlyOnHit, float detonationDamage, float detonationRadius)
        {
            return new Session.Detonate
            {
                DetonateOnEnd = detonateOnEnd,
                ArmOnlyOnHit = armOnlyOnHit,
                DetonationDamage = detonationDamage,
                DetonationRadius = detonationRadius,
            };
        }

        internal Session.Explosion Options(bool noVisuals, bool noSound, float scale, string customParticle, string customSound)
        {
            return new Session.Explosion
            {
                NoVisuals = noVisuals,
                NoSound = noSound,
                Scale = scale,
                CustomParticle = customParticle,
                CustomSound = customSound,
            };
        }

        internal Session.GridSizeDefinition Options(float largeGridModifier, float smallGridModifier)
        {
            return new Session.GridSizeDefinition { Large = largeGridModifier, Small = smallGridModifier };
        }

        internal Session.FakeBarrels Options(bool enable, bool converge)
        {
            return new Session.FakeBarrels { Enable = enable, Converge = converge };
        }

        internal Session.ObjectsHit Options(int maxObjectsHit, bool countBlocks)
        {
            return new Session.ObjectsHit { MaxObjectsHit = maxObjectsHit, CountBlocks = countBlocks };
        }

        internal Session.CustomScalesDefinition Options(bool ignoreOthers, params Session.CustomBlocksDefinition[] customDefScale)
        {
            return new Session.CustomScalesDefinition {IgnoreAllOthers = ignoreOthers, Types = customDefScale};
        }

        internal Session.ArmorDefinition Options(float armor, float light, float heavy, float nonArmor)
        {
            return new Session.ArmorDefinition { Armor = armor, Light = light, Heavy = heavy, NonArmor = nonArmor };
        }

        internal Session.ShieldDefinition Options(float modifier, ShieldType type)
        {
            return new Session.ShieldDefinition { Modifier = modifier, Type = type };
        }

        internal Session.CustomBlocksDefinition Block(string subTypeId, float modifier)
        {
            return new Session.CustomBlocksDefinition { SubTypeId = subTypeId, Modifier = modifier };
        }

        internal Session.SubSystemDefinition.BlockTypes[] Priority(params Session.SubSystemDefinition.BlockTypes[] systems)
        {
            return systems;
        }

        internal Session.Slider Slider(bool enable, double min, double max)
        {
            return new Session.Slider { Enable = enable, Min = min, Max = max };
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
