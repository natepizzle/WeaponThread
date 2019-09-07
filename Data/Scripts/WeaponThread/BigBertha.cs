using System.Collections.Generic;
using static WeaponThread.Session.ShieldDefinition.ShieldType;
using static WeaponThread.Session.AmmoTrajectory.GuidanceType;
using static WeaponThread.Session.HardPointDefinition.Prediction;
using static WeaponThread.Session.AreaDamage.AreaEffectType;
using static WeaponThread.Session.TargetingDefinition.BlockTypes;
using static WeaponThread.Session.TargetingDefinition.Threat;
using static WeaponThread.Session.Shrapnel.ShrapnelShape;
using static WeaponThread.Session.ShapeDefinition.Shapes;
using static WeaponThread.Session.PartAnimationSetDef.EventOptions;
using static WeaponThread.Session.RelMove.MoveType;
using static WeaponThread.Session;

namespace WeaponThread
{   // Don't edit above this line
    partial class Weapons
    {
        WeaponDefinition BigBertha => new WeaponDefinition
        {
            Assignments = new ModelAssignments
            {
                MountPoints = new[]
                {
                    MountPoint(subTypeId: "MA_Bertha", aimPartId: "Bertha_Barrel", muzzlePartId: "None"),
                },
                Barrels = Names("muzzle_missile_001")
            },
            Ui = new UiDefinition
            {
                RateOfFire = false,
                DamageModifier = false,
                ToggleGuidance = false,
                EnableOverload = false,
            },
            HardPoint = new HardPointDefinition
            {
                WeaponId = "Big Bertha", // name of weapon in terminal
                AmmoMagazineId = "ChonkShell",
                IsTurret = false,
                TurretController = false,
                TrackTargets = false,
                ElevationSpeed = 0.04f,
                RotateSpeed = 0.04f,
                DeviateShotAngle = 0f,
                AimingTolerance = 180f, // 0 - 180 firing angle
                EnergyCost = 0.0002f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
                Hybrid = false, //projectile based weapon with energy cost
                EnergyPriority = 0, //  0 = Lowest shares power with shields, 1 = Medium shares power with thrusters and over powers shields, 2 = Highest Does not share power will use all available power until energy requirements met
                RotateBarrelAxis = 0, // 0 = off, 1 = xAxis, 2 = yAxis, 3 = zAxis
                AimLeadingPrediction = Advanced, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                GridWeaponCap = 0,// 0 = unlimited, the smallest weapon cap assigned to a subTypeId takes priority.

                Loading = new AmmoLoading
                {
                    RateOfFire = 3600,
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 380, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 0, //heat generated per shot
                    MaxHeat = 1800, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .95f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 200, //amount of heat lost per second
                    DegradeROF = false, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                },
            },
            Targeting = new TargetingDefinition
            {
                Threats = Valid(Grids),
                SubSystems = Priority(Power, Defense, Offense, Navigation), //define block type targeting order
                ClosestFirst = false, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 10, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 4, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 99, // do not track target threats traveling faster than this speed
            },
            DamageScales = new DamageScaleDefinition
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon
                SelfDamage = false, // true = allow self damage.
                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                Characters = -1f,
                Grids = Options(largeGridModifier: 10f, smallGridModifier: 5f),
                Armor = Options(armor: 1f, light: .1f, heavy: 100f, nonArmor: .04f),
                Shields = Options(modifier: .01f, type: Energy), // Types: Kinetic, Energy, Emp or Bypass

                // ignoreOthers will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
                Custom = SubTypeIds(false),
            },
            Ammo = new AmmoDefinition
            {
                BaseDamage = 5000000f,
                Mass = 100f, // in kilograms
                Health = 0, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
                BackKickForce = 500f,
                Shape = Options(shape: Sphere, diameter: 10), //defines the collision shape of projectile, defaults to visual Line Length
                ObjectsHit = Options(maxObjectsHit: 0, countBlocks: false), // 0 = disabled, value determines max objects (and/or blocks) penetrated per hit
                Shrapnel = Options(baseDamage: 200, fragments: 5, maxTrajectory: 100, noAudioVisual: true, noGuidance: true, shape: HalfMoon),

                AreaEffect = new AreaDamage
                {
                    AreaEffect = Radiant, // Disabled = do not use area effect at all, Explosive is keens, Radiant is not.
                    AreaEffectDamage = 0f, // 0 = use spillover from BaseDamage, otherwise use this value.
                    AreaEffectRadius = 70f,
                    Pulse = Options(interval: 30, pulseChance: 100), // interval measured in game ticks (60 == 1 second)
                    Explosions = Options(noVisuals: false, noSound: false, scale: 2, customParticle: "Explosion_Warhead_30", customSound: ""),
                    Detonation = Options(detonateOnEnd: false, armOnlyOnHit: false, detonationDamage: 10000000, detonationRadius: 70),
                },
                Beams = new BeamDefinition
                {
                    Enable = false,
                    VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                    ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                    RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                    OneParticle = false, // Only spawn one particle hit per beam weapon.
                },
                Trajectory = new AmmoTrajectory
                {
                    Guidance = None,
                    TargetLossDegree = 180f,
                    TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    AccelPerSec = 2000f,
                    DesiredSpeed = 2000f,
                    MaxTrajectory = 8000f,
                    SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                    RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                    Smarts = new Smarts
                    {
                        Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                        Aggressiveness = 1f, // controls how responsive tracking is.
                        MaxLateralThrust = 0.3f, // controls how sharp the trajectile may turn
                        TrackingDelay = 1200, // Measured in line length units traveled.
                        MaxChaseTime = 2000, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                        OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoints.
                    },
                },
            },

            Animations = BigBerthaAnimations, //link to animation config

            Graphics = new GraphicDefinition
            {
                ModelName = "\\Models\\Weapons\\Torpedo_Ammo_1st.mwm",
                VisualProbability = 1f,
                ShieldHitDraw = true,
                Particles = new ParticleDefinition
                {
                    Ammo = new Particle
                    {
                        Name = "ShipWelderArc",
                        Color = Color(red: 245, green: 200, blue: 66, alpha: .02f),//245, 200, 66
                        Offset = Vector(x: 0, y: 0, z: -0.5),
                        Extras = Options(loop: true, restart: false, distance: 800, duration: 12, scale: 2f)
                    },
                    Hit = new Particle
                    {
                        Name = "Explosion_Warhead_15", //"MaterialHit_Metal_GatlingGun",
                        Color = Color(red: 10, green: 1, blue: 0, alpha: 2),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = Options(loop: false, restart: false, distance: 5000, duration: 1, scale: 0.2f),
                    },
                    Barrel1 = new Particle
                    {
                        Name = "Smoke_LargeGunShot", // Smoke_LargeGunShot
                        Color = Color(red: 50, green: 50, blue: 50, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = Options(loop: false, restart: false, distance: 300, duration: 3, scale: 10f),
                    },
                    Barrel2 = new Particle
                    {
                        Name = "Muzzle_Flash_Large",//Muzzle_Flash_Large
                        Color = Color(red: 200, green: 200, blue: 100, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = Options(loop: true, restart: false, distance: 300, duration: 10, scale: 10f),
                    },
                },

                Line = new LineDefinition
                {
                    Trail = false,
                    Material = "ProjectileTrailLine", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                    Color = Color(red: 2, green: 2, blue: 30, alpha: 1),
                    Length = .01f,
                    Width = .01f,
                    ColorVariance = Random(start: 1f, end: 1f), // multiply the color by random values within range.
                    WidthVariance = Random(start: 0f, end: 0f), // adds random value to default width (negatives shrinks width)
                },
            },
            Audio = new AudioDefinition
            {
                HardPoint = new AudioHardPointDefinition
                {
                    FiringSound = "WepShipGatlingShot", // WepShipGatlingShot
                    FiringSoundPerShot = true,
                    ReloadSound = "WepTurretGatlingRotate",
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
        };
    }
}
