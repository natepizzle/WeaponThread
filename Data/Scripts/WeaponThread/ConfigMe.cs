using VRageMath;
using static WeaponThread.Session.AmmoShieldBehavior.ShieldType;
using static WeaponThread.Session.AmmoTrajectory.GuidanceType;
using static WeaponThread.Session.TurretDefinition.Prediction;

namespace WeaponThread
{
    partial class Session
    {
        readonly WeaponDefinition[] WeaponDefinitions =
        {
            //Start of your weapon definitions, can have as many WeaponDefinitions as you want.
            //First Weapon part on PDCTurretLB turret
            new WeaponDefinition
            {
                TurretDef = new TurretDefinition
                {
                    DefinitionId = "LargeGatling",
                    AmmoMagazineId = "Blank",
                    IsTurret = true,
                    TurretController = true,
                    TrackTargets = true,
                    RateOfFire = 300,
                    BarrelsPerShot = 1,
                    ShotsPerBarrel = 1,
                    SkipBarrels = 0,
                    ElevationSpeed = 0.05f,
                    RotateSpeed = 0.05f,
                    DeviateShotAngle = 0f,
                    AimingTolerance = 4f,
                    ReloadTime = 600, // Measured in game ticks (10 = 100ms, 60 = 1 seconds, etc..).
                    ReleaseTimeAfterFire = 204f,
                    HeatPerRoF = 1,
                    MaxHeat = 180,
                    HeatSinkRate = 2,
                    ShotEnergyCost = 0,
                    RotateBarrelAxis = 3, // 0 = off, 1 = xAxis, 2 = yAxis, 3 = zAxis
                    TargetPrediction = Advanced, // Off, Basic, Accurate, Advanced

                    MountPoints = new []
                    {
                        new MountPoint {SubtypeId = "PDCTurretLB", SubpartId = "Boomsticks"},
                        new MountPoint {SubtypeId = "PDCTurretSB", SubpartId = "Boomsticks"},
                    },

                    Barrels = new []
                    {
                        "muzzle_barrel_001", "muzzle_barrel_002", "muzzle_barrel_003",
                        "muzzle_barrel_004", "muzzle_barrel_005", "muzzle_barrel_006"
                    },

                },
                AmmoDef = new AmmoDefinition
                {
                    DefaultDamage = 0f,
                    AreaEffectYield = 0f,
                    AreaEffectRadius = 0f,
                    DetonateOnEnd = false,
                    ProjectileLength = 8f,
                    Mass = 150f,  // in grams
                    Health = 0f,
                    BackkickForce = 2.5f,

                    Trajectory = new AmmoTrajectory
                    {
                         Guidance = None,
                         SmartsFactor = 0.009f,
                         TargetLossDegree = 80f,
                         AccelPerSec = 0f,
                         DesiredSpeed = 300f,
                         MaxTrajectory = 1000f,
                         SpeedVariance = new Randomize {Start = 0, End = 10},
                         RangeVariance = new Randomize {Start = 0, End = 100},
                    },

                    ShieldBehavior = new AmmoShieldBehavior
                    {
                        ShieldDmgMultiplier = 1.1f,
                        ShieldDamage = Kinetic,
                    },

                },
                GraphicDef = new GraphicDefinition
                {
                    ModelName = "",
                    VisualProbability = 1f,
                    ShieldHitDraw = true,
                    Particles = new ParticleDefinition
                    {
                        AmmoParticle = "",
                        AmmoColor = new Vector4(0, 0, 128, 32),
                        AmmoOffset = new Vector3D(0, -1, 0),
                        AmmoScale = 1f,
                        HitParticle = "",
                        HitColor = new Vector4(0, 0, 0, 0),
                        HitScale = 1f,
                        Turret1Particle = "Smoke_LargeGunShot",
                        Turret1Color = new Vector4(0, 0, 0, 0),
                        Turret1Scale = 1f,
                        Turret1Restart = false,
                        Turret2Particle = "Muzzle_Flash_Large",
                        Turret2Color = new Vector4(0, 0, 0, 0),
                        Turret2Scale = 1f,
                        Turret2Restart = true,
                    },

                    Line = new LineDefinition
                    {
                        Trail = true,
                        Material = "ProjectileTrailLine", // WeaponLaser, WarpBubble, ProjectileTrailLine
                        Color = new Vector4(32, 32, 32, 1),
                        Width = 0.04f,
                        RandomizeColor = new Randomize { Start =  1f, End = 2f },
                        RandomizeWidth = new Randomize { Start =  0f, End = 0f },
                    },
                },
                AudioDef = new AudioDefinition
                {
                    Turret = new AudioTuretDefinition
                    {
                        FiringSoundStart = "",
                        FiringSoundLoop = "",
                        FiringSoundEnd = "",
                        FiringRange = 500f,
                        FiringVolume = 1f,
                        FiringPitchVar = new Randomize {Start = 0f, End = 0f},
                        FiringVolumeVar = new Randomize {Start = 0f, End = 0f},
                        ReloadSound = "",
                        ReloadRange = 30f,
                        ReloadVolume = 1f,
                        NoAmmoSound = "",
                        TurretRotationSound = "",
                    },

                    Ammo = new AudioAmmoDefinition
                    {
                        TravelSound = "",
                        TravelRange = 350f,
                        TravelVolume = 1f,
                        TravelPitchVar = new Randomize {Start = 0, End = 0},
                        TravelVolumeVar = new Randomize {Start = 0, End = 0},
                        HitSound = "",
                        HitRange = 450f,
                        HitVolume = 1f,
                        HitPitchVar = new Randomize {Start = 0, End = 0},
                        HitVolumeVar = new Randomize {Start = 0, End = 0},
                    },
                },
            },

            // Second Weapon part on PDCTurretLB turret
            new WeaponDefinition
            {
                TurretDef = new TurretDefinition
                {
                    DefinitionId = "LargeMissileTurret",
                    AmmoMagazineId = "TorpAmmo",
                    IsTurret = true,
                    TurretController = false,
                    TrackTargets = true,
                    RateOfFire = 60,
                    BarrelsPerShot = 1,
                    ShotsPerBarrel = 1,
                    SkipBarrels = 0,
                    ElevationSpeed = 0.05f,
                    RotateSpeed = 0.05f,
                    DeviateShotAngle = 0f,
                    AimingTolerance = 10f,
                    ReloadTime = 600,
                    ReleaseTimeAfterFire = 204f,
                    HeatPerRoF = 1,
                    MaxHeat = 180,
                    HeatSinkRate = 2,
                    ShotEnergyCost = 0,
                    RotateBarrelAxis = 0, // 0 = off, 1 = xAxis, 2 = yAxis, 3 = zAxis
                    TargetPrediction = Advanced,

                    MountPoints = new []
                    {
                        new MountPoint {SubtypeId = "PDCTurretLB", SubpartId = "MissileTurretBarrels"},
                        new MountPoint {SubtypeId = "PDCTurretSB", SubpartId = "MissileTurretBarrels"},
                    },

                    Barrels = new []
                    {
                        "muzzle_missile_001", "muzzle_missile_002", "muzzle_missile_003",
                        "muzzle_missile_004", "muzzle_missile_005", "muzzle_missile_006",
                    },

                },
                AmmoDef = new AmmoDefinition
                {
                    DefaultDamage = 0f,
                    AreaEffectYield = 10f,
                    AreaEffectRadius = 10f,
                    DetonateOnEnd = false,
                    ProjectileLength = 1f,
                    Mass = 150f,  // in grams
                    Health = 0f,
                    BackkickForce = 2.5f,

                    Trajectory = new AmmoTrajectory
                    {
                         Guidance = Smart,
                         SmartsFactor = 0.009f,
                         TargetLossDegree = 80f,
                         AccelPerSec = 30f,
                         DesiredSpeed = 240f,
                         MaxTrajectory = 3000f,
                         SpeedVariance = new Randomize {Start = 0, End = 10},
                         RangeVariance = new Randomize {Start = 0, End = 100},
                    },

                    ShieldBehavior = new AmmoShieldBehavior
                    {
                        ShieldDmgMultiplier = 1.1f,
                        ShieldDamage = Kinetic,
                    },

                },
                GraphicDef = new GraphicDefinition
                {
                    ModelName = "\\Models\\Weapons\\Projectile_Missile.mwm",
                    VisualProbability = 1f,
                    ShieldHitDraw = true,

                    Particles = new ParticleDefinition
                    {
                        AmmoParticle = "Smoke_Missile",
                        AmmoColor = Vector4.One,
                        AmmoOffset = new Vector3D(0, 0 , 0.4), // +Z backward, +Y up, +X right
                        AmmoScale = 0.8f,
                        HitParticle = "",
                        HitColor = new Vector4(0, 0, 0, 0),
                        HitScale = 1f,
                        Turret1Particle = "",
                        Turret1Color = new Vector4(0, 0, 0, 0),
                        Turret1Scale = 1f,
                        Turret1Restart = false,
                        Turret2Particle = "",
                        Turret2Color = new Vector4(0, 0, 0, 0),
                        Turret2Scale = 1f,
                        Turret2Restart = true,
                    },

                    Line = new LineDefinition
                    {
                        Trail = false,
                        Material = "ProjectileTrailLine", // WeaponLaser, WarpBubble, ProjectileTrailLine
                        Color = new Vector4(10, 10, 10, 1),
                        Width = 0.04f,
                        RandomizeColor = new Randomize { Start =  1f, End = 2f },
                        RandomizeWidth = new Randomize { Start =  0f, End = 0f },
                    },
                },
                AudioDef = new AudioDefinition
                {
                    Turret = new AudioTuretDefinition
                    {
                        FiringSoundStart = "WepShipSmallMissileShot",
                        FiringSoundLoop = "",
                        FiringSoundEnd = "",
                        FiringRange = 500f,
                        FiringVolume = 1f,
                        FiringPitchVar = new Randomize {Start = 0f, End = 0f},
                        FiringVolumeVar = new Randomize {Start = 0f, End = 0f},
                        ReloadSound = "",
                        ReloadRange = 30f,
                        ReloadVolume = 1f,
                        NoAmmoSound = "",
                        TurretRotationSound = "",
                    },

                    Ammo = new AudioAmmoDefinition
                    {
                        TravelSound = "",
                        TravelRange = 350f,
                        TravelVolume = 1f,
                        TravelPitchVar = new Randomize {Start = 0, End = 0},
                        TravelVolumeVar = new Randomize {Start = 0, End = 0},
                        HitSound = "",
                        HitRange = 450f,
                        HitVolume = 1f,
                        HitPitchVar = new Randomize {Start = 0, End = 0},
                        HitVolumeVar = new Randomize {Start = 0, End = 0},
                    },
                },
            },
			      // Second Weapon part on PDCTurretLB turret
            new WeaponDefinition
            {
                TurretDef = new TurretDefinition
                {
                    DefinitionId = "PhotonTorpedo",
                    AmmoMagazineId = "WolfSlug40mm",
                    IsTurret = false,
                    TurretController = false,
                    TrackTargets = false,
                    RateOfFire = 600,
                    BarrelsPerShot = 1,
                    ShotsPerBarrel = 1,
                    SkipBarrels = 0,
                    ElevationSpeed = 0.05f,
                    RotateSpeed = 0.05f,
                    DeviateShotAngle = 0f,
                    AimingTolerance = 10f,
                    ReloadTime = 600,
                    ReleaseTimeAfterFire = 204f,
                    HeatPerRoF = 1,
                    MaxHeat = 180,
                    HeatSinkRate = 2,
                    ShotEnergyCost = 0,
                    RotateBarrelAxis = 0, // 0 = off, 1 = xAxis, 2 = yAxis, 3 = zAxis
                    TargetPrediction = Advanced,

                    MountPoints = new []
                    {
                        new MountPoint {SubtypeId = "LargeFixedPositionMissileTurret", SubpartId = "None"},
                    },

                    Barrels = new []
                    {
                        "missile_muzzle_001", "missile_muzzle_002",
                    },

                },
                AmmoDef = new AmmoDefinition
                {
                    DefaultDamage = 20f,
                    AreaEffectYield = 10f,
                    AreaEffectRadius = 15f,
                    DetonateOnEnd = false,
                    ProjectileLength = 1f,
                    Mass = 150f,  // in grams
                    Health = 0f,
                    BackkickForce = 2.5f,

                    Trajectory = new AmmoTrajectory
                    {
                         Guidance = None,
                         SmartsFactor = 0.5f,
                         TargetLossDegree = 80f,
                         AccelPerSec = 0f,
                         DesiredSpeed = 400f,
                         MaxTrajectory = 800f,
                         SpeedVariance = new Randomize {Start = 0, End = 10},
                         RangeVariance = new Randomize {Start = 0, End = 100},
                    },

                    ShieldBehavior = new AmmoShieldBehavior
                    {
                        ShieldDmgMultiplier = 1.1f,
                        ShieldDamage = Kinetic,
                    },

                },
                GraphicDef = new GraphicDefinition
                {
                    ModelName = "",
                    VisualProbability = 0.5f,
                    ShieldHitDraw = true,
                    Particles = new ParticleDefinition
                    {
                        AmmoParticle = "",
                        AmmoColor = new Vector4(0, 0, 128, 32),
                        AmmoOffset = new Vector3D(0, -1, 0),
                        AmmoScale = 1f,
                        HitParticle = "",
                        HitColor = new Vector4(0, 0, 0, 0),
                        HitScale = 1f,
                        Turret1Particle = "Smoke_LargeGunShot",
                        Turret1Color = new Vector4(0, 0, 0, 0),
                        Turret1Scale = 1f,
                        Turret1Restart = false,
                        Turret2Particle = "Muzzle_Flash_Large",
                        Turret2Color = new Vector4(0, 0, 0, 0),
                        Turret2Scale = 1f,
                        Turret2Restart = true,
                    },

                    Line = new LineDefinition
                    {
                        Trail = true,
                        Material = "ProjectileTrailLine", // WeaponLaser, WarpBubble, ProjectileTrailLine
                        Color = new Vector4(10, 10, 10, 1),
                        Width = 0.04f,
                        RandomizeColor = new Randomize { Start =  1f, End = 2f },
                        RandomizeWidth = new Randomize { Start =  0f, End = 0f },
                    },
                },
                AudioDef = new AudioDefinition
                {
                    Turret = new AudioTuretDefinition
                    {
                        FiringSoundStart = "",
                        FiringSoundLoop = "",
                        FiringSoundEnd = "",
                        FiringRange = 500f,
                        FiringVolume = 1f,
                        FiringPitchVar = new Randomize {Start = 0f, End = 0f},
                        FiringVolumeVar = new Randomize {Start = 0f, End = 0f},
                        ReloadSound = "",
                        ReloadRange = 30f,
                        ReloadVolume = 1f,
                        NoAmmoSound = "",
                        TurretRotationSound = "",
                    },

                    Ammo = new AudioAmmoDefinition
                    {
                        TravelSound = "",
                        TravelRange = 350f,
                        TravelVolume = 1f,
                        TravelPitchVar = new Randomize {Start = 0, End = 0},
                        TravelVolumeVar = new Randomize {Start = 0, End = 0},
                        HitSound = "",
                        HitRange = 450f,
                        HitVolume = 1f,
                        HitPitchVar = new Randomize {Start = 0, End = 0},
                        HitVolumeVar = new Randomize {Start = 0, End = 0},
                    },
                },
            },
		// Don't edit below this line.
        };
    }
}
