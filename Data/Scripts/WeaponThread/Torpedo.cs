using static WeaponThread.Session.AmmoShieldBehavior.ShieldType;
using static WeaponThread.Session.AmmoTrajectory.GuidanceType;
using static WeaponThread.Session.HardPointDefinition.Prediction;
using static WeaponThread.Session;
namespace WeaponThread
{   // Don't edit above this line
    partial class Weapons { WeaponDefinition Torpedo => new WeaponDefinition {
    Assignments = new ModelAssignments
    {
        MountPoints = new[]
        {
            MountPoint(subTypeId: "LargeFixedPositionMissileTurret", subPartId: "None"),
        },
        Barrels = Names("muzzle_barrel_001", "muzzle_barrel_002")
    },
    Ui = new UiDefinition
    {
        RateOfFire = Slider(enable: true, min: 1200, max: 3600),
        DamageModifier = Slider(enable: true, min: 0.1, max: 1.1),
        SelectableProjectileColor = true,
    },
        HardPoint = new HardPointDefinition
    { 
        DefinitionId = "Torpedo",
        AmmoMagazineId = "WolfSlug40mm",
        IsTurret = false,
        TurretController = false,
        TrackTargets = false,
        ElevationSpeed = 0.05f,
        RotateSpeed = 0.05f,
        DeviateShotAngle = 0f,
        AimingTolerance = 10f,
        EnergyCost = 0,
        RotateBarrelAxis = 0, // 0 = off, 1 = xAxis, 2 = yAxis, 3 = zAxis
        TargetPrediction = Advanced,
        DelayCeaseFire = 120, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

        Loading = new AmmoLoading
        {
            RateOfFire = 600,
            BarrelsPerShot = 1,
            TrajectilesPerBarrel = 1,
            SkipBarrels = 0,
            ReloadTime = 600,
            DelayUntilFire = 204,
            HeatPerRoF = 1,
            MaxHeat = 180,
            HeatSinkRate = 2,
            ShotsInBurst = 0,
            DelayAfterBurst = 120,
        },
    },
    Ammo = new AmmoDefinition
    {
        DefaultDamage = 20f,
        AreaEffectYield = 10f,
        AreaEffectRadius = 15f,
        DetonateOnEnd = false,
        ProjectileLength = 1f,
        Mass = 150f,
        MaxObjectsHit = 0,
        BackKickForce = 2.5f,

        Trajectory = new AmmoTrajectory
        {
            Guidance = None,
            SmartsFactor = 0.5,
            SmartsTrackingDelay = 1,
            SmartsMaxLateralThrust = 0.5,
            TargetLossDegree = 80,
            TargetLossTime = 0,
            AccelPerSec = 0f,
            DesiredSpeed = 400f,
            MaxTrajectory = 800f,
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
        VisualProbability = 0.5f,
        ShieldHitDraw = true,
        Particles = new ParticleDefinition
        {
            Ammo = new Particle
            {
                Name = "",
                Color = Color(red: 128, green: 0, blue: 0, alpha: 32),
                Offset = Vector(x: 0, y: -1, z: 0),
                Extras = Options(loop: false, restart: false, distance: 5000, duration: 1, scale: 1.25f),
            },
            Hit = new Particle
            {
                Name = "ShipWelderArc",
                Color = Color(red: 255, green: 0, blue: 0, alpha: 1),
                Offset = Vector(x: 0, y: -1, z: 0),
                Extras = Options(loop: false, restart: false, distance: 5000, duration: 1, scale: 1.25f),
            },
            Barrel1 = new Particle
            {
                Name = "", // Smoke_LargeGunShot
                Color = Color(red: 255, green: 0, blue: 0, alpha: 1),
                Offset = Vector(x: 0, y: -1, z: 0),
                Extras = Options(loop: false, restart: false, distance: 50, duration: 6, scale: 1f),
            },
            Barrel2 = new Particle
            {
                Name = "",//Muzzle_Flash_Large
                Color = Color(red: 255, green: 0, blue: 0, alpha: 1),
                Offset = Vector(x: 0, y: -1, z: 0),
                Extras = Options(loop: false, restart: false, distance: 50, duration: 6, scale: 1f),
            },
        },

        Line = new LineDefinition
        {
            Trail = true,
            Material = "ProjectileTrailLine",
            Color = Color(red: 10, green: 10, blue: 10, alpha: 1),
            Width = 0.04f,
            ColorVariance = Random(start: 1, end: 2),
            WidthVariance = Random(start: -0.025f, end: 0.025f),
        },
    },
    Audio = new AudioDefinition
    {
        HardPoint = new AudioHardPointDefinition
        {
            FiringSound = "",
            FiringSoundPerShot = false,
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
