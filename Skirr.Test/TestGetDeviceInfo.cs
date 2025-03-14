﻿using Shouldly;
using Skirr.Test;

namespace Skirr.Command;

public class TestGetDeviceInfo : DeviceTest<AlpacaDevice>
{
    private GetDeviceInfoResult Result;
    private AlpacaDevice? Device;

    [Test]
    public void ReturnTheDescription()
    {
        GivenDevice();

        WhenGetDeviceInfo(new GetDeviceInfoRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1
        });

        Result.Value.ShouldBe("info");
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void DeviceIsInvalid()
    {
        try
        {
            WhenGetDeviceInfo(new GetDeviceInfoRequest()
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

    private void WhenGetDeviceInfo(GetDeviceInfoRequest request)
    {
        GetDeviceInfo connect = new GetDeviceInfo(devices);
        Result = connect.Execute(request);
        Device = devices.Find<AlpacaDevice>(DeviceType.CoverCalibrator, 1);
    }
}
