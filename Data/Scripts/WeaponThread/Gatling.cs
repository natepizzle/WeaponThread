using VRageMath;
using static WeaponThread.Session.AmmoShieldBehavior.ShieldType;
using static WeaponThread.Session.AmmoTrajectory.GuidanceType;
using static WeaponThread.Session.HardPointDefinition.Prediction;
using static WeaponThread.Session;
namespace WeaponThread
{
    partial class Weapons { WeaponDefinition Gatling => new WeaponDefinition {
    HardPoint = new HardPointDefinition
    { // Don't edit above this line
        DefinitionId = "Gatling",
        AmmoMagazineId = "Blank",
        IsTurret = true,
        TurretController = true,
        TrackTargets = true,
        RateOfFire = 300,
        BarrelsPerShot = 1,
        ShotsPerBarrel = 1,
        SkipBarrels = 0,
        ElevationSpeed = 0.05f,
        RotateSpeed = 0.05f,
        DeviateShotAngle = 0f,
        AimingTolerance = 4f,
        ReloadTime = 600, // Measured in game ticks (10 = 100ms, 60 = 1 seconds, etc..).
        DelayUntilFire = 204, // Measured in game ticks (10 = 100ms, 60 = 1 seconds, etc..).
        HeatPerRoF = 1,
        MaxHeat = 180,
        HeatSinkRate = 2,
        ShotEnergyCost = 0,
        RotateBarrelAxis = 3, // 0 = off, 1 = xAxis, 2 = yAxis, 3 = zAxis
        TargetPrediction = Advanced, // Off, Basic, Accurate, Advanced

        MountPoints = new[]
        {
            new MountPoint {SubtypeId = "PDCTurretLB", SubpartId = "Boomsticks"},
            new MountPoint {SubtypeId = "PDCTurretSB", SubpartId = "Boomsticks"},
        },

        Barrels = new[]
        {
            "muzzle_barrel_001", "muzzle_barrel_002", "muzzle_barrel_003",
            "muzzle_barrel_004", "muzzle_barrel_005", "muzzle_barrel_006"
        },

    },
    Ammo = new AmmoDefinition
    {
        DefaultDamage = 0f,
        AreaEffectYield = 0f,
        AreaEffectRadius = 0f,
        DetonateOnEnd = false,
        ProjectileLength = 8f,
        Mass = 150f, // in grams
        Health = 0f,
        BackkickForce = 2.5f,

        Trajectory = new AmmoTrajectory
        {
            Guidance = None,
            SmartsFactor = 0.009f,
            TargetLossDegree = 80f,
            AccelPerSec = 0f,
            DesiredSpeed = 300f,
            MaxTrajectory = 1000f,
            SpeedVariance = new Randomize {Start = 0, End = 10},
            RangeVariance = new Randomize {Start = 0, End = 100},
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
        VisualProbability = 1f,
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
            Color = new Vector4(32, 32, 32, 1),
            Width = 0.04f,
            RandomizeColor = new Randomize {Start = 1f, End = 2f},
            RandomizeWidth = new Randomize {Start = 0f, End = 0f},
        },
    },
    Audio = new AudioDefinition
    {
        HardPoint = new AudioHardPointDefinition
        {
            FiringSound = "ShipJumpDriveCharging",
            FiringSoundLoop = true,
            FiringRange = 500f,
            FiringVolume = 1f,
            FiringPitchVar = new Randomize {Start = 0f, End = 0f},
            FiringVolumeVar = new Randomize {Start = 0f, End = 0f},
            ReloadSound = "",
            ReloadRange = 30f,
            ReloadVolume = 1f,
            NoAmmoSound = "",
            TurretRotationSound = "ArcWepTurretGatlingRotate",
        },

        Ammo = new AudioAmmoDefinition
        {
            TravelSound = "",
            TravelRange = 350f,
            TravelVolume = 1f,
            TravelPitchVar = new Randomize {Start = 0, End = 0},
            TravelVolumeVar = new Randomize {Start = 0, End = 0},
            HitSound = "",
            HitRange = 450f,
            HitVolume = 1f,
            HitPitchVar = new Randomize {Start = 0, End = 0},
            HitVolumeVar = new Randomize {Start = 0, End = 0},
        }, // Don't edit below this line
    },
};}}
