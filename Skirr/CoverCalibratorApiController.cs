using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Skirr.Command;
using Skirr.Command.CoverCalibrator;
using Skirr.Model;

namespace Skirr.Device;

[ApiController]
public class CoverCalibratorApiController : ControllerBase
{
    private readonly CommandFactory commandFactory;

    public CoverCalibratorApiController(CommandFactory commandFactory)
    {
        this.commandFactory = commandFactory;
    }

    [Route("api/v1/covercalibrator/{DeviceNumber}/calibratorstate")]
    [HttpGet]
    [Produces("application/json")]
    public IActionResult GetCalibratorState([FromRoute] int DeviceNumber, [FromForm] ConnectRequestJson request)
    {
        var command = commandFactory.GetCoverCalibratorState();
        var result = command.Execute(new GetCoverCalibratorStateRequest
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = DeviceNumber
        });

        return Ok(new GetCoverCalibratorStateResponse
        {
            ClientTransactionID = result.ClientTransactionID,
            ServerTransactionID = result.ServerTransactionID,
            Value = result.Value
        });
    }
}
