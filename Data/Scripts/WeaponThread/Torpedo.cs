using static WeaponThread.Session.ShieldDefinition.ShieldType;
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
        RotateBarrelAxis = 0, 
        TargetPrediction = Advanced,
        DelayCeaseFire = 120, 

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
    DamageScales = new DamageScaleDefinition
    {
        MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
        DamageVoxels = false, // true = voxels are vulnerable to this weapon

        // modifier values: -1 = disabled (higher performance), 0 = no damage , 0.01 = 1% damage, 2 = 200% damage.
        Characters = -1f,
        Grids = Size(largeGridModifier: -1f, smallGridModifier: -1f),
        Armor = Modifiers(armor: -1f, light: -1f, heavy: -1f, nonArmor: -1f),
        Shields = Modulation(modifier: -1f, type: Kinetic), // Types: Kinetic, Energy, Emp or Bypass

        // ignoreOthers will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
        Custom = Scale(false),
    },
    Ammo = new AmmoDefinition
    {
        DefaultDamage = 20f,
        AreaEffectYield = 10f,
        AreaEffectRadius = 15f,
        DetonateOnEnd = false,
        Mass = 150f,
        Health = 0, 
        MaxObjectsHit = 0,
        BackKickForce = 2.5f,

        Trajectory = new AmmoTrajectory
        {
            Guidance = None, // None (no tracking or guidance), Smart (guidance enabled), TravelTo (for flak behavior)
            TargetLossDegree = 80,
            TargetLossTime = 0,
            AccelPerSec = 0f,
            DesiredSpeed = 400f,
            MaxTrajectory = 800f,
            SpeedVariance = Random(start: 0, end: 10),
            RangeVariance = Random(start: 0, end: 100),
            Smarts = new Smarts
            {
                Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                Aggressiveness = 1f, // controls how responsive tracking is.
                MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                TrackingDelay = 1, // Measured in line length units traveled.
                MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                TopTargets = 4, // 0 = unlimited, max number of targets to pick from
                TopBlocks = 4, // 0 = unlimited, max number of blocks to pick from
                OverideTarget = false, // when set to true ammo picks its own target, does not use hardpoints.
            },
        },
    },
    Graphics = new GraphicDefinition
    {
        ModelName = "", // put your model path here for your ammo (eg see missile.cs)
        VisualProbability = 1f, // 0 to 1 in % of probability of seeing round model (eg missiles)
        ShieldHitDraw = true, // show shield hit particle when impacting shields
        Particles = new ParticleDefinition
        {
            Ammo = new Particle
            {
                Name = "Photon", // put your particle subtypeid here
                Color = Color(red: 128, green: 0, blue: 0, alpha: 32),
                Offset = Vector(x: 0, y: -1, z: 0),
                Extras = Options(loop: false, restart: false, distance: 5000, duration: 1, scale: 1.25f),
            },
            Hit = new Particle
            {
                Name = "ShipWelderArc", // put your particle subtypeid here
                Color = Color(red: 255, green: 0, blue: 0, alpha: 1),
                Offset = Vector(x: 0, y: -1, z: 0),
                Extras = Options(loop: false, restart: false, distance: 5000, duration: 1, scale: 1.25f),
            },
            Barrel1 = new Particle
            {
                Name = "",  // put your particle subtypeid here
                Color = Color(red: 255, green: 0, blue: 0, alpha: 1),
                Offset = Vector(x: 0, y: -1, z: 0),
                Extras = Options(loop: false, restart: false, distance: 50, duration: 6, scale: 1f),
            },
            Barrel2 = new Particle
            {
                Name = "", // put your particle subtypeid here
                Color = Color(red: 255, green: 0, blue: 0, alpha: 1),
                Offset = Vector(x: 0, y: -1, z: 0),
                Extras = Options(loop: false, restart: false, distance: 50, duration: 6, scale: 1f),
            },
        },

        Line = new LineDefinition
        {
            Trail = true,
            Material = "ProjectileTrailLine", // put your transparentmaterial subtypeid here
            Color = Color(red: 10, green: 10, blue: 10, alpha: 1),
            Length = 1f,
            Width = 0.04f,
            ColorVariance = Random(start: 1, end: 2),
            WidthVariance = Random(start: -0.025f, end: 0.025f),
        },
    },
    Audio = new AudioDefinition
    {
        HardPoint = new AudioHardPointDefinition
        {
            FiringSound = "", // put your audio subtypeid here
            FiringSoundPerShot = false,
            ReloadSound = "", // put your audio subtypeid here
            NoAmmoSound = "", // put your audio subtypeid here
            HardPointRotationSound = "", // put your audio subtypeid here
            BarrelRotationSound = "", // put your audio subtypeid here
        },

        Ammo = new AudioAmmoDefinition
        {
            TravelSound = "", // put your audio subtypeid here
            HitSound = "", // put your audio subtypeid here
        }, // Don't edit below this line
    }, 
};}}
