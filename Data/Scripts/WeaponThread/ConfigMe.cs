using System.Collections.Generic;
using VRage.Utils;
using VRageMath;
using static WeaponThread.Session.GraphicDefinition.EffectType;
using static WeaponThread.Session.AmmoDefinition.ShieldType;
using static WeaponThread.Session.AmmoDefinition.GuidanceType;
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
                TurretDef = new TurretDefinition
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
                    TurretMode = true,
                    TrackTarget = true,
                    RotateBarrelAxis = 3, // 0 = off, 1 = xAxis, 2 = yAxis, 3 = zAxis
                    RateOfFire = 180,
                    BarrelsPerShot = 3,
                    SkipBarrels = 3,
                    ShotsPerBarrel = 1,
                    HeatPerRoF = 1,
                    MaxHeat = 180,
                    HeatSinkRate = 2,
                    MuzzleFlashLifeSpan = 0,
                    RotateSpeed = 0.05f,
                    ReloadTime = 10,
                    ReleaseTimeAfterFire = 10f,
                    DeviateShotAngle = 0.001f,
                },
                AmmoDef = new AmmoDefinition
                {
                    Guidance = None,
                    DefaultDamage = 1f,
                    InitalSpeed = 0f,
                    AccelPerSec = 0f,
                    DesiredSpeed = 150f,
                    MaxTrajectory = 2500f,
                    BackkickForce = 2.5f,
                    SpeedVariance = 5f,
                    RangeMultiplier = 2.1f,
                    AreaEffectYield = 1f,
                    AreaEffectRadius = 40f,
					DetonateOnEnd = false,
                    UseRandomizedRange = false,
                    ProjectileLength = 7f,
                    RealisticDamage = false,
                    // If set to realistic DefaultDamage is disabled the 
                    // and following values are used, damage equation is: 
                    // ((Mass / 2) * (Velocity * Velocity) / 1000) * KeenScaler
                    Mass = 150f,  // in grams
                    ThermalDamage = 0, // MegaWatts
                    Health = 0f,
                    ShieldDmgMultiplier = 1.1f,
                    ShieldDamage = Kinetic,
                },
                GraphicDef = new GraphicDefinition
                {
                    ModelName = "",
                    VisualProbability = 1f,
                    ParticleTrail = false,
                    ParticleColor = new Vector4(0, 0, 255, 32),
                    Effect = Custom,
                    CustomEffect = "ShipWelderArc", //only used if effect is set to "Custom"
                    ParticleRadiusMultiplier = 1f,

                    ProjectileTrail = true,
                    ProjectileMaterial = MyStringId.GetOrCompute("WeaponLaser"), // WeaponLaser, WarpBubble, ProjectileTrailLine
                    ProjectileColor = new Vector4(0, 0, 255, 32),
                    ProjectileWidth = 0.05f,
                    ShieldHitDraw = true,
                },
                AudioDef = new AudioDefinition
                {
                    FiringSound = "",
                    FiringSoundRange = 500f,
                    FiringSoundVolume = 1f,
                    ReloadSound = "",
                    ReloadSoundRange = 30f,
                    ReloadSoundVolume = 1f,
                    AmmoTravelSound = "",
                    AmmoTravelSoundRange = 350f,
                    AmmoTravelSoundVolume = 1f,
                    AmmoHitSound = "",
                    AmmoHitSoundRange = 450f,
                    AmmoHitSoundVolume = 1f,
                },
            },

            // Second Weapon part on PDCTurretLB turret
            new WeaponDefinition
            {
                TurretDef = new TurretDefinition
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
                    TurretMode = false,
                    TrackTarget = true,
                    RotateBarrelAxis = 0, // 0 = off, 1 = xAxis, 2 = yAxis, 3 = zAxis
                    RateOfFire = 3600,
                    BarrelsPerShot = 6,
                    SkipBarrels = 0,
                    ShotsPerBarrel = 1,
                    HeatPerRoF = 1,
                    MaxHeat = 180,
                    HeatSinkRate = 2,
                    MuzzleFlashLifeSpan = 0,
                    RotateSpeed = 1f,
                    ReloadTime = 10,
                    ReleaseTimeAfterFire = 10f,
                    DeviateShotAngle = 0.001f,
                },
                AmmoDef = new AmmoDefinition
                {
                    Guidance = None,
                    DefaultDamage = 1f,
                    InitalSpeed = 0f,
                    AccelPerSec = 0f,
                    DesiredSpeed = 0f,
                    MaxTrajectory = 0f,
                    BackkickForce = 2.5f,
                    SpeedVariance = 5f,
                    RangeMultiplier = 2.1f,
                    AreaEffectYield = 0f,
                    AreaEffectRadius = 0f,
					DetonateOnEnd = false,
                    UseRandomizedRange = false,
                    ProjectileLength = 2500f,
                    RealisticDamage = false,
                    // If set to realistic DefaultDamage is disabled the 
                    // and following values are used, damage equation is: 
                    // ((Mass / 2) * (Velocity * Velocity) / 1000) * KeenScaler
                    Mass = 150f,  // in grams
                    ThermalDamage = 0, // MegaWatts
                    Health = 0f,
                    ShieldDmgMultiplier = 1.1f,
                    ShieldDamage = Kinetic,
                },
                GraphicDef = new GraphicDefinition
                {
                    ModelName = "",
                    VisualProbability = 1f,
                    ParticleTrail = false,
                    ParticleColor = new Vector4(255, 12, 0, 32),
                    Effect = Custom,
                    CustomEffect = "ShipWelderArc", //only used if effect is set to "Custom"
                    ParticleRadiusMultiplier = 1f,

                    ProjectileTrail = true,
                    ProjectileMaterial = MyStringId.GetOrCompute("WeaponLaser"), // WeaponLaser, WarpBubble, ProjectileTrailLine
                    ProjectileColor = new Vector4(255, 0, 0, 255),
                    ProjectileWidth = 0.05f,
                    ShieldHitDraw = true,
                },
                AudioDef = new AudioDefinition
                {
                    FiringSound = "",
                    FiringSoundRange = 150f,
                    FiringSoundVolume = 1f,
                    ReloadSound = "",
                    ReloadSoundRange = 30f,
                    ReloadSoundVolume = 1f,
                    AmmoTravelSound = "",
                    AmmoTravelSoundRange = 30f,
                    AmmoTravelSoundVolume = 1f,
                    AmmoHitSound = "",
                    AmmoHitSoundRange = 30f,
                    AmmoHitSoundVolume = 1f,
                },
            },
			// Don't edit below this line.
        };
    }
}
