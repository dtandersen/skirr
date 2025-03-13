using Skirr.Repository;

namespace Skirr.Command;

public class GetDescription : DeviceCommand<GetDescriptionRequest, GetDescriptionResult>
{
    public GetDescription(ConfiguredDevices devices) : base(devices)
    {
    }

    public override GetDescriptionResult ExecuteDevice(AlpacaDevice device, GetDescriptionRequest request)
    {
        return new GetDescriptionResult
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            Value = device.Description
        };
    }
}

public class GetDescriptionRequest : DeviceRequest
{
}

public class GetDescriptionResult : DeviceResult
{
    public required string Value { get; set; }
}
