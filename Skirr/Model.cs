namespace Skirr.Model;

public class DeviceRequest
{
    public int ClientID { get; set; }
    public int ClientTransactionID { get; set; }
}

public class DeviceResponse
{
    public int ClientTransactionID { get; init; }
    public int ServerTransactionID { get; init; }
    public int ErrorNumber { get; init; }
    public string ErrorMessage { get; init; } = "";
}

public class ConnectRequestJson
{
    public int ClientID { get; set; }
    public int ClientTransactionID { get; set; }
}

public class ConnectResultJson
{
    public int ClientTransactionID { get; set; }
    public int ServerTransactionID { get; set; }
}

public class ConnectedRequest
{
    public int ClientID { get; set; }
    public int ClientTransactionID { get; set; }
    public required bool Connected { get; set; }
}

public class ConnectedResult
{
    public int ClientID { get; set; }
    public int ClientTransactionID { get; set; }
}

public class GetConnectedResponse
{
    public int ClientTransactionID { get; set; }
    public int ServerTransactionID { get; set; }
    public bool Value { get; set; }
}

public class SetConnectedForm
{
    public int ClientID { get; set; }
    public int ClientTransactionID { get; set; }
    public required bool Connected { get; set; }
}

public class SetConnectedResponse
{
    public int ClientTransactionID { get; set; }
    public int ServerTransactionID { get; set; }
}

public class GetDescriptionResultJson
{
    public int ClientTransactionID { get; set; }
    public int ServerTransactionID { get; set; }
    public required string Value { get; set; }
}

public class GetDeviceInfoResultJson
{
    public int ClientTransactionID { get; set; }
    public int ServerTransactionID { get; set; }
    public required string Value { get; set; }
}

public class GetDriverInfoResultJson
{
    public int ClientTransactionID { get; set; }
    public int ServerTransactionID { get; set; }
    public required string Value { get; set; }
}

public class GetIntefaceVersionResult
{
    public int ClientTransactionID { get; set; }
    public int ServerTransactionID { get; set; }
    public required int Value { get; set; }
}

public class GetNameResponse
{
    public int ClientTransactionID { get; set; }
    public int ServerTransactionID { get; set; }
    public required string Value { get; set; }
}


public class GetSupportedActionsResponse
{
    public int ClientTransactionID { get; set; }
    public int ServerTransactionID { get; set; }
    public required List<string> Value { get; set; }
}
