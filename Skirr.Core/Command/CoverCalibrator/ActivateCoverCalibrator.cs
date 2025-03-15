using Skirr.Alpaca;
using Skirr.Repository;

namespace Skirr.Command.CoverCalibrator;

public class ActivateCoverCalibrator : DeviceCommand<ActivateCoverCalibratorRequest, ActivateCoverCalibratorResult>
{
    public ActivateCoverCalibrator(ConfiguredDevices devices) : base(devices)
    {
    }

    public override ActivateCoverCalibratorResult ExecuteDevice(AlpacaDevice device, ActivateCoverCalibratorRequest request)
    {
        CoverCalibratorDevice? device2 = Devices.Find<CoverCalibratorDevice>(request.DeviceType, request.DeviceNumber);
        Console.WriteLine($"Activating cover calibrator [brightness={request.Brightness}]");
        if (request.Brightness < 0 || request.Brightness > device2.MaxBrightness)
        {
            Console.WriteLine($"Value out of range [brightness={request.Brightness}]");
            return new ActivateCoverCalibratorResult
            {
                ClientTransactionID = 1,
                ServerTransactionID = 1,
                ErrorMessage = $"Brightness must be between 0 and 255 [brightness={request.Brightness}]",
                ErrorNumber = DeviceError.InvalidValue
            };
        }

        if (device2.Client != null)
        {
            device2.Client.SetBrightness(request.Brightness);
        }
        device2.SetBrightness(request.Brightness);

        return new ActivateCoverCalibratorResult
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1
        };
    }
}

public class ActivateCoverCalibratorRequest : DeviceRequest
{
    public required int Brightness { get; init; }
}

public class ActivateCoverCalibratorResult : DeviceResult
{
}
