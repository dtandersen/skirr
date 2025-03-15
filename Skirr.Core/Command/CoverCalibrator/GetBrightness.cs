using Skirr.Alpaca;
using Skirr.Repository;

namespace Skirr.Command.CoverCalibrator;

public class GetBrightness : DeviceCommand<GetBrightnessRequest, GetBrightnessResult>
{
    public GetBrightness(ConfiguredDevices devices) : base(devices)
    {
    }

    public override GetBrightnessResult ExecuteDevice(AlpacaDevice device, GetBrightnessRequest request)
    {
        CoverCalibratorDevice? device2 = Devices.Find<CoverCalibratorDevice>(request.DeviceType, request.DeviceNumber);

        return new GetBrightnessResult
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            Value = device2.Brightness
        };
    }
}

public class GetBrightnessRequest : DeviceRequest
{
}

public class GetBrightnessResult : DeviceResult
{
    public required int Value { get; set; }
}
