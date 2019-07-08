using static WeaponThread.Session.AmmoShieldBehavior.ShieldType;
using static WeaponThread.Session.AmmoTrajectory.GuidanceType;
using static WeaponThread.Session.HardPointDefinition.Prediction;
using static WeaponThread.Session;
namespace WeaponThread
{   // Don't edit above this line
    partial class Weapons { WeaponDefinition Gatling => new WeaponDefinition {
    HardPoint = new HardPointDefinition
    { 
        DefinitionId = "Gatling",
        AmmoMagazineId = "Blank",
        IsTurret = true,
        TurretController = true,
        TrackTargets = true,
        RateOfFire = 150,
        BarrelsPerShot = 2,
        ShotsPerBarrel = 1,
        SkipBarrels = 0,
        ElevationSpeed = 0.05f,
        RotateSpeed = 0.05f,
        DeviateShotAngle = 2f,
        AimingTolerance = 4f,
        ReloadTime = 600, // Measured in game ticks (10 = 100ms, 60 = 1 seconds, etc..).
        DelayUntilFire = 0, // Measured in game ticks (10 = 100ms, 60 = 1 seconds, etc..).
        HeatPerRoF = 1,
        MaxHeat = 180,
        HeatSinkRate = 2,
        EnergyCost = 0.0001f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
        RotateBarrelAxis = 3, // 0 = off, 1 = xAxis, 2 = yAxis, 3 = zAxis
        TargetPrediction = Advanced, // Off, Basic, Accurate, Advanced

        MountPoints = new[]
        {
            MountPoint(subTypeId: "PDCTurretLB", subPartId: "Boomsticks"),
            MountPoint(subTypeId: "PDCTurretSB", subPartId: "Boomsticks"),
        },

        Barrels = Names("muzzle_barrel_001", "muzzle_barrel_002", "muzzle_barrel_003", "muzzle_barrel_004", "muzzle_barrel_005", "muzzle_barrel_006")
    },
    Ammo = new AmmoDefinition
    {
        DefaultDamage = 100f,
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
            DesiredSpeed = 200f,
            MaxTrajectory = 1000f,
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
        ModelName = "",
        VisualProbability = 1f,
        ShieldHitDraw = true,
        Particles = new ParticleDefinition
        {
            AmmoParticle = "",
            AmmoColor = Color(red: 0, green: 0, blue: 128, alpha: 32),
            AmmoOffset = Vector(x: 0, y: -1, z: 0),
            AmmoScale = 1f,
            HitParticle = "",
            HitColor = Color(red: 0, green: 0, blue: 0, alpha: 0),
            HitScale = 1f,
            Barrel1Particle = "Smoke_LargeGunShot",
            Barrel1Color = Color(red: 0, green: 0, blue: 0, alpha: 0),
            Barrel1Scale = 1f,
            Barrel1Restart = false,
            Barrel1Duration = 10, // value measured in game ticks, 60 ticks in 1 second.
            Barrel2Particle = "Muzzle_Flash_Large",
            Barrel2Color = Color(red: 0, green: 0, blue: 0, alpha: 0),
            Barrel2Scale = 1f,
            Barrel2Restart = true,
            Barrel2Duration = 10,
        },

        Line = new LineDefinition
        {
            Trail = true,
            Material = "ProjectileTrailLine",
            Color = Color(red: 32, green: 32, blue: 32, alpha: 1),
            Width = 0.04f,
            RandomizeColor = Random(start: 1, end: 2),
            RandomizeWidth = Random(start: 0, end: 0),
        },
    },
    Audio = new AudioDefinition
    {
        HardPoint = new AudioHardPointDefinition
        {
            FiringSound = "WepShipGatlingShot",
            FiringSoundPerShot = true,
            ReloadSound = "",
            NoAmmoSound = "",
            HardPointRotationSound = "WepTurretGatlingRotate",
            BarrelRotationSound = "WepShipGatlingRotation",
        },

        Ammo = new AudioAmmoDefinition
        {
            TravelSound = "",
            HitSound = "",
        }, // Don't edit below this line
    },
};}}
