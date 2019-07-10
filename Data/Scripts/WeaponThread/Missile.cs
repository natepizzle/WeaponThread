using static WeaponThread.Session.AmmoShieldBehavior.ShieldType;
using static WeaponThread.Session.AmmoTrajectory.GuidanceType;
using static WeaponThread.Session.HardPointDefinition.Prediction;
using static WeaponThread.Session;
namespace WeaponThread
{   // Don't edit above this line
    partial class Weapons { WeaponDefinition Missile => new WeaponDefinition {
    Assignments = new ModelAssignments
    {
        MountPoints = new[]
        {
            MountPoint(subTypeId: "PDCTurretLB", subPartId: "MissileTurretBarrels"),
            MountPoint(subTypeId: "PDCTurretSB", subPartId: "MissileTurretBarrels"),
        },
        Barrels = Names("muzzle_missile_001", "muzzle_missile_002", "muzzle_missile_003", "muzzle_missile_004", "muzzle_missile_005", "muzzle_missile_006")
    },
    HardPoint = new HardPointDefinition
    { 
        DefinitionId = "Missile",
        AmmoMagazineId = "TorpAmmo",
        IsTurret = true,
        TurretController = false,
        TrackTargets = true,
        ElevationSpeed = 0.05f,
        RotateSpeed = 0.05f,
        DeviateShotAngle = 0f,
        AimingTolerance = 10f,
        EnergyCost = 0,
        RotateBarrelAxis = 0, 
        TargetPrediction = Advanced,
        DelayCeaseFire = 120, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

        Loading = new AmmoLoading
        {
            RateOfFire = 60,
            BarrelsPerShot = 1,
            TrajectilesPerBarrel = 1,
            SkipBarrels = 0,
            ReloadTime = 600,
            DelayUntilFire = 204,
            HeatPerRoF = 1,
            MaxHeat = 180,
            HeatSinkRate = 2,
            ShotsInBurst = 4,
            DelayAfterBurst = 240,
        },
    },
    Ammo = new AmmoDefinition
    {
        DefaultDamage = 100f,
        AreaEffectYield = 100f,
        AreaEffectRadius = 50f,
        DetonateOnEnd = false,
        ProjectileLength = 1f,
        Mass = 50000f, 
        Health = 0f,
        BackKickForce = 2.5f,

        Trajectory = new AmmoTrajectory
        {
            Guidance = Smart,
            SmartsFactor = 0.01f,
            SmartsTrackingDelay = 1,
            TargetLossDegree = 80f,
            AccelPerSec = 60f,
            DesiredSpeed = 350f,
            MaxTrajectory = 5000f,
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
            Barrel1Particle = "",
            Barrel1Color = Color(red: 0, green: 0, blue: 0, alpha: 0),
            Barrel1Scale = 1f,
            Barrel1Restart = false,
            Barrel1Duration = 30,
            Barrel2Particle = "",
            Barrel2Color = Color(red: 0, green: 0, blue: 0, alpha: 0),
            Barrel2Scale = 1f,
            Barrel2Restart = true,
            Barrel2Duration = 30,
        },

        Line = new LineDefinition
        {
            Trail = false,
            Material = "ProjectileTrailLine",
            Color = Color(red: 10, green: 10, blue: 10, alpha: 1),
            Width = 0.04f,
            ColorVariance = Random(start: 1, end: 2),
            WidthVariance = Random(start: 0, end: 0),
        },
    },
    Audio = new AudioDefinition
    {
        HardPoint = new AudioHardPointDefinition
        {
            FiringSound = "WepShipSmallMissileShot",
            FiringSoundPerShot = true,
            ReloadSound = "",
            NoAmmoSound = "",
            HardPointRotationSound = "",
            BarrelRotationSound = "",
        },

        Ammo = new AudioAmmoDefinition
        {
            TravelSound = "",
            HitSound = "",
        }, // Don't edit below this line
    }, 
};}}