using Skirr.Repository;

namespace Skirr.Command.CoverCalibrator;

public class GetCoverCalibratorState : DeviceCommand<GetCoverCalibratorStateRequest, GetCoverCalibratorStateResult>
{
    public GetCoverCalibratorState(ConfiguredDevices devices) : base(devices)
    {
    }

    public override GetCoverCalibratorStateResult ExecuteDevice(AlpacaDevice device, GetCoverCalibratorStateRequest request)
    {
        return new GetCoverCalibratorStateResult
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            Value = CoverCalibratorState.Ready
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
    public static int Ready = 3;

}
