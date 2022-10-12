using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace MonitoringAppSimulation
{
    // definition of a message (marked up with Protobuf attributes)
    [ProtoContract]
    public class VehicleCommandData
    {
        [ProtoMember(1)]
        public int Test { get; set; }

        [ProtoMember(2)]
        public bool DoorOpen { get; set; }

        [ProtoMember(3)]
        public bool AutoDrivingOn { get; set; }

    }
}
