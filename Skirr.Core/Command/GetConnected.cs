namespace Skirr.Command;

/// <summary>
/// https://ascom-standards.org/api/#/ASCOM%20Methods%20Common%20To%20All%20Devices/get__device_type___device_number__connected
/// </summary>
public class GetConnected : DeviceCommand<GetConnectedRequest, GetConnectedResult>
{
    public GetConnected(ConfiguredDevices devices) : base(devices)
    {
    }

    public override void ExecuteDevice(AlpacaDevice device, GetConnectedRequest request, GetConnectedResult result)
    {
        device.Connected = true;
        result.Success(new GetConnectedDto()
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            Connected = true
        });
    }
}

public class GetConnectedRequest : DeviceRequest
{
}

public class GetConnectedResult : DeviceResult<GetConnectedDto>
{
}

public class GetConnectedDto : DeviceDto
{
    public bool Connected { get; set; }
}
