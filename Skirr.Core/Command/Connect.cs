namespace Skirr.Command;

/// <summary>
/// https://ascom-standards.org/api/#/ASCOM%20Methods%20Common%20To%20All%20Devices/put__device_type___device_number__connect
/// </summary>
public class Connect
{
    private readonly Ascom ascom;

    public Connect(Ascom ascom)
    {
        this.ascom = ascom;
    }

    public void Execute(ConnectRequest request, ConnectResult result)
    {
        ascom.DeviceNumber = 1;
        result.ClientTransactionID = 1;
        result.ServerTransactionID = 1;
    }
}

public record ConnectRequest
{
    public required string DeviceType;
    public required int DeviceNumber;
    public int ClientId;
    public int ClientTransactionId;
}

public record ConnectResult
{
    public int ClientTransactionID;
    public int ServerTransactionID;
}
