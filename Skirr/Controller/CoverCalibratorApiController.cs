using Microsoft.AspNetCore.Mvc;
using Skirr.Command.CoverCalibrator;
using Skirr.Model;

namespace Skirr.Web.Controller;

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

    [Route("api/v1/covercalibrator/{DeviceNumber}/coverstate")]
    [HttpGet]
    [Produces("application/json")]
    public IActionResult GetCalibratorCoverState([FromRoute] int DeviceNumber, [FromForm] ConnectRequestJson request)
    {
        var command = commandFactory.GetCoverCalibratorCoverState();
        var result = command.Execute(new GetCoverCalibratorCoverStateRequest
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = DeviceNumber
        });

        return Ok(new GetCoverCalibratorCoverStateResponse
        {
            ClientTransactionID = result.ClientTransactionID,
            ServerTransactionID = result.ServerTransactionID,
            Value = result.Value
        });
    }

    [Route("api/v1/covercalibrator/{DeviceNumber}/maxbrightness")]
    [HttpGet]
    [Produces("application/json")]
    public IActionResult GetCalibratorCoverMaxBrightness([FromRoute] int DeviceNumber, [FromForm] ConnectRequestJson request)
    {
        // var command = commandFactory.GetCoverCalibratorCoverState();
        // var result = command.Execute(new GetCoverCalibratorCoverStateRequest
        // {
        //     DeviceType = DeviceType.CoverCalibrator,
        //     DeviceNumber = DeviceNumber
        // });

        return Ok(new GetCoverCalibratorMaxBrightnessResponse
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            Value = 255
        });
    }

    [Route("api/v1/covercalibrator/{DeviceNumber}/brightness")]
    [HttpGet]
    [Produces("application/json")]
    public IActionResult GetBrightness([FromRoute] int DeviceNumber, [FromForm] CoverCalibratorGetBrightnessForm request)
    {
        var command = commandFactory.GetBrightness();
        var result = command.Execute(new GetBrightnessRequest
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = DeviceNumber
        });

        return Ok(new CoverCalibratorGetBrightnessResponse
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            Value = result.Value
        });
    }

    [Route("api/v1/covercalibrator/{DeviceNumber}/opencover")]
    [HttpPut]
    [Produces("application/json")]
    public IActionResult OpenCover([FromRoute] int DeviceNumber, [FromForm] ConnectRequestJson request)
    {
        // var command = commandFactory.GetCoverCalibratorCoverState();
        // var result = command.Execute(new GetCoverCalibratorCoverStateRequest
        // {
        //     DeviceType = DeviceType.CoverCalibrator,
        //     DeviceNumber = DeviceNumber
        // });

        return Ok(new CoverCalibratorOpenCoverResponse
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            ErrorMessage = "not implemented",
            ErrorNumber = DeviceError.MethodNotImplemented
        });
    }

    [Route("api/v1/covercalibrator/{DeviceNumber}/closecover")]
    [HttpPut]
    [Produces("application/json")]
    public IActionResult CloseCover([FromRoute] int DeviceNumber, [FromForm] ConnectRequestJson request)
    {
        // var command = commandFactory.GetCoverCalibratorCoverState();
        // var result = command.Execute(new GetCoverCalibratorCoverStateRequest
        // {
        //     DeviceType = DeviceType.CoverCalibrator,
        //     DeviceNumber = DeviceNumber
        // });


        return Ok(new CoverCalibratorCloseCoverResponse
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            ErrorMessage = "not implemented",
            ErrorNumber = DeviceError.MethodNotImplemented
        });
    }

    [Route("api/v1/covercalibrator/{DeviceNumber}/haltcover")]
    [HttpPut]
    [Produces("application/json")]
    public IActionResult HaltCover([FromRoute] int DeviceNumber, [FromForm] ConnectRequestJson request)
    {
        // var command = commandFactory.GetCoverCalibratorCoverState();
        // var result = command.Execute(new GetCoverCalibratorCoverStateRequest
        // {
        //     DeviceType = DeviceType.CoverCalibrator,
        //     DeviceNumber = DeviceNumber
        // });

        return Ok(new CoverCalibratorHaltCoverResponse
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            ErrorMessage = "not implemented",
            ErrorNumber = DeviceError.MethodNotImplemented
        });
    }

    [Route("api/v1/covercalibrator/{DeviceNumber}/calibratoroff")]
    [HttpPut]
    [Produces("application/json")]
    public IActionResult TurnOffCalibrator([FromRoute] int DeviceNumber, [FromForm] ConnectRequestJson request)
    {
        // var command = commandFactory.GetCoverCalibratorCoverState();
        // var result = command.Execute(new GetCoverCalibratorCoverStateRequest
        // {
        //     DeviceType = DeviceType.CoverCalibrator,
        //     DeviceNumber = DeviceNumber
        // });

        return Ok(new GetCoverCalibratorMaxBrightnessResponse
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            Value = 255
        });
    }

    [Route("api/v1/covercalibrator/{DeviceNumber}/calibratoron")]
    [HttpPut]
    [Produces("application/json")]
    public IActionResult TurnOnCalibrator([FromRoute] int DeviceNumber, [FromForm] CoverCalibratorCalibratorOnForm request)
    {
        var command = commandFactory.ActivateCoverCalibrator();
        var result = command.Execute(new ActivateCoverCalibratorRequest
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = DeviceNumber,
            Brightness = request.Brightness
        });

        return Ok(new CoverCalibratorCalibratorOnResponse
        {
            ClientTransactionID = 1,
            ServerTransactionID = 1,
            ErrorMessage = result.ErrorMessage,
            ErrorNumber = result.ErrorNumber
        });
    }
}
