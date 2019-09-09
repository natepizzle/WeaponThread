using System.Collections.Generic;
using static WeaponThread.Session.EventTriggers;
using static WeaponThread.Session.RelMove.MoveType;
using static WeaponThread.Session;

namespace WeaponThread
{ // Don't edit above this line
    partial class Weapons
    {
        private AnimationDefinition BigBerthaAnimations => new AnimationDefinition
        {
            WeaponAnimationSets = new[]
            {
                new PartAnimationSetDef()
                {
                    SubpartId = Names("Bertha_Barrel"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<EventTriggers, RelMove[]>
                    {
                        [Firing] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = ExpoDecay,
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, 15), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 0, -15), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                            },
                    }
                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("Bertha_Reloader"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 170, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0),
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<EventTriggers, RelMove[]>
                    {
                        [Reloading] =
                            new[] //Firing, Reloading, Overheated, Tracking, Locked, OnOff define a new[] for each
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, 5.4, 0), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 32, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay,
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, -5.4, 0), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                            },
                    }
                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("Bertha_BreechDoor"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 75, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0),
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<EventTriggers, RelMove[]>
                    {
                        [Reloading] = new[] //Firing, Reloading, Overheated, Tracking, Locked, OnOff define a new[] for each
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 70, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(-90, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 100, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 70, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(90, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                    }
                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("round"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 200, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0),
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<EventTriggers, RelMove[]>
                    {
                        [Reloading] = new[] //Firing, Reloading, Overheated, Tracking, Locked, OnOff define a new[] for each
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 0, -20), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 2, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, 5.4, 0), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 50, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide,
                                Fade = false,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                LinearPoints = new[]
                                {
                                    Transformation(0, -5.4, 20), //linear movement
                                },
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                TicksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Show,
                                Fade = true,
                                LinearPoints = new XYZ[0],
                                Rotation = Transformation(0, 0, 0), //degrees
                                RotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                    }
                }
            }
        };
    }
}
