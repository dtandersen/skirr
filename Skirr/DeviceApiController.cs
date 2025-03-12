using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Skirr.Command;

namespace Skirr.Device;

[ApiController]
public class DeviceApiController : ControllerBase
{
    [Route("api/v1/{DeviceType}/{DeviceNumber}/connect")]
    [HttpPut]
    [Produces("application/json")]
    public String Connect([FromQuery] string DeviceType, [FromRoute] int DeviceNumber, [FromForm] ConnectRequest request)
    {
        Console.WriteLine("connect");
        return $$"""
        {
        "ClientTransactionID": 1,
        "ServerTransactionID": 1,
        }
        """;
    }

    [Route("api/v1/{DeviceType}/{DeviceNumber}/connected")]
    [HttpGet]
    [Produces("application/json")]
    public IActionResult Connected([FromRoute] string DeviceType, [FromRoute] int DeviceNumber, [FromForm] ConnectRequest request)
    {
        Console.WriteLine("Connected");
        return Ok(new ConnectResult
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1
        });
    }

    [Route("api/v1/{DeviceType}/{DeviceNumber}/connected")]
    [HttpPut]
    [Produces("application/json")]
    public ConnectedResult Connected2([FromRoute] string DeviceType, [FromRoute] int DeviceNumber, [FromForm] ConnectedRequest request)
    {
        Console.WriteLine("Connected");
        return new ConnectedResult
        {
            ClientID = 1,
            ClientTransactionID = 1
        };
    }
}

public class ConnectRequest
{
    public int ClientID { get; set; }
    public int ClientTransactionID { get; set; }
}

public class ConnectResult
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
