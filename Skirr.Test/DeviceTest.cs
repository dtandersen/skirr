using Skirr.Alpaca;
using Skirr.Repository;

namespace Skirr.Test;

public class DeviceTest<T> where T : AlpacaDevice
{
    protected ConfiguredDevices devices;
    protected T? device;

    public DeviceTest()
    {
        devices = new InMemoryConfiguredDevices();
    }

    public void GivenDevice(T device)
    {
        this.device = device;
        devices.AddDevice(device);
    }

    public void GivenDevice()
    {
        GivenDevice((T)new AlpacaDevice
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1,
            Description = "My cover calibrator",
            Info = "info",
            Name = "name",
            Actions = ["brightness"]
        });
    }
}

public class CoverCalibratorDeviceTest : DeviceTest<CoverCalibratorDevice>
{
    public void GivenCoverCalibrator()
    {
        GivenDevice(new CoverCalibratorDevice
        {
            DeviceType = DeviceType.CoverCalibrator,
            DeviceNumber = 1,
            Description = "My cover calibrator",
            Info = "info",
            Name = "name",
            Actions = ["brightness"]
        });
    }
}
