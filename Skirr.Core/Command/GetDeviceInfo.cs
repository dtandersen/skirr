using Skirr.Repository;

namespace Skirr.Command;

public class GetDeviceInfo : DeviceCommand<GetDeviceInfoRequest, GetDeviceInfoResult>
{
    public GetDeviceInfo(ConfiguredDevices devices) : base(devices)
    {
    }

    public override GetDeviceInfoResult ExecuteDevice(AlpacaDevice device, GetDeviceInfoRequest request)
    {
        return new GetDeviceInfoResult
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            Value = device.Info
        };
    }
}

public class GetDeviceInfoRequest : DeviceRequest
{
}

public class GetDeviceInfoResult : DeviceResult
{
    public required string Value { get; set; }
}
