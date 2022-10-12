using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace MonitoringAppSimulation
{
    public enum GearModeEnum
    {
        ModeP = 1,
        ModeR = 2,
        ModeN = 3,
        ModeD = 4
    }
    public enum OnOffEnum
    {
        ModeOff = 0,
        ModeOn = 1
    }

    public enum DrivingReadyEnum
    {
        DrivingNotReady = 0,
        DrivingReady = 1
    }

    public enum DirectionSignalEnum
    {
        DirectionNormal = 0,
        DirectionLeft = 1,
        DirectionRight = 2
    }

    public enum DrivingModeEnum
    {
        DrivingManual = 1,
        DrivingAutonomous = 2
    }

    public enum CabinDoorStatus
    {
        DoorClosed = 1,
        DoorOpened = 2,
        DoorClosing = 3
    }

    public enum GpsStatusEnum
    {
        GpsNormal = 0,
        GpsAbnormal = 1
    }

    [ProtoContract]
    public class GPSPosition
    {
        [ProtoMember(1)]
        public double Lat { get; set; }

        [ProtoMember(2)]
        public double Lng { get; set; }
    }

    // definition of a message (marked up with Protobuf attributes)
    [ProtoContract]
    public class VehicleCANData
    {
        [ProtoMember(1)]
        public int VehicleSpeed { get; set; }

        [ProtoMember(2)]
        public GearModeEnum GearMode { get; set; }

        [ProtoMember(3)]
        public DrivingReadyEnum DrivingReady { get; set; }

        [ProtoMember(4)]
        public int DrivingHour { get; set; }

        [ProtoMember(5)]
        public int DrivingMinutes { get; set; }

        [ProtoMember(6)]
        public int DrivingDistance { get; set; }

        [ProtoMember(7)]
        public int BatteryRemains { get; set; }

        [ProtoMember(8)]
        public OnOffEnum BatteryCharing { get; set; }

        [ProtoMember(9)]
        public int AvailableDistance { get; set; }

        [ProtoMember(10)]
        public OnOffEnum TailLamp { get; set; }

        [ProtoMember(11)]
        public OnOffEnum FogLamp { get; set; }

        [ProtoMember(12)]
        public OnOffEnum HeadLampHigh { get; set; }

        [ProtoMember(13)]
        public OnOffEnum HeadLampLow { get; set; }

        [ProtoMember(14)]
        public DirectionSignalEnum TurnSignalLamp { get; set; }


        [ProtoMember(15)]
        public OnOffEnum EmergencyLamp { get; set; }

        [ProtoMember(16)]
        public OnOffEnum EmergencySwitchMode { get; set; }

        [ProtoMember(17)]
        public OnOffEnum CabinCombineStatus { get; set; }

        [ProtoMember(18)]
        public DrivingModeEnum DrivingMode { get; set; }

        [ProtoMember(19)]
        public int OutTemperature { get; set; }

        [ProtoMember(20)]
        public int CabinClimate { get; set; }

        [ProtoMember(21)]
        public CabinDoorStatus CabinDoorStatus { get; set; }
        [ProtoMember(22)]
        public OnOffEnum StopBellStatus { get; set; }

        [ProtoMember(23)]
        public int GpsTimeHour { get; set; }

        [ProtoMember(24)]
        public int GpsTimeMinutes { get; set; }

        [ProtoMember(25)]
        public GpsStatusEnum GpsStatus { get; set; }

        [ProtoMember(26)]
        public GPSPosition GpsInfo { get; set; }

        [ProtoMember(27)]
        public int CurrentStation { get; set; }

        [ProtoMember(28)]
        public int DestinationStation { get; set; }

        [ProtoMember(29)]
        public int StationDistance { get; set; }

        [ProtoMember(30)]
        public int IntersectionDistance { get; set; }

        [ProtoMember(31)]
        public int BumpDistance { get; set; }

        [ProtoMember(32)]
        public int Heading { get; set; }
        [ProtoMember(33)]
        public int INSStatus { get; set; }
        [ProtoMember(34)]
        public int AVSensor { get; set; }

        [ProtoMember(35)]
        public int AVSw { get; set; }

        [ProtoMember(36)]
        public int AVError { get; set; }
        [ProtoMember(37)]
        public bool Moving { get; set; }
    }
}
