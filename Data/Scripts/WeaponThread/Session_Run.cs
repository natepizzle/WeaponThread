using System;
using System.Collections.Generic;
using ProtoBuf;
using Sandbox.ModAPI;
using VRage.Game.Components;
using VRage.Utils;
using VRageMath;

namespace WeaponThread
{
    [MySessionComponentDescriptor(MyUpdateOrder.BeforeSimulation | MyUpdateOrder.AfterSimulation, int.MinValue + 1)]
    public partial class Session : MySessionComponentBase
    {
        public override void LoadData()
        {
            MyAPIGateway.Utilities.RegisterMessageHandler(2, Handler);
            Init();
            SendModMessage();
        }

        protected override void UnloadData()
        {
            MyAPIGateway.Utilities.UnregisterMessageHandler(2, Handler);
        }

        void Handler(object o)
        {
            if (o == null) SendModMessage();
        }

        void SendModMessage()
        {
            MyAPIGateway.Utilities.SendModMessage(1, Storage);
        }

        internal byte[] Storage;
        internal void Init()
        {
            try
            {
                Storage = MyAPIGateway.Utilities.SerializeToBinary(WeaponDefinitions);
            }
            catch (Exception ex) {; }
        }

        [ProtoContract]
        public struct WeaponDefinition
        {
            public enum EffectType
            {
                Spark,
                Lance,
                Orb,
                Custom
            }

            internal enum GuidanceType
            {
                None,
                Remote,
                Seeking,
                Lock,
                Smart
            }

            internal enum ShieldType
            {
                Bypass,
                Emp,
                Energy,
                Kinetic
            }

            [ProtoMember(1)] internal KeyValuePair<string, string>[] MountPoints;
            [ProtoMember(2)] internal string[] Barrels;
            [ProtoMember(3)] internal string DefinitionId;
            [ProtoMember(4)] internal bool TurretMode;
            [ProtoMember(5)] internal bool TrackTarget;
            [ProtoMember(6)] internal bool HasAreaEffect;
            [ProtoMember(7)] internal bool HasThermalEffect;
            [ProtoMember(8)] internal bool HasKineticEffect;
            [ProtoMember(9)] internal bool SkipAcceleration;
            [ProtoMember(10)] internal bool UseRandomizedRange;
            [ProtoMember(11)] internal bool ShieldHitDraw;
            [ProtoMember(12)] internal bool RealisticDamage;
            [ProtoMember(13)] internal bool LineTrail;
            [ProtoMember(14)] internal bool ParticleTrail;
            [ProtoMember(15)] internal int RotateBarrelAxis;
            [ProtoMember(16)] internal int ReloadTime;
            [ProtoMember(17)] internal int RateOfFire;
            [ProtoMember(18)] internal int BarrelsPerShot;
            [ProtoMember(19)] internal int SkipBarrels;
            [ProtoMember(20)] internal int ShotsPerBarrel;
            [ProtoMember(21)] internal int HeatPerRoF;
            [ProtoMember(22)] internal int MaxHeat;
            [ProtoMember(23)] internal int HeatSinkRate;
            [ProtoMember(24)] internal int MuzzleFlashLifeSpan;
            [ProtoMember(25)] internal float Mass;
            [ProtoMember(26)] internal float Health;
            [ProtoMember(27)] internal float LineLength;
            [ProtoMember(28)] internal float LineWidth;
            [ProtoMember(29)] internal float InitalSpeed;
            [ProtoMember(30)] internal float AccelPerSec;
            [ProtoMember(31)] internal float DesiredSpeed;
            [ProtoMember(32)] internal float RotateSpeed;
            [ProtoMember(33)] internal float SpeedVariance;
            [ProtoMember(34)] internal float MaxTrajectory;
            [ProtoMember(35)] internal float BackkickForce;
            [ProtoMember(36)] internal float DeviateShotAngle;
            [ProtoMember(37)] internal float ReleaseTimeAfterFire;
            [ProtoMember(38)] internal float RangeMultiplier;
            [ProtoMember(39)] internal float ThermalDamage;
            [ProtoMember(40)] internal float KeenScaler;
            [ProtoMember(41)] internal float AreaEffectYield;
            [ProtoMember(42)] internal float AreaEffectRadius;
            [ProtoMember(43)] internal float ShieldDmgMultiplier;
            [ProtoMember(44)] internal float DefaultDamage;
            [ProtoMember(45)] internal float ComputedBaseDamage;
            [ProtoMember(46)] internal float VisualProbability;
            [ProtoMember(47)] internal float ParticleRadiusMultiplier;
            [ProtoMember(48)] internal float AmmoTravelSoundRange;
            [ProtoMember(49)] internal float AmmoTravelSoundVolume;
            [ProtoMember(50)] internal float AmmoHitSoundRange;
            [ProtoMember(51)] internal float AmmoHitSoundVolume;
            [ProtoMember(52)] internal float ReloadSoundRange;
            [ProtoMember(53)] internal float ReloadSoundVolume;
            [ProtoMember(54)] internal float FiringSoundRange;
            [ProtoMember(55)] internal float FiringSoundVolume;
            [ProtoMember(56)] internal MyStringId PhysicalMaterial;
            [ProtoMember(57)] internal MyStringId ModelName;
            [ProtoMember(58)] internal Vector4 TrailColor;
            [ProtoMember(59)] internal Vector4 ParticleColor;
            [ProtoMember(60)] internal ShieldType ShieldDamage;
            [ProtoMember(61)] internal EffectType Effect;
            [ProtoMember(62)] internal GuidanceType Guidance;
            [ProtoMember(63)] internal string AmmoTravelSound;
            [ProtoMember(64)] internal string AmmoHitSound;
            [ProtoMember(65)] internal string ReloadSound;
            [ProtoMember(66)] internal string FiringSound;
            [ProtoMember(67)] internal string CustomEffect;
        }
    }
}

