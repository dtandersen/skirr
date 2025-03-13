using Microsoft.AspNetCore.Mvc;

namespace Skirr.Management;

public class ApplicationsController : Controller
{
    // private readonly IApplicationService _applicationService;

    // public ApplicationsController(IApplicationService applicationService)
    // {
    //     _applicationService = applicationService;
    // }

    [HttpPut]
    public String Index(ApplicationQuery query)
    {
        // var permissionNodes = await _applicationService.SelectePagedApplicationsAsync(query);
        // ViewData["Query"] = query;
        // return View(permissionNodes.Data);
        return """
        test
        """;
    }

    [HttpGet]
    [Route("/management/apiversions")]
    public String y()
    {
        Console.WriteLine("configureddevices");
        return """
        {
        "Value": [
            1
        ],
        "ClientTransactionID": 1,
        "ServerTransactionID": 1
        }
        """;
    }

    [HttpGet]
    [Route("/management/v1/configureddevices")]
    public String x()
    {
        Console.WriteLine("configureddevices");
        return """
        {
        "Value": [
            {
            "DeviceName": "Skirr",
            "DeviceType": "covercalibrator",
            "DeviceNumber": 1,
            "UniqueID": "c8629d61-9619-4870-a0b9-6badb3e402bd"
            }
        ],
        "ClientTransactionID": 1,
        "ServerTransactionID": 1
        }
        """;
    }

    [HttpGet]
    [Route("/management/v1/description")]
    public String z()
    {
        Console.WriteLine("description");
        return """
        {
        "Value": {
            "ServerName": "string",
            "Manufacturer": "string",
            "ManufacturerVersion": "string",
            "Location": "string"
        },
        "ClientTransactionID": 1,
        "ServerTransactionID": 1
        }
        """;
    }
}

public record ApplicationQuery
{
    int ClientID;
    int ClientTransactionID;
}

public record ApplicationResult
{
    int ClientTransactionID = 1;
    int ServerTransactionID = 1;
}
