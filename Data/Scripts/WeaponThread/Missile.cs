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
    partial class Weapons { WeaponDefinition Missile => new WeaponDefinition {
    Assignments = new ModelAssignments
    {
        MountPoints = new[]
        {
            MountPoint(subTypeId: "PDCTurretLB", aimPartId: "MissileTurretBarrels", muzzlePartId: "MissileTurretBarrels"),
            MountPoint(subTypeId: "PDCTurretSB", aimPartId: "MissileTurretBarrels", muzzlePartId: "MissileTurretBarrels"),
        },
        Barrels = Names("muzzle_missile_001", "muzzle_missile_002", "muzzle_missile_003", "muzzle_missile_004", "muzzle_missile_005", "muzzle_missile_006")
    },
    Ui = new UiDefinition
    {
        RateOfFire = true,
        DamageModifier = false,
        ToggleGuidance = true,
        EnableOverload = false,
    },
    HardPoint = new HardPointDefinition
    {
        WeaponId = "Missile", // name of weapon in terminal
        AmmoMagazineId = "TorpAmmo",
        IsTurret = true,
        TurretController = false,
        TrackTargets = true,
        ElevationSpeed = 0.05f,
        RotateSpeed = 0.05f,
        DeviateShotAngle = 25f,
        AimingTolerance = 10f,
        EnergyCost = 10,
        Hybrid = false, //projectile based weapon with energy cost
        EnergyPriority = 0, //  0 = Lowest shares power with shields, 1 = Medium shares power with thrusters and over powers shields, 2 = Highest Does not share power will use all available power until energy requirements met
        RotateBarrelAxis = 0,
        AimLeadingPrediction = Advanced,
        DelayCeaseFire = 0,
        GridWeaponCap = 0,// 0 = unlimited, the smallest weapon cap assigned to a subTypeId takes priority.

        Loading = new AmmoLoading
        {
            RateOfFire = 180,
            BarrelsPerShot = 1,
            TrajectilesPerBarrel = 1,
            SkipBarrels = 0,
            ReloadTime = 300,
            DelayUntilFire = 0,
            HeatPerShot = 0, //heat generated per shot
            MaxHeat = 0, //max heat before weapon enters cooldown (70% of max heat)
            Cooldown = .95f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
            HeatSinkRate = 0, //amount of heat lost per second
            DegradeROF = false, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
            ShotsInBurst = 32,
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
        StopTrackingSpeed = 50, // do not track target threats traveling faster than this speed
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
        BaseDamage = 1f, 		// how much damage the projectile does
        Mass = 2500f,
        Health = 7500,
        BackKickForce = 2.5f,
        ObjectsHit = Options(maxObjectsHit: 0, countBlocks: false), // 0 = disabled, value determines max objects (and/or blocks) penetrated per hit
        Shrapnel = Options(baseDamage: 500, fragments: 0, maxTrajectory: 600, noAudioVisual: false, noGuidance: false, shape: FullMoon),

        AreaEffect = new AreaDamage
        {
            AreaEffect = Disabled, // Disabled = do not use area effect at all, Explosive is keens, Radiant is not.
            AreaEffectDamage = 0f, // 0 = use spillover from BaseDamage, otherwise apply this value after baseDamage.
            AreaEffectRadius = 0f,
            Explosions = Options(noVisuals: false, noSound: false, scale: 4, customParticle: "", customSound: ""),
            Detonation = Options(detonateOnEnd: true, armOnlyOnHit: false, detonationDamage: 50000, detonationRadius: 1),
        },
        Beams = new BeamDefinition
        {
            Enable = false,
            VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
            ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
            RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
            OneParticle = true, // Only spawn one particle hit per beam weapon.
        },
        Trajectory = new AmmoTrajectory
        {
            Guidance = Smart,
            TargetLossDegree = 80f,
            TargetLossTime = 600, // time until trajectile death,  Measured in ticks (6 = 100ms, 60 = 1 seconds, etc..).
            AccelPerSec = 25f,
            DesiredSpeed = 300f,
            MaxTrajectory = 5000f,
            SpeedVariance = Random(start: 0, end: 0),
            RangeVariance = Random(start: 0, end: 0),
            Smarts = new Smarts
            {
                Inaccuracy = 15f, // 0 = perfect, aim pos will be 0 - # meters from center, recalculates on miss.
                Aggressiveness = 1f, // controls how responsive tracking is.
                MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn (1 is max value)
                TrackingDelay = 5, // Measured in line length units traveled.
                MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
            },
        },
    },
    Graphics = new GraphicDefinition
    {
        ModelName = "", //\\Models\\Weapons\\Torpedo_Ammo_1st.mwm
        VisualProbability = 1f,
        ShieldHitDraw = true,
        Particles = new ParticleDefinition
        {
            Ammo = new Particle
            {
                Name = "PhotonTorpedoParticle",
                Color = Color(red: 1, green: 1, blue: 10, alpha: 1),
                Offset = Vector(x: 0, y: 0, z: 0),
                Extras = Options(loop: true, restart: false, distance: 5000, duration: 12, scale: 1.5f),
            },
            Hit = new Particle
            {
                Name = "ShipWelderArc",
                Color = Color(red: 10, green: 10, blue: 255, alpha: 1),
                Offset = Vector(x: 0, y: 0, z: 0),
                Extras = Options(loop: false, restart: false, distance: 5000, duration: 1, scale: 1.75f),
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
            Color = Color(red: 30, green: 0, blue: 30, alpha: 1),
            Length = 1f,
            Width = 0.1f,
            ColorVariance = Random(start: 1, end: 3),
            WidthVariance = Random(start: 0, end: 0),
        },
        Emissive = new EmissiveDefinition
        {
            Heating = Options(enable: true),
            Tracking = Options(enable: true, color: Color(red: 1, green: 0, blue: 0, alpha: 1)),
            Reloading = Options(enable: true, color: Color(red: 1, green: 0, blue: 0, alpha: 1), pulse: false),
            Firing = Options(enable: true, stages: 6, color: Color(red: 1, green: 0, blue: 0, alpha: 1)),
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