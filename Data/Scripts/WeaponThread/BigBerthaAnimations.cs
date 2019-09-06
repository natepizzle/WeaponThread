using System.Collections.Generic;
using static WeaponThread.Session.PartAnimationSetDef.EventOptions;
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
                    SubpartId = "Bertha_Barrel",
                    muzzle = "Any", //only used for firing, use "Any" for all muzzles
                    StartupDelay = 0, //only used for On animation
                    motionDelay = 0,
                    Reverse = Events(),
                    Loop = Events(Firing),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventOptions, RelMove[]>
                    {
                        [Firing] =
                            new[] //Firing, Reloading, Overheated, Tracking, Locked, OnOff define a new[] for each
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    ticksToMove = 25, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = ExpoDecay,
                                    linearPoints = new[]
                                    {
                                        Transformation(0, 0, 15), //linear movement
                                    },
                                    rotation = Transformation(0, 0, 0), //degrees
                                    rotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    ticksToMove = 40, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    linearPoints = new[]
                                    {
                                        Transformation(0, 0, -15), //linear movement
                                    },
                                    rotation = Transformation(0, 0, 0), //degrees
                                    rotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                            },
                    }
                },
                new PartAnimationSetDef()
                {
                    SubpartId = "Bertha_Reloader",
                    muzzle = "Any", //only used for firing, use "Any" for all muzzles
                    StartupDelay = 0, //only used for On animation
                    motionDelay = 170,
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventOptions, RelMove[]>
                    {
                        [Reloading] =
                            new[] //Firing, Reloading, Overheated, Tracking, Locked, OnOff define a new[] for each
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    ticksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    linearPoints = new[]
                                    {
                                        Transformation(0, 5.5, 0), //linear movement
                                    },
                                    rotation = Transformation(0, 0, 0), //degrees
                                    rotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    ticksToMove = 32, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Delay,
                                    linearPoints = new XYZ[0],
                                    rotation = Transformation(0, 0, 0), //degrees
                                    rotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    ticksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    linearPoints = new[]
                                    {
                                        Transformation(0, -5.5, 0), //linear movement
                                    },
                                    rotation = Transformation(0, 0, 0), //degrees
                                    rotAroundCenter = Transformation(0, 0, 0), //degrees
                                },
                            },
                    }
                },
                new PartAnimationSetDef()
                {
                    SubpartId = "Bertha_BreechDoor",
                    muzzle = "Any", //only used for firing, use "Any" for all muzzles
                    StartupDelay = 0, //only used for On animation
                    motionDelay = 75,
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventOptions, RelMove[]>
                    {
                        [Reloading] = new[] //Firing, Reloading, Overheated, Tracking, Locked, OnOff define a new[] for each
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                ticksToMove = 70, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                linearPoints = new XYZ[0],
                                rotation = Transformation(-90, 0, 0), //degrees
                                rotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                ticksToMove = 100, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                linearPoints = new XYZ[0],
                                rotation = Transformation(0, 0, 0), //degrees
                                rotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                ticksToMove = 70, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                linearPoints = new XYZ[0],
                                rotation = Transformation(90, 0, 0), //degrees
                                rotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                    }
                },
                new PartAnimationSetDef()
                {
                    SubpartId = "round",
                    muzzle = "Any", //only used for firing, use "Any" for all muzzles
                    StartupDelay = 0, //only used for On animation
                    motionDelay = 200,
                    Reverse = Events(),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventOptions, RelMove[]>
                    {
                        [Reloading] = new[] //Firing, Reloading, Overheated, Tracking, Locked, OnOff define a new[] for each
                        {
                            new RelMove
                            {
                                CenterEmpty = "",
                                ticksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                linearPoints = new[]
                                {
                                    Transformation(0, 0, -20), //linear movement
                                },
                                rotation = Transformation(0, 0, 0), //degrees
                                rotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                ticksToMove = 2, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                linearPoints = new XYZ[0],
                                rotation = Transformation(0, 0, 0), //degrees
                                rotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                ticksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                linearPoints = new[]
                                {
                                    Transformation(0, 5.5, 0), //linear movement
                                },
                                rotation = Transformation(0, 0, 0), //degrees
                                rotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                            new RelMove
                            {
                                CenterEmpty = "",
                                ticksToMove = 50, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Delay,
                                linearPoints = new XYZ[0],
                                rotation = Transformation(0, 0, 0), //degrees
                                rotAroundCenter = Transformation(0, 0, 0), //degrees
                            },/*
                            new RelMove
                            {
                                CenterEmpty = "",
                                ticksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Hide,
                                linearPoints = new XYZ[0],
                                rotation = Transformation(0, 0, 0), //degrees
                                rotAroundCenter = Transformation(0, 0, 0), //degrees
                            },*/
                            
                            new RelMove
                            {
                                CenterEmpty = "",
                                ticksToMove = 1, //number of ticks to complete motion, 60 = 1 second
                                MovementType = Linear,
                                linearPoints = new[]
                                {
                                    Transformation(0, -5.5, 20), //linear movement
                                },
                                rotation = Transformation(0, 0, 0), //degrees
                                rotAroundCenter = Transformation(0, 0, 0), //degrees
                            },
                        },
                    }
                }
            }
        };
    }
}
