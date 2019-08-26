using System;
using static WeaponThread.Session.ShieldDefinition.ShieldType;
using static WeaponThread.Session.AmmoTrajectory.GuidanceType;
using static WeaponThread.Session.HardPointDefinition.Prediction;
using static WeaponThread.Session.AreaDamage.AreaEffectType;
using static WeaponThread.Session.TargetingDefinition.BlockTypes;
using static WeaponThread.Session.TargetingDefinition.Threat;
using static WeaponThread.Session.Shrapnel.ShrapnelShape;
using static WeaponThread.Session;

namespace WeaponThread
{   // Don't edit above this line
    partial class Weapons { WeaponDefinition GazerBeam => new WeaponDefinition {
    Assignments = new ModelAssignments
    {
        MountPoints = new[]
        {
            MountPoint(subTypeId: "GazerBeamLB", aimPartId: "GazerBeamLenses", muzzlePartId: "GazerBeamLenses"),
        },
        Barrels = Names("muzzle_barrel_001", "muzzle_barrel_002", "muzzle_barrel_003", "muzzle_barrel_004", "muzzle_barrel_005", "muzzle_barrel_006", "muzzle_barrel_007", "muzzle_barrel_008")
    },
    Ui = new UiDefinition
    {
        RateOfFire = Slider(enable: true, min: 1200, max: 3600),
        DamageModifier = Slider(enable: true, min: 0.1, max: 1.1),
        SelectableProjectileColor = true,
    },
    HardPoint = new HardPointDefinition
    {
        WeaponId = "GazerBeam", // name of weapon in terminal
        AmmoMagazineId = "Blank",
        IsTurret = true,
        TurretController = true,
        TrackTargets = true,
        ElevationSpeed = 0.04f,
        RotateSpeed = 0.04f,
        DeviateShotAngle = 0f,
        AimingTolerance = 4f, // 0 - 180 firing angle
        EnergyCost = 0.00000000001f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
        RotateBarrelAxis = 0, // 0 = off, 1 = xAxis, 2 = yAxis, 3 = zAxis
        AimLeadingPrediction = Advanced, // Off, Basic, Accurate, Advanced
        DelayCeaseFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

        Loading = new AmmoLoading
        {
            RateOfFire = 500,
            BarrelsPerShot = 1,
            TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
            SkipBarrels = 0,
            ReloadTime = 600, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
            DelayUntilFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
            HeatPerShot = 1, //heat generated per shot
            MaxHeat = 1800, //max heat before weapon enters cooldown (70% of max heat)
            Cooldown = .95f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
            HeatSinkRate = 200, //amount of heat lost per second
            DegradeROF = true, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
            ShotsInBurst = 600,
            DelayAfterBurst = 240, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
        },
    },
    Targeting = new TargetingDefinition
    {
        Threats = Valid(Characters, Projectiles, Grids),
        SubSystems = Priority(Navigation, Defense, Offense, Power, Production, Any), //define block type targeting order
        ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
        MinimumDiameter = 10, // 0 = unlimited, Minimum radius of threat to engage.
        MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
        TopTargets = 4, // 0 = unlimited, max number of top targets to randomize between.
        TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
        StopTrackingSpeed = 70, // do not track target threats traveling faster than this speed
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

        // ignoreOthers will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
        Custom = SubTypeIds(false),
    },
    Ammo = new AmmoDefinition
    {
        BaseDamage = 10f,
        Mass = 0.1f, // in kilograms
        Health = 0, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
        BackKickForce = 0f,
        ObjectsHit = Options(maxObjectsHit: 2, countBlocks: false), // 0 = disabled, value determines max objects (and/or blocks) penetrated per hit
        Shrapnel = Options(baseDamage: 1, fragments: 0, maxTrajectory: 100, noAudioVisual: true, noGuidance: true, shape: HalfMoon),

        AreaEffect = new AreaDamage
        {
            AreaEffect = Disabled, // Disabled = do not use area effect at all, Explosive is keens, Radiant is not.
            AreaEffectDamage = 0f, // 0 = use spillover from BaseDamage, otherwise use this value.
            AreaEffectRadius = 100f,
            Explosions = Options(noVisuals: false, noSound: false, scale: 1, customParticle: "", customSound: ""),
            Detonation = Options(detonateOnEnd: false, armOnlyOnHit: false, detonationDamage: 0, detonationRadius: 0),
        },
        Beams = new BeamDefinition
        {
            Enable = true,
            VirtualBeams = true, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
            ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
            RotateRealBeam = true, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
            OneParticle = true, // Only spawn one particle hit per beam weapon.
        },
        Trajectory = new AmmoTrajectory
        {
            Guidance = None,
            TargetLossDegree = 80f,
            TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
            AccelPerSec = 0f,
            DesiredSpeed = 0f,
            MaxTrajectory = 3000f,
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
                Name = "LaserImpactParticle", //"MaterialHit_Metal_GatlingGun",
                Color = Color(red: 10, green: 1, blue: 0, alpha: 2),
                Offset = Vector(x: 0, y: 0, z: 0),
                Extras = Options(loop: false, restart: false, distance: 5000, duration: 1, scale: 0.2f),
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
            Color = Color(red: 2, green: 2, blue: 30, alpha: 1),
            Length = 1f,
            Width = 0.05f,
            ColorVariance = Random(start: 0.75f, end: 2f), // multiply the color by random values within range.
            WidthVariance = Random(start: 0f, end: 0.15f), // adds random value to default width (negatives shrinks width)
        },
        Emissive = new EmissiveDefinition
        {
            Heating = Options(enable: true),
            Tracking = Options(enable: true, color: Color(red: 255, green: 0, blue: 0, alpha: 1)),
            Reloading = Options(enable: true, color: Color(red: 255, green: 0, blue: 0, alpha: 1), pulse: false),
            Firing = Options(enable: true, stages: 1, color: Color(red: 255, green: 0, blue: 0, alpha: 1)),
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
