using Skirr.Repository;

namespace Skirr.Command;

public class GetSupportedActions : DeviceCommand<GetSupportedActionsRequest, GetSupportedActionsResult>
{
    public GetSupportedActions(ConfiguredDevices devices) : base(devices)
    {
    }

    public override GetSupportedActionsResult ExecuteDevice(AlpacaDevice device, GetSupportedActionsRequest request)
    {
        return new GetSupportedActionsResult
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            Value = device.Actions
        };
    }
}

public class GetSupportedActionsRequest : DeviceRequest
{
}

public class GetSupportedActionsResult : DeviceResult
{
    public required List<string> Value { get; set; }
}
