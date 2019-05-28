using Sandbox.ModAPI;
using VRage.Game.Components;

namespace WeaponThread
{
    [MySessionComponentDescriptor(MyUpdateOrder.BeforeSimulation | MyUpdateOrder.AfterSimulation, int.MinValue + 1)]
    public class Session : MySessionComponentBase
    {
        private readonly ConfigMe _myConfig = new ConfigMe();
        public override void LoadData()
        {
            MyAPIGateway.Utilities.RegisterMessageHandler(2, Handler);
            _myConfig.Init();
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
            MyAPIGateway.Utilities.SendModMessage(1, _myConfig.Storage);
        }
    }
}

