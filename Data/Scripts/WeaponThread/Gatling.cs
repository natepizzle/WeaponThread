using static WeaponThread.Session.ShieldDefinition.ShieldType;
using static WeaponThread.Session.AmmoTrajectory.GuidanceType;
using static WeaponThread.Session.HardPointDefinition.Prediction;
using static WeaponThread.Session.AreaDamage.AreaEffectType;
using static WeaponThread.Session.SubSystemDefinition.BlockTypes;
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
        AimingTolerance = 4f, // 0 - 180 firing angle
        EnergyCost = 0.00000000001f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
        RotateBarrelAxis = 3, // 0 = off, 1 = xAxis, 2 = yAxis, 3 = zAxis
        AimLeadingPrediction = Advanced, // Off, Basic, Accurate, Advanced
        DelayCeaseFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

        Loading = new AmmoLoading
        {
            RateOfFire = 3600,
            BarrelsPerShot = 6,
            FakeBarrels = Options(enable: true, converge: true), // use virtual barrels to save performance at the cost of hit accuracy, converge beams to save even more performance (One particle hit)
            TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
            SkipBarrels = 0,
            ReloadTime = 600, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
            DelayUntilFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
            HeatPerShot = 1, //heat generated per shot
            MaxHeat = 37000, //max heat before weapon enters cooldown (70% of max heat)
            Cooldown = .95f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
            HeatSinkRate = 200, //amount of heat lost per second
            DegradeROF = true, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
            ShotsInBurst = 600,
            DelayAfterBurst = 240, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
        },
    },
    Targeting = new TargetingDefinition
    {
        SubSystems = new SubSystemDefinition()
        {
            Systems = Priority(Navigation, Defense, Offense, Power, Production), //define block type targeting order
            SubSystemPriority = true,
            ClosestFirst = true, // targets closest of first subtarget until closest of next subtarget is reached, will switch back to previous subtarget if closer than next subtarget if set to true. If set to false will target and destroy all of subtarget groups and then move to next subtarget group.
        },
        TopTargets = 4, // 0 = unlimited, max number of top targets to randomize between.
        TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
    },
    DamageScales = new DamageScaleDefinition
    {
        MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
        DamageVoxels = false, // true = voxels are vulnerable to this weapon

        // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
        Characters = -1f,
        Grids = Options(largeGridModifier: -1f, smallGridModifier: -1f),
        Armor = Options(armor: -1f, light: -1f, heavy: -1f, nonArmor: -1f), 
        Shields = Options(modifier: -1f, type: Kinetic), // Types: Kinetic, Energy, Emp or Bypass

        // first true/false (ignoreOthers) will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
        Custom = Options(false, Block(subTypeId: "Test1", modifier: -1), Block(subTypeId: "Test2", modifier: -1)),
    },
    Ammo = new AmmoDefinition
    {
        BaseDamage = 10f,
        Mass = 10000f, // in kilograms
        Health = 0, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
        BackKickForce = 0f,
        ObjectsHit = Options(maxObjectsHit: 0, countBlocks: false), // 0 = disabled, value determines max objects (and/or blocks) penetrated per hit

        AreaEffect = new AreaDamage
        {
            AreaEffect = Radiant, // Disabled = do not use area effect at all, Explosive is keens, Radiant is not.
            AreaEffectDamage = 10f, // 0 = use spillover from BaseDamage, otherwise use this value.
            AreaEffectRadius = 5f,
            Explosions = Options(noVisuals: false, noSound: false, scale: 1, customParticle: "", customSound: ""),
            Detonation = Options(detonateOnEnd: false, armOnlyOnHit: false, detonationDamage: 0, detonationRadius: 0),
        },

        Trajectory = new AmmoTrajectory
        {
            Guidance = None,
            TargetLossDegree = 80f,
            TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
            AccelPerSec = 0f,
            DesiredSpeed = 0f,
            MaxTrajectory = 5000f,
            SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
            RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
            Smarts = new Smarts
            {
                Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                Aggressiveness = 1f, // controls how responsive tracking is.
                MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                TrackingDelay = 1, // Measured in line length units traveled.
                MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                OverideTarget = false, // when set to true ammo picks its own target, does not use hardpoints.
            },
        },
    },
    Graphics = new GraphicDefinition
    {
        ModelName = "",
        VisualProbability = 1f,
        ShieldHitDraw = true,
        Particles = new ParticleDefinition
        {
            Ammo = new Particle
            {
                Name = "ShipWelderArc",
                Color = Color(red: 128, green: 0, blue: 0, alpha: 32),
                Offset = Vector(x: 0, y: -1, z: 0),
                Extras = Options(loop: true, restart: false, distance: 5000, duration: 1, scale: 1)
            },
            Hit = new Particle
            {
                Name = "ShipWelderArc",
                Color = Color(red: 243, green: 190, blue: 51, alpha: 1),
                Offset = Vector(x: 0, y: 0, z: 0),
                Extras = Options(loop: false, restart: false, distance: 5000, duration: 1, scale: 1.5f),
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
            Material = "WeaponLaser", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
            Color = Color(red: 32, green: 32, blue: 128, alpha: 1),
            Length = 1f,
            Width = 0.05f,
            ColorVariance = Random(start: 0.75f, end: 2f), // multiply the color by random values within range.
            WidthVariance = Random(start: 0f, end: 0.15f), // adds random value to default width (negatives shrinks width)
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
