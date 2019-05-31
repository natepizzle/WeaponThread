using System.Collections.Generic;
using VRage.Utils;
using VRageMath;
using static WeaponThread.Session.WeaponDefinition.EffectType;
using static WeaponThread.Session.WeaponDefinition.ShieldType;
using static WeaponThread.Session.WeaponDefinition.GuidanceType;
namespace WeaponThread
{
    partial class Session
    {
        readonly WeaponDefinition[] WeaponDefinitions =
        {
			//Start of your weapon definitions, can have as many WeaponDefinitions as you want.
            //First Weapon part on PDCTurretLB turret
            new WeaponDefinition
            {
                DefinitionId = "LargeGatling",
                MountPoints = new []
                {
                    new KeyValuePair<string, string>("PDCTurretLB", "Boomsticks"),
                },
                Barrels = new []
                {
                    "muzzle_barrel_001", "muzzle_barrel_002", "muzzle_barrel_003",
                    "muzzle_barrel_004", "muzzle_barrel_005", "muzzle_barrel_006"
                },
                // Turret properties
                TurretMode = true,
                TrackTarget = true,
                RotateBarrelAxis = 3, // 0 = off, 1 = xAxis, 2 = yAxis, 3 = zAxis
                RateOfFire = 120,
                BarrelsPerShot = 1,
                SkipBarrels = 0,
                ShotsPerBarrel = 1,
                HeatPerRoF = 1,
                MaxHeat = 180,
                HeatSinkRate = 2,
                MuzzleFlashLifeSpan = 0,
                RotateSpeed = 0.05f,
                FiringSound = "RealWepTurretMissileShot",
                FiringSoundRange = 500f,
                FiringSoundVolume = 10f,

                // Ammo Mag properties
                ReloadTime = 10,
                ReleaseTimeAfterFire = 10f,
                ReloadSound = "cueName",
                ReloadSoundRange = 30f,
                ReloadSoundVolume = 1f,

                //Ammo Properties
                Guidance = Smart,
                DefaultDamage = 100f,
                InitalSpeed = 10f,
                AccelPerSec = 10f,
                DesiredSpeed = 300f,
                MaxTrajectory = 2000f,
                DeviateShotAngle = 1f,
                BackkickForce = 2.5f,
                SpeedVariance = 5f,
                RangeMultiplier = 2.1f,
                AreaEffectYield = 0f,
                AreaEffectRadius = 0f,
                UseRandomizedRange = false,

                // Ammo Visual Audio properties
                ModelName = MyStringId.GetOrCompute("Custom"),
                AmmoTravelSound = "ShipJumpDriveRecharge",
                AmmoTravelSoundRange = 350f,
                AmmoTravelSoundVolume = 5f,
                AmmoHitSound = "RealWepSmallMissileExpl",
                AmmoHitSoundRange = 450f,
                AmmoHitSoundVolume = 10f,
                VisualProbability = 1f,

                ParticleTrail = true,
                // The following are used if ParticleTrail is set to true
                ParticleColor = new Vector4(255, 255, 255, 8),
                Effect = Custom,
                CustomEffect = "ShipWelderArc", //only used if effect is set to "Custom"
                ParticleRadiusMultiplier = 1.5f,

                LineTrail = false,
                // The following are used if Trail is set to true;
                PhysicalMaterial = MyStringId.GetOrCompute("WeaponLaser"), // WeaponLaser, WarpBubble, ProjectileTrailLine
                TrailColor = new Vector4(0, 0, 255, 110f),
                LineLength = 1f,
                LineWidth = 0.025f,

                RealisticDamage = false,
                // If set to realistic DefaultDamage is disabled the 
                // and following values are used, damage equation is: 
                // ((Mass / 2) * (Velocity * Velocity) / 1000) * KeenScaler
                KeenScaler = 0.0125f,
                Mass = 150f,  // in grams
                ThermalDamage = 0, // MegaWatts
                Health = 0f,

                //Shield Behavior
                ShieldHitDraw = true,
                ShieldDmgMultiplier = 1.1f,
                ShieldDamage = Kinetic,
            },

            // Second Weapon part on PDCTurretLB turret
            new WeaponDefinition
            {
                DefinitionId = "LargeMissileTurret",
                MountPoints = new []
                {
                    new KeyValuePair<string, string>("PDCTurretLB", "MissileTurretBarrels"),
                },
                Barrels = new []
                {
                    "muzzle_missile_001", "muzzle_missile_002", "muzzle_missile_003",
                    "muzzle_missile_004", "muzzle_missile_005", "muzzle_missile_006"
                },
                // Turret properties
                TurretMode = false,
                TrackTarget = true,
                RotateBarrelAxis = 0, // 0 = off, 1 = xAxis, 2 = yAxis, 3 = zAxis
                RateOfFire = 600,
                BarrelsPerShot = 1,
                SkipBarrels = 0,
                ShotsPerBarrel = 1,
                HeatPerRoF = 1,
                MaxHeat = 180,
                HeatSinkRate = 2,
                MuzzleFlashLifeSpan = 0,
                RotateSpeed = 1f,
                FiringSound = "",
                FiringSoundRange = 150f,
                FiringSoundVolume = 1f,

                // Ammo Mag properties
                ReloadTime = 10,
                ReleaseTimeAfterFire = 10f,
                ReloadSound = "cueName",
                ReloadSoundRange = 30f,
                ReloadSoundVolume = 1f,

                //Ammo Properties
                Guidance = Smart,
                DefaultDamage = 10f,
                InitalSpeed = 10f,
                AccelPerSec = 10f,
                DesiredSpeed = 30f,
                MaxTrajectory = 800f,
                DeviateShotAngle = 1f,
                BackkickForce = 2.5f,
                SpeedVariance = 5f,
                RangeMultiplier = 2.1f,
                AreaEffectYield = 0f,
                AreaEffectRadius = 0f,
                UseRandomizedRange = false,

                // Ammo Visual Audio properties
                ModelName = MyStringId.GetOrCompute("Custom"),
                AmmoTravelSound = "",
                AmmoTravelSoundRange = 40f,
                AmmoTravelSoundVolume = 1f,
                AmmoHitSound = "",
                AmmoHitSoundRange = 100f,
                AmmoHitSoundVolume = 1f,
                VisualProbability = 1f,

                ParticleTrail = false,
                // The following are used if ParticleTrail is set to true
                ParticleColor = new Vector4(255, 18, 0, 64),
                Effect = Custom,
                CustomEffect = "ShipWelderArc", //only used if effect is set to "Custom"
                ParticleRadiusMultiplier = 0.65f,

                LineTrail = true,
                // The following are used if Trail is set to true;
                PhysicalMaterial = MyStringId.GetOrCompute("WeaponLaser"), // WeaponLaser, WarpBubble, ProjectileTrailLine
                TrailColor = new Vector4(255, 0, 0, 255),
                LineLength = 5f,
                LineWidth = 0.08f,

                RealisticDamage = false,
                // If set to realistic DefaultDamage is disabled the 
                // and following values are used, damage equation is: 
                // ((Mass / 2) * (Velocity * Velocity) / 1000) * KeenScaler
                KeenScaler = 0.0125f,
                Mass = 150f,  // in grams
                ThermalDamage = 0, // MegaWatts
                Health = 0f,

                //Shield Behavior
                ShieldHitDraw = true,
                ShieldDmgMultiplier = 1.1f,
                ShieldDamage = Kinetic,
            },

			// Don't edit below this line.
        };
    }
}
