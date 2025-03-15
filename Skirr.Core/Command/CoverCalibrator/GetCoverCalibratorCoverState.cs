using Skirr.Alpaca;
using Skirr.Repository;

namespace Skirr.Command.CoverCalibrator;

public class GetCoverCalibratorCoverState : DeviceCommand<GetCoverCalibratorCoverStateRequest, GetCoverCalibratorCoverStateResult>
{
    public GetCoverCalibratorCoverState(ConfiguredDevices devices) : base(devices)
    {
    }

    public override GetCoverCalibratorCoverStateResult ExecuteDevice(AlpacaDevice device, GetCoverCalibratorCoverStateRequest request)
    {
        CoverCalibratorDevice? device2 = Devices.Find<CoverCalibratorDevice>(request.DeviceType, request.DeviceNumber);

        return new GetCoverCalibratorCoverStateResult
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            Value = device2.CoverState
        };
    }
}

public class GetCoverCalibratorCoverStateRequest : DeviceRequest
{
}

public class GetCoverCalibratorCoverStateResult : DeviceResult
{
    public required int Value { get; set; }
}
