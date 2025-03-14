using Shouldly;
using Skirr.Command.CoverCalibrator;
using Skirr.Test;

namespace Skirr.Command;

public class TestGetCoverCalibratorState : DeviceTest
{
    private GetCoverCalibratorStateResult Result;
    private AlpacaDevice? Device;

    [Test]
    public void ReturnTheDescription()
    {
        GivenCoverCalibrator();

        WhenGetCoverCalibratorState(new GetCoverCalibratorStateRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1
        });

        Result.Value.ShouldBe(CoverCalibratorState.Ready);
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void DeviceIsInvalid()
    {
        try
        {
            WhenGetCoverCalibratorState(new GetCoverCalibratorStateRequest()
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

    private void WhenGetCoverCalibratorState(GetCoverCalibratorStateRequest request)
    {
        GetCoverCalibratorState connect = new GetCoverCalibratorState(devices);
        Result = connect.Execute(request);
        Device = devices.Find(DeviceType.CoverCalibrator, 1);
    }
}
