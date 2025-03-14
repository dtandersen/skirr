using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Skirr.Command;
using Skirr.Model;

namespace Skirr.Device;

[ApiController]
public class DeviceApiController : ControllerBase
{
    private readonly CommandFactory commandFactory;

    public DeviceApiController(CommandFactory commandFactory)
    {
        this.commandFactory = commandFactory;
    }

    [Route("api/v1/{DeviceType}/{DeviceNumber}/connect")]
    [HttpPut]
    [Produces("application/json")]
    public IActionResult Connect([FromQuery] string DeviceType, [FromRoute] int DeviceNumber, [FromForm] ConnectRequestJson request)
    {
        var command = commandFactory.Connect();
        var result = command.Execute(new ConnectRequest
        {
            DeviceType = DeviceType,
            DeviceNumber = DeviceNumber
        });

        return Ok(new ConnectResultJson
        {
            ClientTransactionID = result.ClientTransactionID,
            ServerTransactionID = result.ServerTransactionID
        });
    }

    [Route("api/v1/{DeviceType}/{DeviceNumber}/connected")]
    [HttpGet]
    [Produces("application/json")]
    public IActionResult Connected([FromRoute] string DeviceType, [FromRoute] int DeviceNumber, [FromForm] ConnectRequestJson request)
    {
        var command = commandFactory.GetConnected();
        var result = command.Execute(new GetConnectedRequest
        {
            DeviceType = DeviceType,
            DeviceNumber = DeviceNumber
        });

        return Ok(new GetConnectedResultJson
        {
            ClientTransactionID = result.ClientTransactionID,
            ServerTransactionID = result.ServerTransactionID,
            Value = result.Connected
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
            ClientTransactionID = 1,
        };
    }

    [HttpGet]
    [Route("api/v1/{DeviceType}/{DeviceNumber}/description")]
    [Produces("application/json")]
    public IActionResult GetDescription([FromRoute] string DeviceType, [FromRoute] int DeviceNumber, [FromForm] ConnectRequestJson request)
    {
        var command = commandFactory.GetDescription();
        var result = command.Execute(new GetDescriptionRequest
        {
            DeviceType = DeviceType,
            DeviceNumber = DeviceNumber
        });

        return Ok(new GetDescriptionResultJson
        {
            ClientTransactionID = result.ClientTransactionID,
            ServerTransactionID = result.ServerTransactionID,
            Value = result.Value
        });
    }

    [HttpGet]
    [Route("api/v1/{DeviceType}/{DeviceNumber}/driverinfo")]
    [Produces("application/json")]
    public IActionResult GetDeviceInfo([FromRoute] string DeviceType, [FromRoute] int DeviceNumber, [FromForm] ConnectRequestJson request)
    {
        var command = commandFactory.GetDeviceInfo();
        var result = command.Execute(new GetDeviceInfoRequest
        {
            DeviceType = DeviceType,
            DeviceNumber = DeviceNumber
        });

        return Ok(new GetDeviceInfoResultJson
        {
            ClientTransactionID = result.ClientTransactionID,
            ServerTransactionID = result.ServerTransactionID,
            Value = result.Value
        });
    }

    [HttpGet]
    [Route("api/v1/{DeviceType}/{DeviceNumber}/name")]
    [Produces("application/json")]
    public IActionResult GetName([FromRoute] string DeviceType, [FromRoute] int DeviceNumber, [FromForm] ConnectRequestJson request)
    {
        var command = commandFactory.GetName();
        var result = command.Execute(new GetNameRequest
        {
            DeviceType = DeviceType,
            DeviceNumber = DeviceNumber
        });

        return Ok(new GetNameResponse
        {
            ClientTransactionID = result.ClientTransactionID,
            ServerTransactionID = result.ServerTransactionID,
            Value = result.Value
        });
    }

    [HttpGet]
    [Route("api/v1/{DeviceType}/{DeviceNumber}/supportedactions")]
    [Produces("application/json")]
    public IActionResult GetSupportedActions([FromRoute] string DeviceType, [FromRoute] int DeviceNumber, [FromForm] ConnectRequestJson request)
    {
        var command = commandFactory.GetSupportedActions();
        var result = command.Execute(new GetSupportedActionsRequest
        {
            DeviceType = DeviceType,
            DeviceNumber = DeviceNumber
        });

        return Ok(new GetSupportedActionsResponse
        {
            ClientTransactionID = result.ClientTransactionID,
            ServerTransactionID = result.ServerTransactionID,
            Value = result.Value
        });
    }
}
