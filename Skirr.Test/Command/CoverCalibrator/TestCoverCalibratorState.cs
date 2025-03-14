﻿using Shouldly;
using Skirr.Alpaca;
using Skirr.Test;

namespace Skirr.Command.CoverCalibrator;

public class TestGetCoverCalibratorState : CoverCalibratorDeviceTest
{
    private GetCoverCalibratorStateResult Result;

    [Test]
    public void CoverCalibratorIsReady()
    {
        GivenCoverCalibrator();
        device.State = CoverCalibratorState.Ready;

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
        device.State = CoverCalibratorState.Off;

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
        catch (DeviceNotFoundException e)
        {
            e.Message.ShouldBe(DeviceNotFoundException.FormatMessage(DeviceType.CoverCalibrator, 2));
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
