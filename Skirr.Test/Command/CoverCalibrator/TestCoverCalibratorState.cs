using Shouldly;
using Skirr.Alpaca;
using Skirr.Test;

namespace Skirr.Command.CoverCalibrator;

public class TestGetCoverCalibratorState : DeviceTest
{
    private GetCoverCalibratorStateResult Result;
    private CoverCalibratorDevice? Device;

    [Test]
    public void CoverCalibratorIsReady()
    {
        GivenCoverCalibrator();
        Device = devices.Find<CoverCalibratorDevice>(DeviceType.CoverCalibrator, 1);
        Device.State = CoverCalibratorState.Ready;

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
    public void CoverCalibratorIsOff()
    {
        GivenCoverCalibrator();
        Device = devices.Find<CoverCalibratorDevice>(DeviceType.CoverCalibrator, 1);
        Device.State = CoverCalibratorState.Off;

        WhenGetCoverCalibratorState(new GetCoverCalibratorStateRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1
        });

        Result.Value.ShouldBe(CoverCalibratorState.Off);
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
    }
}
