namespace Skirr.Command;

/// <summary>
/// https://ascom-standards.org/api/#/ASCOM%20Methods%20Common%20To%20All%20Devices/put__device_type___device_number__connect
/// </summary>
public class Connect : DeviceCommand<ConnectRequest, ConnectResult>
{
    public Connect(ConfiguredDevices devices) : base(devices)
    {
    }

    public override void ExecuteDevice(AlpacaDevice device, ConnectRequest request, ConnectResult result)
    {
        // result.ClientTransactionID = 1;
        // result.ServerTransactionID = 1;
        result.Success(new ConnectDto()
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1
        });
    }
}

public class ConnectRequest : DeviceRequest
{
}

public class ConnectDto : DeviceDto
{
}

public class ConnectResult : DeviceResult<ConnectDto>
{
}
// public class ConnectResult : SuccessResult<ConnectDto>, ErrorResult
// {
//     public ConnectDto result;
//     public ErrorDto error;

//     public void Invalid(ErrorDto error)
//     {
//         this.error = error;
//     }

//     public void Success(ConnectDto result)
//     {
//         this.result = result;
//     }
// }
