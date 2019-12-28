using System.Diagnostics;
using static WeaponThread.Session.ShieldDefinition.ShieldType;
using static WeaponThread.Session.AmmoTrajectory.GuidanceType;
using static WeaponThread.Session.HardPointDefinition.Prediction;
using static WeaponThread.Session.AreaDamage.AreaEffectType;
using static WeaponThread.Session.TargetingDefinition.BlockTypes;
using static WeaponThread.Session.TargetingDefinition.Threat;
using static WeaponThread.Session.Shrapnel.ShrapnelShape;
using static WeaponThread.Session.ShapeDefinition.Shapes;
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
        Barrels = Names("muzzle_missile_001", "muzzle_missile_002", "muzzle_missile_003", "muzzle_missile_004", "muzzle_missile_005", "muzzle_missile_006"),
        EnableSubPartPhysics = false
    },
    HardPoint = new HardPointDefinition
    {
        WeaponId = "Missile", // name of weapon in terminal
        AmmoMagazineId = "TorpAmmo",
        Block = AimControl(trackTargets: false, turretAttached: false, turretController: false, primaryTracking: false, rotateRate: 0.01f, elevateRate: 0.01f, minAzimuth: -180, maxAzimuth: 180, minElevation: -9, maxElevation: 50, offset: Vector(x: 0, y: 0, z: 0), fixedOffset: false, debug: false),
        DeviateShotAngle = 0f,
        AimingTolerance = 1f,
        EnergyCost = 10,
        Hybrid = false, //projectile based weapon with energy cost
        EnergyPriority = 0, //  0 = Lowest shares power with shields, 1 = Medium shares power with thrusters and over powers shields, 2 = Highest Does not share power will use all available power until energy requirements met
        RotateBarrelAxis = 0,
        AimLeadingPrediction = Advanced,
        DelayCeaseFire = 0,
        GridWeaponCap = 0,// 0 = unlimited, the smallest weapon cap assigned to a subTypeId takes priority.
        Ui = Display(rateOfFire: true, damageModifier: false, toggleGuidance: true, enableOverload: false),

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
            DegradeRof = false, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
            ShotsInBurst = 32,
            DelayAfterBurst = 240, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
        },
    },
    Targeting = new TargetingDefinition
    {
        Threats = Valid(Projectiles, Characters, Grids),
        SubSystems = Priority(Thrust, Utility, Offense, Power, Production, Any), //define block type targeting order
        ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
        MinimumDiameter = 0, // 0 = unlimited, Minimum radius of threat to engage.
        MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
        TopTargets = 4, // 0 = unlimited, max number of top targets to randomize between.
        TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
        StopTrackingSpeed = 500, // do not track target threats traveling faster than this speed
    },
    DamageScales = new DamageScaleDefinition
    {
        MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
        DamageVoxels = false, // true = voxels are vulnerable to this weapon
        SelfDamage = false, // true = allow self damage.

        // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
        Characters = -1f,
        Grids = Options(largeGridModifier: -1f, smallGridModifier: -1f),
        Armor = Options(armor: -1f, light: -1f, heavy: -1f, nonArmor: -1f),
        Shields = Options(modifier: -1f, type: Bypass), // Types: Kinetic, Energy, Emp or Bypass

        // ignoreOthers will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
        Custom = SubTypeIds(false),
    },
    Ammo = new AmmoDefinition
    {
        BaseDamage = 100f, 		// how much damage the projectile does
        Mass = 50f,
        Health = 1,
        BackKickForce = 2.5f,
        Shape = Options(shape: Sphere, diameter: 2), //defines the collision shape of projectile, defaults to visual Line Length
        ObjectsHit = Options(maxObjectsHit: 0, countBlocks: false), // 0 = disabled, value determines max objects (and/or blocks) penetrated per hit
        Shrapnel = Options(baseDamage: 500, fragments: 0, maxTrajectory: 600, noAudioVisual: false, noGuidance: false, shape: FullMoon),

        AreaEffect = new AreaDamage
        {
            AreaEffect = Explosive, // Disabled = do not use area effect at all, Explosive is keens, Radiant is not.
            AreaEffectDamage = 100f, // 0 = use spillover from BaseDamage, otherwise apply this value after baseDamage.
            AreaEffectRadius = 100f,
            Pulse = Options(interval: 60, pulseChance: 50), // interval measured in game ticks (60 == 1 second)
            Explosions = Options(noVisuals: false, noSound: false, scale: 4, customParticle: "", customSound: ""),
            Detonation = Options(detonateOnEnd: true, armOnlyOnHit: false, detonationDamage: 500, detonationRadius: 50),
            EwarFields = Options(duration: 600, stackDuration: true, depletable: true)
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
            Guidance = None,
            TargetLossDegree = 80f,
            TargetLossTime = 600, // time until trajectile death,  Measured in ticks (6 = 100ms, 60 = 1 seconds, etc..).
            AccelPerSec = 10f,
            DesiredSpeed = 30f,
            MaxTrajectory = 250f,
            FieldTime = 3600, // 0 is disabled, a value causes the projectile to come to rest and remain for a time (Measured in game ticks, 60 = 1 second)
            SpeedVariance = Random(start: 0, end: 0),
            RangeVariance = Random(start: 0, end: 0),
            Smarts = new Smarts
            {
                Inaccuracy = 0f, // 0 = perfect, aim pos will be 0 - # meters from center, recalculates on miss.
                Aggressiveness = 1f, // controls how responsive tracking is.
                MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn (1 is max value)
                TrackingDelay = 15, // Measured in line length units traveled.
                MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                OverideTarget = false, // when set to true ammo picks its own target, does not use hardpoint's.
            },
            Mines = Options(detectRadius: 100, deCloakRadius: 200, fieldTime: 1800, cloak: true, persist: false),
        },
    },
    Graphics = new GraphicDefinition
    {
        ModelName = "\\Models\\Weapons\\Torpedo_Ammo_1st.mwm", //\\Models\\Weapons\\Torpedo_Ammo_1st.mwm
        VisualProbability = 1f,
        ShieldHitDraw = true,
        Particles = new ParticleDefinition
        {
            Ammo = new Particle
            {
                Name = "ShipWelderArc",
                Color = Color(red: 5, green: 5, blue: 10, alpha: 1),
                Offset = Vector(x: 0, y: 0, z: 0),
                Extras = Options(loop: true, restart: false, distance: 1600, duration: 12, scale: 1f),
            },
            Hit = new Particle
            {
                Name = "ShipWelderArc",
                Color = Color(red: 10, green: 10, blue: 255, alpha: 1),
                Offset = Vector(x: 0, y: 0, z: 0),
                Extras = Options(loop: false, restart: false, distance: 5000, duration: 1, scale: 2.5f),
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
            Tracer = Base(enable: false, length: 1f, width: 0.1f, color: Color(red: 30, green: 0, blue: 30, alpha: 1)),
            TracerMaterial = "ProjectileTrailLine", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
            ColorVariance = Random(start: 1, end: 3), // multiply the color by random values within range.
            WidthVariance = Random(start: 0, end: 0), // adds random value to default width (negatives shrinks width)
            Trail = Options(enable: false, material: "ProjectileTrailLine", decayTime: 600, color: Color(red: 8, green: 8, blue: 64, alpha: 8)),
            OffsetEffect = Options(maxOffset: 0, minLength: 5, maxLength: 15) // 0 offset value disables this effect
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