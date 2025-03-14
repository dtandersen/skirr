using Shouldly;
using Skirr.Alpaca;
using Skirr.Test;

namespace Skirr.Command;

public class TestGetDescription : DeviceTest
{
    private GetDescriptionResult Result;
    private AlpacaDevice? Device;

    [Test]
    public void ReturnTheDescription()
    {
        GivenCoverCalibrator();

        WhenGetDescription(new GetDescriptionRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1
        });

        Result.Value.ShouldBe("My cover calibrator");
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void DeviceIsInvalid()
    {
        try
        {
            WhenGetDescription(new GetDescriptionRequest()
            {
                DeviceType = DeviceType.CoverCalibrator,
                DeviceNumber = 2
            });
        }
        catch (InvalidDeviceException e)
        {
            var error = e.Error;
            error.ErrorNumber.ShouldBe(DeviceError.InvalidDevice);
            error.ErrorMessage.ShouldBe($"Invalid device: {DeviceType.CoverCalibrator}#2");
            return;
        }

        Assert.Fail("Expected InvalidDeviceException");
    }

    private void WhenGetDescription(GetDescriptionRequest request)
    {
        GetDescription connect = new GetDescription(devices);
        Result = connect.Execute(request);
        Device = devices.Find<AlpacaDevice>(DeviceType.CoverCalibrator, 1);
    }
}
