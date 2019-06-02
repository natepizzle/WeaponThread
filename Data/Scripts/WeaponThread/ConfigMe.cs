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
                    RateOfFire = 120,
                    BarrelsPerShot = 1,
                    SkipBarrels = 0,
                    ShotsPerBarrel = 1,
                    HeatPerRoF = 1,
                    MaxHeat = 180,
                    HeatSinkRate = 2,
                    MuzzleFlashLifeSpan = 0,
                    RotateSpeed = 0.05f,
                    ReloadTime = 10,
                    ReleaseTimeAfterFire = 10f,
                    DeviateShotAngle = 1f,
                },
                AmmoDef = new AmmoDefinition
                {
                    Guidance = Smart,
                    ProjectileLength = 1f,
                    DefaultDamage = 100f,
                    InitalSpeed = 10f,
                    AccelPerSec = 10f,
                    DesiredSpeed = 300f,
                    MaxTrajectory = 2000f,
                    BackkickForce = 2.5f,
                    SpeedVariance = 5f,
                    RangeMultiplier = 2.1f,
                    AreaEffectYield = 0f,
                    AreaEffectRadius = 0f,
                    UseRandomizedRange = false,
                    ShieldDmgMultiplier = 1.1f,
                    ShieldDamage = Kinetic,

                    RealisticDamage = false,
                    // If set to realistic DefaultDamage is disabled the 
                    // and following values are used, damage equation is: 
                    // ((Mass / 2) * (Velocity * Velocity) / 1000) * KeenScaler
                    Mass = 150f,  // in grams
                    ThermalDamage = 0, // MegaWatts
                    Health = 0f,
                },
                GraphicDef = new GraphicDefinition
                {
                    ModelName = MyStringId.GetOrCompute("Custom"),
                    VisualProbability = 1f,
                    ParticleTrail = true,
                    ParticleColor = new Vector4(255, 255, 255, 16),
                    Effect = Custom,
                    CustomEffect = "ShipWelderArc", //only used if effect is set to "Custom"
                    ParticleRadiusMultiplier = 1f,

                    ProjectileTrail = false,
                    ProjectileMaterial = MyStringId.GetOrCompute("WeaponLaser"), // WeaponLaser, WarpBubble, ProjectileTrailLine
                    ProjectileColor = new Vector4(0, 0, 255, 110f),
                    ProjectileWidth = 0.025f,
                    ShieldHitDraw = true,
                },
                AudioDef = new AudioDefinition
                {
                    FiringSound = "RealWepTurretMissileShot",
                    FiringSoundRange = 500f,
                    FiringSoundVolume = 5f,
                    ReloadSound = "cueName",
                    ReloadSoundRange = 30f,
                    ReloadSoundVolume = 1f,
                    AmmoTravelSound = "ShipJumpDriveRecharge",
                    AmmoTravelSoundRange = 350f,
                    AmmoTravelSoundVolume = 1f,
                    AmmoHitSound = "RealWepSmallMissileExpl",
                    AmmoHitSoundRange = 450f,
                    AmmoHitSoundVolume = 3f,
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
                    RateOfFire = 300,
                    BarrelsPerShot = 1,
                    SkipBarrels = 0,
                    ShotsPerBarrel = 1,
                    HeatPerRoF = 1,
                    MaxHeat = 180,
                    HeatSinkRate = 2,
                    MuzzleFlashLifeSpan = 0,
                    RotateSpeed = 1f,
                    ReloadTime = 10,
                    ReleaseTimeAfterFire = 10f,
                    DeviateShotAngle = 1f,
                },
                AmmoDef = new AmmoDefinition
                {
                    Guidance = Smart,
                    DefaultDamage = 10f,
                    InitalSpeed = 10f,
                    AccelPerSec = 10f,
                    DesiredSpeed = 150f,
                    MaxTrajectory = 800f,
                    BackkickForce = 2.5f,
                    SpeedVariance = 5f,
                    RangeMultiplier = 2.1f,
                    AreaEffectYield = 0f,
                    AreaEffectRadius = 0f,
                    UseRandomizedRange = false,
                    ProjectileLength = 5f,
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
                    ModelName = MyStringId.GetOrCompute("Custom"),
                    VisualProbability = 1f,
                    ParticleTrail = false,
                    ParticleColor = new Vector4(255, 18, 0, 64),
                    Effect = Custom,
                    CustomEffect = "ShipWelderArc", //only used if effect is set to "Custom"
                    ParticleRadiusMultiplier = 0.65f,
                    ProjectileTrail = true,
                    ProjectileMaterial = MyStringId.GetOrCompute("WeaponLaser"), // WeaponLaser, WarpBubble, ProjectileTrailLine
                    ProjectileColor = new Vector4(255, 0, 0, 255),
                    ProjectileWidth = 0.08f,
                    ShieldHitDraw = true,
                },
                AudioDef = new AudioDefinition
                {
                    FiringSound = "",
                    FiringSoundRange = 150f,
                    FiringSoundVolume = 1f,
                    ReloadSound = "cueName",
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
