using Shouldly;
using Skirr.Test;

namespace Skirr.Command;

public class Tests : AscomTest
{
    private ConnectResultDto Result;
    private AlpacaDevice? Device;

    [Test]
    public void Connect()
    {
        GivenDevice(DeviceType.CoverCalibrator, 1);

        WhenConnect(new ConnectRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1
        });

        Device.Connected.ShouldBe(true);
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void DeviceIsInvalid()
    {
        try
        {
            Connect connect = new Connect(devices);
            ConnectRequest request = new ConnectRequest()
            {
                DeviceType = DeviceType.CoverCalibrator,
                DeviceNumber = 2
            };

            connect.Execute(request);
        }
        catch (InvalidDeviceException e)
        {
            var error = e.Error;
            error.ErrorNumber.ShouldBe(0x401);
            error.ErrorMessage.ShouldBe($"Invalid device: {DeviceType.CoverCalibrator}#2");
            return;
        }

        Assert.Fail("Expected InvalidDeviceException");
    }

    private void WhenConnect(ConnectRequest request)
    {
        Connect connect = new Connect(devices);
        Result = connect.Execute(request);
        Device = devices.Find(DeviceType.CoverCalibrator, 1);
    }
}
