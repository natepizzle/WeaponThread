using VRageMath;
using static WeaponThread.Session.AmmoShieldBehavior.ShieldType;
using static WeaponThread.Session.AmmoTrajectory.GuidanceType;
using static WeaponThread.Session.HardPointDefinition.Prediction;
using static WeaponThread.Session;
namespace WeaponThread
{
    partial class Weapons { WeaponDefinition Missile => new WeaponDefinition {
    HardPoint = new HardPointDefinition
    { // Don't edit above this line
        DefinitionId = "Missile",
        AmmoMagazineId = "TorpAmmo",
        IsTurret = true,
        TurretController = false,
        TrackTargets = true,
        RateOfFire = 60,
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
            new MountPoint {SubtypeId = "PDCTurretLB", SubpartId = "MissileTurretBarrels"},
            new MountPoint {SubtypeId = "PDCTurretSB", SubpartId = "MissileTurretBarrels"},
        },

        Barrels = new[]
        {
            "muzzle_missile_001", "muzzle_missile_002", "muzzle_missile_003",
            "muzzle_missile_004", "muzzle_missile_005", "muzzle_missile_006",
        },

    },
    Ammo = new AmmoDefinition
    {
        DefaultDamage = 0f,
        AreaEffectYield = 10f,
        AreaEffectRadius = 10f,
        DetonateOnEnd = false,
        ProjectileLength = 1f,
        Mass = 150f, // in grams
        Health = 0f,
        BackkickForce = 2.5f,

        Trajectory = new AmmoTrajectory
        {
            Guidance = Smart,
            SmartsFactor = 0.009f,
            TargetLossDegree = 80f,
            AccelPerSec = 30f,
            DesiredSpeed = 240f,
            MaxTrajectory = 3000f,
            SpeedVariance = Random(start: 0, end: 10),
            RangeVariance = Random(start: 0, end: 100),
        },

        ShieldBehavior = new AmmoShieldBehavior
        {
            ShieldDmgMultiplier = 1.1f,
            ShieldDamage = Kinetic,
        },

    },
    Graphics = new GraphicDefinition
    {
        ModelName = "\\Models\\Weapons\\Projectile_Missile.mwm",
        VisualProbability = 1f,
        ShieldHitDraw = true,

        Particles = new ParticleDefinition
        {
            AmmoParticle = "Smoke_Missile",
            AmmoColor = Color(red: 1, green: 1, blue: 1, alpha: 1),
            AmmoOffset = Vector(x: 0, y: 0, z: 0.4), // +Z backward, +Y up, +X right
            AmmoScale = 0.8f,
            HitParticle = "",
            HitColor = Color(red: 0, green: 0, blue: 0, alpha: 0),
            HitScale = 1f,
            Turret1Particle = "",
            Turret1Color = Color(red: 0, green: 0, blue: 0, alpha: 0),
            Turret1Scale = 1f,
            Turret1Restart = false,
            Turret2Particle = "",
            Turret2Color = Color(red: 0, green: 0, blue: 0, alpha: 0),
            Turret2Scale = 1f,
            Turret2Restart = true,
        },

        Line = new LineDefinition
        {
            Trail = false,
            Material = "ProjectileTrailLine",
            Color = Color(red: 10, green: 10, blue: 10, alpha: 1),
            Width = 0.04f,
            RandomizeColor = Random(start: 1, end: 2),
            RandomizeWidth = Random(start: 0, end: 0),
        },
    },
    Audio = new AudioDefinition
    {
        HardPoint = new AudioHardPointDefinition
        {
            FiringSound = "WepShipSmallMissileShot",
            FiringSoundLoop = false,
            FiringRange = 500f,
            FiringVolume = 1f,
            FiringPitchVar = Random(start: 0, end: 0),
            FiringVolumeVar = Random(start: 0, end: 0),
            ReloadSound = "ArcBotSpiderAttackBite",
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
            TravelPitchVar = Random(start: 0, end: 0),
            TravelVolumeVar = Random(start: 0, end: 0),
            HitSound = "",
            HitRange = 450f,
            HitVolume = 1f,
            HitPitchVar = Random(start: 0, end: 0),
            HitVolumeVar = Random(start: 0, end: 0),
        }, // Don't edit below this line
    }, 
};}}