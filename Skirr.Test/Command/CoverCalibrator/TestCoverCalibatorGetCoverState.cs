using Shouldly;
using Skirr.Alpaca;
using Skirr.Test;

namespace Skirr.Command.CoverCalibrator;

public class TestGetCoverCalibratorCoverState : CoverCalibratorDeviceTest
{
    private GetCoverCalibratorCoverStateResult Result;

    [Test]
    public void CoverCalibratorIsReady()
    {
        GivenCoverCalibrator();
        device.Open();

        WhenGetCoverCalibratorCoverState(new GetCoverCalibratorCoverStateRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1
        });

        Result.Value.ShouldBe(CoverCalibratorCoverState.Open);
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void CoverCalibratorIsOff()
    {
        GivenCoverCalibrator();
        device.Close();

        WhenGetCoverCalibratorCoverState(new GetCoverCalibratorCoverStateRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1
        });

        Result.Value.ShouldBe(CoverCalibratorCoverState.Closed);
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void DeviceIsInvalid()
    {
        try
        {
            WhenGetCoverCalibratorCoverState(new GetCoverCalibratorCoverStateRequest()
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

    private void WhenGetCoverCalibratorCoverState(GetCoverCalibratorCoverStateRequest request)
    {
        GetCoverCalibratorCoverState connect = new GetCoverCalibratorCoverState(devices);
        Result = connect.Execute(request);
    }
}
