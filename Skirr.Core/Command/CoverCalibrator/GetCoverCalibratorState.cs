using Skirr.Alpaca;
using Skirr.Repository;

namespace Skirr.Command.CoverCalibrator;

public class GetCoverCalibratorState : DeviceCommand<GetCoverCalibratorStateRequest, GetCoverCalibratorStateResult>
{
    public GetCoverCalibratorState(ConfiguredDevices devices) : base(devices)
    {
    }

    public override GetCoverCalibratorStateResult ExecuteDevice(AlpacaDevice device, GetCoverCalibratorStateRequest request)
    {
        CoverCalibratorDevice? device2 = Devices.Find<CoverCalibratorDevice>(request.DeviceType, request.DeviceNumber);

        return new GetCoverCalibratorStateResult
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            Value = device2.State
        };
    }
}

public class GetCoverCalibratorStateRequest : DeviceRequest
{
}

public class GetCoverCalibratorStateResult : DeviceResult
{
    public required int Value { get; set; }
}

public class CoverCalibratorState
{
    public readonly static int Off = 1;
    public readonly static int Ready = 3;
}
