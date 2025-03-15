using Skirr.Repository;

namespace Skirr.Command;

/// <summary>
/// https://ascom-standards.org/api/#/ASCOM%20Methods%20Common%20To%20All%20Devices/put__device_type___device_number__connect
/// </summary>
public class SetConnected : DeviceCommand<SetConnectedRequest, SetConnectedResult>
{
    public SetConnected(ConfiguredDevices devices) : base(devices)
    {
    }

    public override SetConnectedResult ExecuteDevice(AlpacaDevice device, SetConnectedRequest request)
    {
        if (request.Connected)
        {
            device.Connect();
        }
        else
        {
            device.Disconnect();
        }

        var result = new SetConnectedResult()
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1
        };

        return result;
    }
}

public class SetConnectedRequest : DeviceRequest
{
    public required bool Connected { get; init; }
}

public class SetConnectedResult : DeviceResult
{
}
