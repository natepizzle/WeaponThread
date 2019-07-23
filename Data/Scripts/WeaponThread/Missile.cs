using static WeaponThread.Session.ShieldDefinition.ShieldType;
using static WeaponThread.Session.AmmoTrajectory.GuidanceType;
using static WeaponThread.Session.HardPointDefinition.Prediction;
using static WeaponThread.Session.AreaDamage.AreaEffectType;
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
        DeviateShotAngle = 5f,
        AimingTolerance = 180f,
        EnergyCost = 0,
        RotateBarrelAxis = 0, 
        TargetPrediction = Advanced,
        DelayCeaseFire = 0, 

        Loading = new AmmoLoading
        {
            RateOfFire = 180,
            BarrelsPerShot = 1,
            TrajectilesPerBarrel = 1,
            SkipBarrels = 0,
            ReloadTime = 300,
            DelayUntilFire = 0,
            HeatPerRoF = 1,
            MaxHeat = 180,
            HeatSinkRate = 2,
            ShotsInBurst = 3,
            DelayAfterBurst = 120,
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
        BaseDamage = 25000f, 		// how much damage the projectile does
        Mass = 10000f,
        Health = 0, 
        MaxObjectsHit = 0,
        BackKickForce = 2.5f,

        AreaEffect = new AreaDamage
        {
            AreaEffect = Explosive, // Disabled = do not use area effect at all, Explosive is keens, Radiant is not.
            AreaEffectDamage = 500f, // 0 = use spillover from BaseDamage, otherwise apply this value after baseDamage.
            AreaEffectRadius = 5f,
            DisableExplosionVisuals = false,
            DetonateOnEnd = false, // at trajectile death (baseDamage = 0/MaxTrajectory).
        },

        Trajectory = new AmmoTrajectory
        {
            Guidance = None,
            TargetLossDegree = 80f,
            TargetLossTime = 200, // time until trajectile death,  Measured in ticks (6 = 100ms, 60 = 1 seconds, etc..).
            AccelPerSec = 50f,
            DesiredSpeed = 600f,
            MaxTrajectory = 10000f,
            SpeedVariance = Random(start: 0, end: 0),
            RangeVariance = Random(start: 0, end: 0),
            Smarts = new Smarts
            {
                Inaccuracy = 15f, // 0 = perfect, aim pos will be 0 - # meters from center, recalculates on miss.
                Aggressiveness = 1f, // controls how responsive tracking is.
                MaxLateralThrust = 0.2, // controls how sharp the trajectile may turn (1 is max value)
                TrackingDelay = 5, // Measured in line length units traveled.
                MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                TopTargets = 4, // 0 = unlimited, max number of targets to pick from
                TopBlocks = 4, // 0 = unlimited, max number of blocks to pick from
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
            Length = 1f,
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