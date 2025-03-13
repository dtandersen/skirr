namespace Skirr.Model;

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

public class GetConnectedResultJson
{
    public int ClientTransactionID { get; set; }
    public int ServerTransactionID { get; set; }
    public bool Value { get; set; }
}

public class GetDescriptionResultJson
{
    public int ClientTransactionID { get; set; }
    public int ServerTransactionID { get; set; }
    public required string Value { get; set; }
}
