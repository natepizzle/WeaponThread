using VRageMath;
using static WeaponThread.Session.AmmoShieldBehavior.ShieldType;
using static WeaponThread.Session.AmmoTrajectory.GuidanceType;
using static WeaponThread.Session.HardPointDefinition.Prediction;
using static WeaponThread.Session;
namespace WeaponThread
{
    partial class Weapons { WeaponDefinition Torpedo => new WeaponDefinition {
    HardPoint = new HardPointDefinition
    { // Don't edit above this line
        DefinitionId = "Torpedo",
        AmmoMagazineId = "WolfSlug40mm",
        IsTurret = false,
        TurretController = false,
        TrackTargets = false,
        RateOfFire = 600,
        BarrelsPerShot = 1,
        ShotsPerBarrel = 1,
        SkipBarrels = 0,
        ElevationSpeed = 0.05f,
        RotateSpeed = 0.05f,
        DeviateShotAngle = 0f,
        AimingTolerance = 10f,
        ReloadTime = 600,
        DelayUntilFire = 204,
        HeatPerRoF = 1,
        MaxHeat = 180,
        HeatSinkRate = 2,
        ShotEnergyCost = 0,
        RotateBarrelAxis = 0, // 0 = off, 1 = xAxis, 2 = yAxis, 3 = zAxis
        TargetPrediction = Advanced,

        MountPoints = new[]
        {
            new MountPoint {SubtypeId = "LargeFixedPositionMissileTurret", SubpartId = "None"},
        },

        Barrels = new[]
        {
            "missile_muzzle_001", "missile_muzzle_002",
        },
    },
    Ammo = new AmmoDefinition
    {
        DefaultDamage = 20f,
        AreaEffectYield = 10f,
        AreaEffectRadius = 15f,
        DetonateOnEnd = false,
        ProjectileLength = 1f,
        Mass = 150f,  // in grams
        Health = 0f,
        BackkickForce = 2.5f,

        Trajectory = new AmmoTrajectory
        {
            Guidance = None,
            SmartsFactor = 0.5f,
            TargetLossDegree = 80f,
            AccelPerSec = 0f,
            DesiredSpeed = 400f,
            MaxTrajectory = 800f,
            SpeedVariance = new Randomize { Start = 0, End = 10 },
            RangeVariance = new Randomize { Start = 0, End = 100 },
        },

        ShieldBehavior = new AmmoShieldBehavior
        {
            ShieldDmgMultiplier = 1.1f,
            ShieldDamage = Kinetic,
        },

    },
    Graphics = new GraphicDefinition
    {
        ModelName = "",
        VisualProbability = 0.5f,
        ShieldHitDraw = true,
        Particles = new ParticleDefinition
        {
            AmmoParticle = "",
            AmmoColor = new Vector4(0, 0, 128, 32),
            AmmoOffset = new Vector3D(0, -1, 0),
            AmmoScale = 1f,
            HitParticle = "",
            HitColor = new Vector4(0, 0, 0, 0),
            HitScale = 1f,
            Turret1Particle = "Smoke_LargeGunShot",
            Turret1Color = new Vector4(0, 0, 0, 0),
            Turret1Scale = 1f,
            Turret1Restart = false,
            Turret2Particle = "Muzzle_Flash_Large",
            Turret2Color = new Vector4(0, 0, 0, 0),
            Turret2Scale = 1f,
            Turret2Restart = true,
        },

        Line = new LineDefinition
        {
            Trail = true,
            Material = "ProjectileTrailLine",
            Color = new Vector4(10, 10, 10, 1),
            Width = 0.04f,
            RandomizeColor = new Randomize { Start = 1f, End = 2f },
            RandomizeWidth = new Randomize { Start = 0f, End = 0f },
        },
    },
    Audio = new AudioDefinition
    {
        HardPoint = new AudioHardPointDefinition
        {
            FiringSound = "",
            FiringSoundLoop = false,
            FiringRange = 500f,
            FiringVolume = 1f,
            FiringPitchVar = new Randomize { Start = 0f, End = 0f },
            FiringVolumeVar = new Randomize { Start = 0f, End = 0f },
            ReloadSound = "",
            ReloadRange = 30f,
            ReloadVolume = 1f,
            NoAmmoSound = "",
            TurretRotationSound = "",
        },

        Ammo = new AudioAmmoDefinition
        {
            TravelSound = "",
            TravelRange = 350f,
            TravelVolume = 1f,
            TravelPitchVar = new Randomize { Start = 0, End = 0 },
            TravelVolumeVar = new Randomize { Start = 0, End = 0 },
            HitSound = "",
            HitRange = 450f,
            HitVolume = 1f,
            HitPitchVar = new Randomize { Start = 0, End = 0 },
            HitVolumeVar = new Randomize { Start = 0, End = 0 },
        }, // Don't edit below this line
    }, 
};}}
