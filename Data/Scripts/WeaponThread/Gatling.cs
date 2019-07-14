using static WeaponThread.Session.AmmoShieldBehavior.ShieldType;
using static WeaponThread.Session.AmmoTrajectory.GuidanceType;
using static WeaponThread.Session.HardPointDefinition.Prediction;
using static WeaponThread.Session;
namespace WeaponThread
{   // Don't edit above this line
    partial class Weapons { WeaponDefinition Gatling => new WeaponDefinition {
    Assignments = new ModelAssignments
    {
        MountPoints = new[]
        {
            MountPoint(subTypeId: "PDCTurretLB", subPartId: "Boomsticks"),
            MountPoint(subTypeId: "PDCTurretSB", subPartId: "Boomsticks"),
        },
        Barrels = Names("muzzle_barrel_001", "muzzle_barrel_002", "muzzle_barrel_003", "muzzle_barrel_004", "muzzle_barrel_005", "muzzle_barrel_006")
    },
    Ui = new UiDefinition
    {
        RateOfFire = Slider(enable: true, min: 1200, max: 3600),
        DamageModifier = Slider(enable: true, min: 0.1, max: 1.1),
        SelectableProjectileColor = true,
    },
    HardPoint = new HardPointDefinition
    { 
        DefinitionId = "Gatling",
        AmmoMagazineId = "Blank",
        IsTurret = true,
        TurretController = true,
        TrackTargets = true,
        ElevationSpeed = 0.01f,
        RotateSpeed = 0.01f,
        DeviateShotAngle = 0f,
        AimingTolerance = 4f,
        EnergyCost = 0.00000000001f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
        RotateBarrelAxis = 3, // 0 = off, 1 = xAxis, 2 = yAxis, 3 = zAxis
        TargetPrediction = Advanced, // Off, Basic, Accurate, Advanced
        DelayCeaseFire = 120, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

        Loading = new AmmoLoading
        {
            RateOfFire = 3600,
            BarrelsPerShot = 1,
            TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
            SkipBarrels = 0,
            ReloadTime = 600, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
            DelayUntilFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
            HeatPerRoF = 1,
            MaxHeat = 180,
            HeatSinkRate = 2,
            ShotsInBurst = 0,
            DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
        },
    },
    Ammo = new AmmoDefinition
    {
        DefaultDamage = 5000f,
        AreaEffectYield = 0f,
        AreaEffectRadius = 0f,
        DetonateOnEnd = false,
        ProjectileLength = 1f,
        Mass = 5000f, // in kilograms
        MaxObjectsHit = 2, // 0 = disabled, value determines max objects (and/or blocks) penetrated per hit
        BackKickForce = 0f,

        Trajectory = new AmmoTrajectory
        {
            Guidance = None,
            SmartsFactor = 0.009f,
            SmartsTrackingDelay = 1, // Measured in projectile length units traveled.
            TargetLossDegree = 80f,
            AccelPerSec = 0f,
            DesiredSpeed = 0f,
            MaxTrajectory = 3000f,
            SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
            RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
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
            HitParticle = "ShipWelderArc",
            HitColor = Color(red: 10, green: 10, blue: 172, alpha: 1),
            HitScale = 1.5f,
            Barrel1Particle = "", // Smoke_LargeGunShot
            Barrel1Color = Color(red: 0, green: 0, blue: 0, alpha: 0),
            Barrel1Scale = 1f,
            Barrel1Restart = false,
            Barrel1Duration = 6, // value measured in game ticks, 60 ticks in 1 second.
            Barrel2Particle = "", //Muzzle_Flash_Large
            Barrel2Color = Color(red: 0, green: 0, blue: 0, alpha: 0),
            Barrel2Scale = 1f,
            Barrel2Restart = false,
            Barrel2Duration = 6,
        },

        Line = new LineDefinition
        {
            Trail = true,
            Material = "WeaponLaser", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
            Color = Color(red: 32, green: 32, blue: 40, alpha: 1),
            Width = 0.05f,
            ColorVariance = Random(start: 0.5f, end: 2.5f), // multiply the color by random values within range.
            WidthVariance = Random(start: 0f, end: 0.1f), // adds random value to default width (negatives shrinks width)
        },
    },
    Audio = new AudioDefinition
    {
        HardPoint = new AudioHardPointDefinition
        {
            FiringSound = "", // WepShipGatlingShot
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
