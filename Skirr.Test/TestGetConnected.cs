﻿using Shouldly;
using Skirr.Test;

namespace Skirr.Command;

public class SetConnectedTest : DeviceTest<AlpacaDevice>
{
    SetConnectedResult? Result;

    [Test]
    public void DeviceIsConnected()
    {
        GivenDevice();
        device.Disconnect();

        WhenSetConnected(new SetConnectedRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1,
            Connected = true
        });

        device.Connected.ShouldBe(true);
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void DeviceIsDisconnected()
    {
        GivenDevice();
        device.Connect();

        WhenSetConnected(new SetConnectedRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1,
            Connected = false
        });

        device.Connected.ShouldBe(false);
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void DeviceIsInvalid()
    {
        try
        {
            WhenSetConnected(new SetConnectedRequest()
            {
                DeviceType = DeviceType.CoverCalibrator,
                DeviceNumber = 2,
                Connected = true
            });
        }
        catch (DeviceNotFoundException e)
        {
            e.Message.ShouldBe(DeviceNotFoundException.FormatMessage(DeviceType.CoverCalibrator, 2));
            return;
        }

        Assert.Fail("Expected InvalidDeviceException");
    }

    private void WhenSetConnected(SetConnectedRequest request)
    {
        SetConnected command = new SetConnected(devices);
        Result = command.Execute(request);
    }
}
