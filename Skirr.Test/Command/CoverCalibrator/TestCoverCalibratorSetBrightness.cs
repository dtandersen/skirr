using Shouldly;
using Skirr.Alpaca;
using Skirr.Test;

namespace Skirr.Command.CoverCalibrator;

public class ActivateCalibratorTest : CoverCalibratorDeviceTest
{
    private ActivateCoverCalibratorResult Result;

    [Test]
    public void CalibratorTurnsOn()
    {
        GivenCoverCalibrator();
        device.Brightness = 0;

        WhenCalibratorIsActivated(new ActivateCoverCalibratorRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1,
            Brightness = 100
        });

        device.Brightness.ShouldBe(100);
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void BrightnessTooLow()
    {
        GivenCoverCalibrator();
        device.Brightness = 0;

        WhenCalibratorIsActivated(new ActivateCoverCalibratorRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1,
            Brightness = -1
        });

        device.Brightness.ShouldBe(0);
        Result.ErrorMessage.ShouldBe("Brightness must be between 0 and 255 [brightness=-1]");
        Result.ErrorNumber.ShouldBe(DeviceError.InvalidValue);
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void BrightnessTooHigh()
    {
        GivenCoverCalibrator();
        device.MaxBrightness = 255;
        device.Brightness = 0;

        WhenCalibratorIsActivated(new ActivateCoverCalibratorRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1,
            Brightness = 256
        });

        device.Brightness.ShouldBe(0);
        Result.ErrorMessage.ShouldBe("Brightness must be between 0 and 255 [brightness=256]");
        Result.ErrorNumber.ShouldBe(DeviceError.InvalidValue);
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void DeviceIsInvalid()
    {
        try
        {
            WhenCalibratorIsActivated(new ActivateCoverCalibratorRequest()
            {
                DeviceType = DeviceType.CoverCalibrator,
                DeviceNumber = 2,
                Brightness = 0
            });
        }
        catch (DeviceNotFoundException e)
        {
            e.Message.ShouldBe(DeviceNotFoundException.FormatMessage(DeviceType.CoverCalibrator, 2));
            return;
        }

        Assert.Fail("Expected InvalidDeviceException");
    }

    private void WhenCalibratorIsActivated(ActivateCoverCalibratorRequest request)
    {
        ActivateCoverCalibrator connect = new ActivateCoverCalibrator(devices);
        Result = connect.Execute(request);
    }
}
