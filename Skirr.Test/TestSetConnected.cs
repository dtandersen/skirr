using System.Threading.Tasks;
using Shouldly;
using Skirr.Test;

namespace Skirr.Command;

public class GetConnectedTest : DeviceTest<AlpacaDevice>
{
    GetConnectedDto? Result;

    [Test]
    public void DeviceIsConnected()
    {
        GivenDevice();
        device.Connect();

        WhenConnected(new GetConnectedRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1
        });

        Result.Connected.ShouldBe(true);
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void DeviceIsDisconnected()
    {
        GivenDevice();
        device.Disconnect();

        WhenConnected(new GetConnectedRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1
        });

        Result.Connected.ShouldBe(false);
        Result.ClientTransactionID.ShouldBe(1);
        Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void DeviceIsInvalid()
    {
        try
        {
            WhenConnected(new GetConnectedRequest()
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

    private void WhenConnected(GetConnectedRequest request)
    {
        GetConnected command = new GetConnected(devices);
        Result = command.Execute(request);
    }
}
