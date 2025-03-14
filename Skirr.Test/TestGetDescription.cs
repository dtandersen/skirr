﻿using Shouldly;
using Skirr.Alpaca;
using Skirr.Test;

namespace Skirr.Command;

public class TestGetDescription : DeviceTest<AlpacaDevice>
{
    private GetDescriptionResult Result;
    private AlpacaDevice? Device;

    [Test]
    public void ReturnTheDescription()
    {
        GivenDevice();

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
        catch (DeviceNotFoundException e)
        {
            e.Message.ShouldBe(DeviceNotFoundException.FormatMessage(DeviceType.CoverCalibrator, 2));
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
