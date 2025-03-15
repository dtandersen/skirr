using System.Net.WebSockets;
using Skirr.Alpaca;
using Skirr.Repository;

namespace Skirr.Command;

public class RegisterClient : Command<RegisterClientRequest, RegisterClientResponse>
{
    public readonly ConfiguredDevices Devices;

    public RegisterClient(ConfiguredDevices devices)
    {
        Devices = devices;
    }

    public RegisterClientResponse Execute(RegisterClientRequest request)
    {
        var device = Devices.Find<CoverCalibratorDevice>(DeviceType.CoverCalibrator, 1);
        device.Client = request.Client;
        return new RegisterClientResponse()
        {
        };
    }
}

public class RegisterClientRequest
{
    public required SkirrClient Client { get; init; }
}

public class RegisterClientResponse
{
}

public interface SkirrClient
{
    void SetBrightness(int brightness);
}
