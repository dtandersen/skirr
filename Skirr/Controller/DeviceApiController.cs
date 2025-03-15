using Microsoft.AspNetCore.Mvc;
using Skirr.Command;
using Skirr.Model;

namespace Skirr.Web.Controller;

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

        return Ok(new GetConnectedResponse
        {
            ClientTransactionID = result.ClientTransactionID,
            ServerTransactionID = result.ServerTransactionID,
            Value = result.Connected
        });
    }

    [Route("api/v1/{DeviceType}/{DeviceNumber}/connected")]
    [HttpPut]
    [Produces("application/json")]
    public IActionResult SetConnected([FromRoute] string DeviceType, [FromRoute] int DeviceNumber, [FromForm] SetConnectedForm request)
    {
        var command = commandFactory.SetConnected();
        var result = command.Execute(new SetConnectedRequest
        {
            DeviceType = DeviceType,
            DeviceNumber = DeviceNumber,
            Connected = request.Connected
        });

        return Ok(new SetConnectedResponse
        {
            ClientTransactionID = result.ClientTransactionID,
            ServerTransactionID = result.ServerTransactionID,
        });
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
    [Route("api/v1/{DeviceType}/{DeviceNumber}/driverversion")]
    [Produces("application/json")]
    public IActionResult GetDriverVersion([FromRoute] string DeviceType, [FromRoute] int DeviceNumber, [FromForm] ConnectRequestJson request)
    {
        // var command = commandFactory.GetDeviceInfo();
        // var result = command.Execute(new GetDeviceInfoRequest
        // {
        //     DeviceType = DeviceType,
        //     DeviceNumber = DeviceNumber
        // });

        return Ok(new GetDeviceInfoResultJson
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            Value = "1"
        });
    }

    [HttpGet]
    [Route("api/v1/{DeviceType}/{DeviceNumber}/interfaceversion")]
    [Produces("application/json")]
    public IActionResult GetInterfaceVersion([FromRoute] string DeviceType, [FromRoute] int DeviceNumber, [FromForm] ConnectRequestJson request)
    {
        // var command = commandFactory.GetDeviceInfo();
        // var result = command.Execute(new GetDeviceInfoRequest
        // {
        //     DeviceType = DeviceType,
        //     DeviceNumber = DeviceNumber
        // });

        return Ok(new GetIntefaceVersionResult
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            Value = 1
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
