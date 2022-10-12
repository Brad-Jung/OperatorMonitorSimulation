using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProtoBuf;

namespace MonitoringAppSimulation
{
    class VehicleCommandDataStatus
    {
        private VehicleCommandData vehicleCommandData;
        private NetmqPublisher publisher;
        private bool running = false;
        public event Action<string> OnPublished;

        public VehicleCommandDataStatus()
        {
            vehicleCommandData = new VehicleCommandData();
            vehicleCommandData.Test = 0;
            //publisher = new NetmqPublisher();
        }

        public void SetCommandData()
        {
            vehicleCommandData.Test++;
        }

        public int GetCommandDataCount()
        {
            return vehicleCommandData.Test;
        }

        public VehicleCommandData GetVehicleCommandData()
        {
            return vehicleCommandData;
        }

        public void OpenDoor(bool doorOpen)
        {
            vehicleCommandData.DoorOpen = doorOpen;
        }

        public void OnAutoDrivingMode(bool modeOn)
        {
            vehicleCommandData.AutoDrivingOn = modeOn;
        }
    }
}
