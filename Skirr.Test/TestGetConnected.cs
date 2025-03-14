using System.Threading.Tasks;
using Shouldly;
using Skirr.Test;

namespace Skirr.Command;

public class GetConnectedTest : DeviceTest
{
    GetConnectedDto? Result;

    [Test]
    public void DeviceIsConnected()
    {
        GivenCoverCalibrator();

        WhenConnected(new GetConnectedRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1
        });

        AlpacaDevice? device = devices.Find<AlpacaDevice>(DeviceType.CoverCalibrator, 1);
        device.Connected.ShouldBe(true);
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void DeviceIsInvalid()
    {
        try
        {
            WhenConnected(new GetConnectedRequest()
            {
                DeviceType = DeviceType.CoverCalibrator,
                DeviceNumber = 2
            });
        }
        catch (InvalidDeviceException e)
        {
            var error = e.Error;
            error.ErrorNumber.ShouldBe(0x401);
            error.ErrorMessage.ShouldBe($"Invalid device: {DeviceType.CoverCalibrator}#2");
            return;
        }

        Assert.Fail("Expected InvalidDeviceException");
    }

    private void WhenConnected(GetConnectedRequest request)
    {
        GetConnected command = new GetConnected(devices);
        Result = command.Execute(request);
    }
}
