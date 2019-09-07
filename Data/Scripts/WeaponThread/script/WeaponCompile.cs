﻿using System.Collections.Generic;
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

        internal Session.ObjectsHit Options(int maxObjectsHit, bool countBlocks)
        {
            return new Session.ObjectsHit { MaxObjectsHit = maxObjectsHit, CountBlocks = countBlocks };
        }

        internal Session.Shrapnel Options(float baseDamage, int fragments, float maxTrajectory, bool noAudioVisual, bool noGuidance, Session.Shrapnel.ShrapnelShape shape)
        {
            return new Session.Shrapnel { BaseDamage = baseDamage, Fragments = fragments, MaxTrajectory = maxTrajectory, NoAudioVisual = noAudioVisual, NoGuidance = noGuidance, Shape = shape};
        }

        internal Session.HeatingEmissive Options(bool enable)
        {
            return new Session.HeatingEmissive { Enable = enable};
        }

        internal Session.FiringEmissive Options(bool enable, int stages, Vector4 color)
        {
            return new Session.FiringEmissive { Enable = enable, Color = color };
        }

        internal Session.TrackingEmissive Options(bool enable, Vector4 color)
        {
            return new Session.TrackingEmissive { Enable = enable, Color = color };
        }

        internal Session.ReloadingEmissive Options(bool enable, Vector4 color, bool pulse)
        {
            return new Session.ReloadingEmissive { Enable = enable, Color = color };
        }

        internal Session.CustomScalesDefinition SubTypeIds(bool ignoreOthers, params Session.CustomBlocksDefinition[] customDefScale)
        {
            return new Session.CustomScalesDefinition {IgnoreAllOthers = ignoreOthers, Types = customDefScale};
        }

        internal Session.ArmorDefinition Options(float armor, float light, float heavy, float nonArmor)
        {
            return new Session.ArmorDefinition { Armor = armor, Light = light, Heavy = heavy, NonArmor = nonArmor };
        }

        internal Session.OffsetEffect Options(double maxOffset, double minLength, double maxLength)
        {
            return new Session.OffsetEffect { MaxOffset = maxOffset, MinLength = minLength, MaxLength = maxLength};
        }

        internal Session.ShieldDefinition Options(float modifier, ShieldType type)
        {
            return new Session.ShieldDefinition { Modifier = modifier, Type = type };
        }

        internal Session.ShapeDefinition Options(Session.ShapeDefinition.Shapes shape, double diameter)
        {
            return new Session.ShapeDefinition { Shape = shape, Diameter = diameter };
        }

        internal Session.Pulse Options(int interval, int pulseChance)
        {
            return new Session.Pulse { Interval = interval, PulseChance = pulseChance };
        }

        internal Session.EwarFields Options(int duration, bool stackDuration, bool depletable)
        {
            return new Session.EwarFields { Duration = duration, StackDuration = stackDuration, Depletable = depletable};
        }

        internal Session.CustomBlocksDefinition Block(string subTypeId, float modifier)
        {
            return new Session.CustomBlocksDefinition { SubTypeId = subTypeId, Modifier = modifier };
        }

        internal Session.TargetingDefinition.BlockTypes[] Priority(params Session.TargetingDefinition.BlockTypes[] systems)
        {
            return systems;
        }

        internal Session.TargetingDefinition.Threat[] Valid(params Session.TargetingDefinition.Threat[] threats)
        {
            return threats;
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

        internal Session.MountPoint MountPoint(string subTypeId, string aimPartId, string muzzlePartId)
        {
            return new Session.MountPoint { SubtypeId = subTypeId, AimPartId = aimPartId, MuzzlePartId = muzzlePartId};
        }

        internal string[] Names(params string[] names)
        {
            return names;
        }
    }
}
