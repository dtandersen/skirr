using Skirr.Repository;

namespace Skirr.Command;

/// <summary>
/// https://ascom-standards.org/api/#/ASCOM%20Methods%20Common%20To%20All%20Devices/put__device_type___device_number__connect
/// </summary>
public class Connect : DeviceCommand<ConnectRequest, ConnectResultDto>
{
    public Connect(ConfiguredDevices devices) : base(devices)
    {
    }

    public override ConnectResultDto ExecuteDevice(AlpacaDevice device, ConnectRequest request)
    {
        device.Connected = true;

        var result = new ConnectResultDto()
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

public class ConnectResultDto : DeviceResult
{
}
