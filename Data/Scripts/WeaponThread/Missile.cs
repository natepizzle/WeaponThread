using static WeaponThread.Session.ShieldDefinition.ShieldType;
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
    Ui = new UiDefinition
    {
        RateOfFire = Slider(enable: true, min: 1200, max: 3600),
        DamageModifier = Slider(enable: true, min: 0.1, max: 1.1),
        SelectableProjectileColor = true,
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
        AimingTolerance = 180f,
        EnergyCost = 0,
        RotateBarrelAxis = 0, 
        TargetPrediction = Advanced,
        DelayCeaseFire = 120, 

        Loading = new AmmoLoading
        {
            RateOfFire = 60,
            BarrelsPerShot = 1,
            TrajectilesPerBarrel = 1,
            SkipBarrels = 0,
            ReloadTime = 300,
            DelayUntilFire = 0,
            HeatPerRoF = 1,
            MaxHeat = 180,
            HeatSinkRate = 2,
            ShotsInBurst = 128,
            DelayAfterBurst = 99999999,
        },
    },
    DamageScales = new DamageScaleDefinition
    {
        MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
        DamageVoxels = false, // true = voxels are vulnerable to this weapon

        // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
        Characters = -1f,
        Grids = Size(largeGridModifier: -1f, smallGridModifier: -1f),
        Armor = Modifiers(armor: -1f, light: -1f, heavy: -1f, nonArmor: -1f),
        Shields = Modulation(modifier: -1f, type: Kinetic), // Types: Kinetic, Energy, Emp or Bypass

        // ignoreOthers will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
        Custom = Scale(false),
    },
    Ammo = new AmmoDefinition
    {
        DefaultDamage = 9999999f,
        AreaEffectYield = 0f,
        AreaEffectRadius = 0f,
        DetonateOnEnd = true,
        Mass = 1000f,
        Health = 0, 
        MaxObjectsHit = 0,
        BackKickForce = 2.5f,

        Trajectory = new AmmoTrajectory
        {
            Guidance = Smart,
            SmartsFactor = 1f,
            SmartsTrackingDelay = 1,
            SmartsMaxLateralThrust = 0.5,
            TargetLossDegree = 80f,
            TargetLossTime = 200,
            AccelPerSec = 20f,
            DesiredSpeed = 200f,
            MaxTrajectory = 500000f,
            SpeedVariance = Random(start: 0, end: 0),
            RangeVariance = Random(start: 0, end: 0),
        },
    },
    Graphics = new GraphicDefinition
    {
        ModelName = "\\Models\\Weapons\\Projectile_Missile.mwm", 
        VisualProbability = 1f,
        ShieldHitDraw = true,
        Particles = new ParticleDefinition
        {
            Ammo = new Particle
            {
                Name = "ShipWelderArc",
                Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                Offset = Vector(x: 0, y: 0, z: 0.4),
                Extras = Options(loop: false, restart: false, distance: 5000, duration: 1, scale: 0.8f),
            },
            Hit = new Particle
            {
                Name = "ShipWelderArc",
                Color = Color(red: 10, green: 10, blue: 255, alpha: 1),
                Offset = Vector(x: 0, y: 0, z: 0),
                Extras = Options(loop: false, restart: false, distance: 5000, duration: 1, scale: 1.25f),
            },
            Barrel1 = new Particle
            {
                Name = "", 
                Color = Color(red: 255, green: 0, blue: 0, alpha: 1),
                Offset = Vector(x: 0, y: -1, z: 0),
                Extras = Options(loop: false, restart: false, distance: 50, duration: 6, scale: 1f),
            },
            Barrel2 = new Particle
            {
                Name = "",
                Color = Color(red: 255, green: 0, blue: 0, alpha: 1),
                Offset = Vector(x: 0, y: -1, z: 0),
                Extras = Options(loop: false, restart: false, distance: 50, duration: 6, scale: 1f),
            },
        },

        Line = new LineDefinition
        {
            Trail = false,
            Material = "ProjectileTrailLine",
            Color = Color(red: 6, green: 6, blue: 6, alpha: 1),
            Length = 20f,
            Width = 0.1f,
            ColorVariance = Random(start: 1, end: 3),
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