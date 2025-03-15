using Shouldly;
using Skirr.Test;

namespace Skirr.Command;

public class TestConnect : DeviceTest<AlpacaDevice>
{
    private ConnectResult Result;
    private AlpacaDevice? Device;

    [Test]
    public void DeviceIsConnected()
    {
        GivenDevice();
        device.Disconnect();

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
        catch (DeviceNotFoundException e)
        {
            e.Message.ShouldBe(DeviceNotFoundException.FormatMessage(DeviceType.CoverCalibrator, 2));
            return;
        }

        Assert.Fail("Expected InvalidDeviceException");
    }

    private void WhenConnect(ConnectRequest request)
    {
        Connect connect = new Connect(devices);
        Result = connect.Execute(request);
        Device = devices.Find<AlpacaDevice>(DeviceType.CoverCalibrator, 1);
    }
}
