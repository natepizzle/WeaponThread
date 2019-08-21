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
    partial class Weapons
    {
        WeaponDefinition MA_PDX => new WeaponDefinition
        {
            Assignments = new ModelAssignments
            {
                MountPoints = new[]
{
            new MountPoint {SubtypeId = "MA_PDX", SubpartId = "MissileTurretBarrels"},
            new MountPoint {SubtypeId = "MA_PDX_sm", SubpartId = "MissileTurretBarrels"},
        },
                Barrels = Names("muzzle_projectile_001")
            },
            Ui = new UiDefinition
            {
                RateOfFire = Slider(enable: false, min: 4000, max: 4000),
                DamageModifier = Slider(enable: true, min: 0.1, max: 1.1),
                SelectableProjectileColor = true,
            },
            HardPoint = new HardPointDefinition
            {
                WeaponId = "PDX", // name of weapon in terminal
                AmmoMagazineId = "Blank",
                IsTurret = true,
                TurretController = true,
                TrackTargets = true,
                ElevationSpeed = 0.4f,
                RotateSpeed = 0.4f,
                DeviateShotAngle = 0f,
                AimingTolerance = 4f, // 0 - 180 firing angle
                EnergyCost = 0.001f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel .1f=30MW
                Hybrid = false, //projectile based weapon with energy cost
                EnergyPriority = 0, //  0 = Lowest shares power with shields, 1 = Medium shares power with thrusters and over powers shields, 2 = Highest Does not share power will use all available power until energy requirements met
                RotateBarrelAxis = 0, // 0 = off, 1 = xAxis, 2 = yAxis, 3 = zAxis
                AimLeadingPrediction = Advanced, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 30, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).


                Loading = new AmmoLoading
                {
                    RateOfFire = 3600,
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 0, //heat generated per shot
                    MaxHeat = 1, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .99f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 1, //amount of heat lost per second
                    DegradeROF = true, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                },
            },
            Targeting = new TargetingDefinition
            {
                // This weapon ideally is point defense, always prioritize incoming missiles/threats first, then offense/defenses.
                Threats = Valid(Characters, Projectiles, Grids),
                SubSystems = Priority(Navigation, Defense, Offense, Power, Production, Any), //define block type targeting order
                ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 10, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 4, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = double.MaxValue, // do not track target threats traveling faster than this speed
            },
            DamageScales = new DamageScaleDefinition
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon

                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                Characters = -1f,
                Grids = Options(largeGridModifier: -1f, smallGridModifier: -1f),
                Armor = Options(armor: .5f, light: .4f, heavy: .1f, nonArmor: 1f),
                Shields = Options(modifier: 1f, type: Energy), // Types: Kinetic, Energy, Emp or Bypass

                // ignoreOthers will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
                Custom = SubTypeIds(false, Block(subTypeId: "Test1", modifier: -1), Block(subTypeId: "Test2", modifier: -1)),
            },
            Ammo = new AmmoDefinition
            {
                BaseDamage = 15f,
                Mass = 0f, // in kilograms
                Health = 0, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
                BackKickForce = 0f,
                ObjectsHit = Options(maxObjectsHit: 0, countBlocks: false), // 0 = disabled, value determines max objects (and/or blocks) penetrated per hit
                Shrapnel = Options(baseDamage: 1, fragments: 0, maxTrajectory: 100, noAudioVisual: true, noGuidance: true, shape: HalfMoon),

                AreaEffect = new AreaDamage
                {
                    AreaEffect = Disabled, // Disabled = do not use area effect at all, Explosive is keens, Radiant is not.
                    AreaEffectDamage = 10f, // 0 = use spillover from BaseDamage, otherwise use this value.
                    AreaEffectRadius = 7.5f,
                    Explosions = Options(noVisuals: false, noSound: false, scale: 1, customParticle: "", customSound: ""),
                    Detonation = Options(detonateOnEnd: false, armOnlyOnHit: false, detonationDamage: 0, detonationRadius: 0),
                },
                Beams = new BeamDefinition
                {
                    Enable = true,
                    VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                    ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                    RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                    OneParticle = true, // Only spawn one particle hit per beam weapon.
                },

                Trajectory = new AmmoTrajectory
                {
                    Guidance = None,
                    TargetLossDegree = 80f,
                    TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    AccelPerSec = 0f,
                    DesiredSpeed = 0f,
                    MaxTrajectory = 600f,
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
                    Color = Color(red: 32, green: 5, blue: 5, alpha: 1),
                    Length = 1f,
                    Width = 0.05f,
                    ColorVariance = Random(start: 0.8f, end: 1.2f), // multiply the color by random values within range.
                    WidthVariance = Random(start: -.01f, end: 0.01f), // adds random value to default width (negatives shrinks width)
                },
                Emissive = new EmissiveDefinition
                {
                    Heating = Options(enable: false),
                    Tracking = Options(enable: false, color: Color(red: 255, green: 0, blue: 0, alpha: 1)),
                    Reloading = Options(enable: false, color: Color(red: 255, green: 0, blue: 0, alpha: 1), pulse: false),
                    Firing = Options(enable: false, stages: 1, color: Color(red: 255, green: 0, blue: 0, alpha: 1)),
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
                    BarrelRotationSound = "", //WepShipGatlingRotation
                },

                Ammo = new AudioAmmoDefinition
                {
                    TravelSound = "",
                    HitSound = "",
                }, // Don't edit below this line
            },
        };
    }
}
