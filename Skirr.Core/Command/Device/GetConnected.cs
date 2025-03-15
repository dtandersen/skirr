using Skirr.Repository;

namespace Skirr.Command;

/// <summary>
/// https://ascom-standards.org/api/#/ASCOM%20Methods%20Common%20To%20All%20Devices/get__device_type___device_number__connected
/// </summary>
public class GetConnected : DeviceCommand<GetConnectedRequest, GetConnectedDto>
{
    public GetConnected(ConfiguredDevices devices) : base(devices)
    {
    }

    public override GetConnectedDto ExecuteDevice(AlpacaDevice device, GetConnectedRequest request)
    {
        var result = new GetConnectedDto()
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            Connected = device.Connected
        };

        return result;
    }
}

public class GetConnectedRequest : DeviceRequest
{
}

public class GetConnectedDto : DeviceResult
{
    public bool Connected { get; set; }
}
