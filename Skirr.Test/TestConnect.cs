using Shouldly;
using Skirr.Test;

namespace Skirr.Command;

public class Tests : AscomTest
{
    [Test]
    public void Connect()
    {
        GivenDevice(DeviceType.CoverCalibrator, 1);
        Connect connect = new Connect(devices);
        ConnectRequest request = new ConnectRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1
        };

        ConnectResult result = new ConnectResult();

        connect.Execute(request, result);

        AlpacaDevice? device = devices.Find(DeviceType.CoverCalibrator, 1);
        device.DeviceNumber.ShouldBe(1);
        result.Result.ClientTransactionID.ShouldBe(1);
        result.Result.ServerTransactionID.ShouldBe(1);
    }

    [Test]
    public void DeviceIsInvalid()
    {
        Connect connect = new Connect(devices);
        ConnectRequest request = new ConnectRequest()
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1
        };

        ConnectResult result = new ConnectResult();

        connect.Execute(request, result);

        result.Error.ErrorNumber.ShouldBe(0x401);
        result.Error.ErrorMessage.ShouldBe($"Invalid device: {DeviceType.CoverCalibrator}#1");
    }
}
