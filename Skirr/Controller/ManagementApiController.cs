using Microsoft.AspNetCore.Mvc;

namespace Skirr.Web.Controller;

[ApiController]
public class ApplicationsController : ControllerBase
{
    [HttpGet]
    [Route("/management/apiversions")]
    public string ListApiVersions()
    {
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
    public string ListConfiguredDevices()
    {
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
    public string GetDescription()
    {
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
