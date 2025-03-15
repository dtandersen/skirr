using Shouldly;
using Skirr.Alpaca;
using Skirr.Test;

namespace Skirr.Command.CoverCalibrator;

public class TestGetBrightness : CoverCalibratorDeviceTest
{
    private GetBrightnessResult Result;

    [Test]
    public void ReturnsTheBrightness()
    {
        GivenCoverCalibrator();
        device.SetBrightness(50);

        WhenGetBrightness(new GetBrightnessRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1
        });

        Result.Value.ShouldBe(50);
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void DeviceIsInvalid()
    {
        try
        {
            WhenGetBrightness(new GetBrightnessRequest()
            {
                DeviceType = DeviceType.CoverCalibrator,
                DeviceNumber = 2
            });
        }
        catch (DeviceNotFoundException e)
        {
            e.Message.ShouldBe(DeviceNotFoundException.FormatMessage(DeviceType.CoverCalibrator, 2));
            return;
        }

        Assert.Fail("Expected InvalidDeviceException");
    }

    private void WhenGetBrightness(GetBrightnessRequest request)
    {
        GetBrightness connect = new GetBrightness(devices);
        Result = connect.Execute(request);
    }
}
