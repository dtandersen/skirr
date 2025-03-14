using Skirr.Alpaca;
using Skirr.Repository;

namespace Skirr.Test;

public class DeviceTest
{
    protected ConfiguredDevices devices;

    public DeviceTest()
    {
        devices = new InMemoryConfiguredDevices();
    }

    public void GivenDevice(AlpacaDevice device)
    {
        devices.AddDevice(device);
    }

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
