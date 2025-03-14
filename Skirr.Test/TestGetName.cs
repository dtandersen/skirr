using Shouldly;
using Skirr.Test;

namespace Skirr.Command;

public class TestGetName : DeviceTest
{
    private GetNameResult Result;
    private AlpacaDevice? Device;

    [Test]
    public void ReturnTheDescription()
    {
        GivenCoverCalibrator();

        WhenGetName(new GetNameRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1
        });

        Result.Value.ShouldBe("name");
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void DeviceIsInvalid()
    {
        try
        {
            WhenGetName(new GetNameRequest()
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

    private void WhenGetName(GetNameRequest request)
    {
        GetName connect = new GetName(devices);
        Result = connect.Execute(request);
        Device = devices.Find(DeviceType.CoverCalibrator, 1);
    }
}
