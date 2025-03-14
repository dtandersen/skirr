using Skirr.Repository;

namespace Skirr.Command;

public class GetName : DeviceCommand<GetNameRequest, GetNameResult>
{
    public GetName(ConfiguredDevices devices) : base(devices)
    {
    }

    public override GetNameResult ExecuteDevice(AlpacaDevice device, GetNameRequest request)
    {
        return new GetNameResult
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            Value = device.Name
        };
    }
}

public class GetNameRequest : DeviceRequest
{
}

public class GetNameResult : DeviceResult
{
    public required string Value { get; set; }
}
