
using Skirr.Repository;

namespace Skirr.Command;

public abstract class DeviceCommand<REQ, RES> : Command<REQ, RES>
    where REQ : DeviceRequest
    where RES : DeviceResult
{
    public ConfiguredDevices Devices { get; }

    public DeviceCommand(ConfiguredDevices devices)
    {
        Devices = devices;
    }

    public RES Execute(REQ request)
    {
        AlpacaDevice? device = Devices.Find<AlpacaDevice>(request.DeviceType, request.DeviceNumber);
        if (device == null)
        {
            throw new InvalidDeviceException(new DeviceResult
            {
                ClientTransactionID = request.ClientTransactionId,
                ServerTransactionID = 0,
                ErrorNumber = 0x401,
                ErrorMessage = $"Invalid device: {request.DeviceType}#{request.DeviceNumber}"
            });
        }

        return ExecuteDevice(device, request);
    }

    public abstract RES ExecuteDevice(AlpacaDevice device, REQ request);
}

public class DeviceRequest
{
    public required string DeviceType;
    public required int DeviceNumber;
    public int ClientId;
    public int ClientTransactionId;
}

public class DeviceResult
{
    public int ClientTransactionID { get; init; }
    public int ServerTransactionID { get; init; }
    public int ErrorNumber { get; init; }
    public string ErrorMessage { get; init; } = "";
}
