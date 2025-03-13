using Shouldly;
using Skirr.Test;

namespace Skirr.Command;

public class GetConnectedTest : AscomTest
{
    GetConnectedResult? result;
    GetConnectedDto? Result;

    [Test]
    public void DeviceIsConnected()
    {
        GivenDevice(DeviceType.CoverCalibrator, 1);

        WhenConnected(new GetConnectedRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1
        });

        AlpacaDevice? device = devices.Find(DeviceType.CoverCalibrator, 1);
        device.Connected.ShouldBe(true);
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void DeviceIsInvalid()
    {
        WhenConnected(new GetConnectedRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1
        });

        result.Error.ErrorNumber.ShouldBe(0x401);
        result.Error.ErrorMessage.ShouldBe($"Invalid device: {DeviceType.CoverCalibrator}#1");
    }

    private void WhenConnected(GetConnectedRequest request)
    {
        result = new GetConnectedResult();

        GetConnected command = new GetConnected(devices);
        command.Execute(request, result);

        Result = result.Result;
    }
}
