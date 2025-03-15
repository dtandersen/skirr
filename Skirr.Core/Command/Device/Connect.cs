using Skirr.Repository;

namespace Skirr.Command;

/// <summary>
/// https://ascom-standards.org/api/#/ASCOM%20Methods%20Common%20To%20All%20Devices/put__device_type___device_number__connect
/// </summary>
public class Connect : DeviceCommand<ConnectRequest, ConnectResult>
{
    public Connect(ConfiguredDevices devices) : base(devices)
    {
    }

    public override ConnectResult ExecuteDevice(AlpacaDevice device, ConnectRequest request)
    {
        device.Connect();

        var result = new ConnectResult()
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1
        };

        return result;
    }
}

public class ConnectRequest : DeviceRequest
{
}

public class ConnectDto : DeviceResult
{
}

public class ConnectResult : DeviceResult
{
}
