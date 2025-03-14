using Shouldly;
using Skirr.Test;

namespace Skirr.Command;

public class TestGetSupportedActions : DeviceTest
{
    private GetSupportedActionsResult Result;
    private AlpacaDevice? Device;

    [Test]
    public void ReturnTheDescription()
    {
        GivenCoverCalibrator();

        WhenGetSupportedActions(new GetSupportedActionsRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1
        });

        Result.Value.ShouldBe(["brightness"]);
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void DeviceIsInvalid()
    {
        try
        {
            WhenGetSupportedActions(new GetSupportedActionsRequest()
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

    private void WhenGetSupportedActions(GetSupportedActionsRequest request)
    {
        GetSupportedActions connect = new GetSupportedActions(devices);
        Result = connect.Execute(request);
        Device = devices.Find<AlpacaDevice>(DeviceType.CoverCalibrator, 1);
    }
}
