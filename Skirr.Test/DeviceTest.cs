using Skirr.Repository;

namespace Skirr.Test;

public class DeviceTest
{
    protected ConfiguredDevices devices;

    public DeviceTest()
    {
        devices = new InMemoryConfiguredDevices();
    }

    protected void GivenDevice(AlpacaDevice device)
    {
        devices.AddDevice(device);
    }
}
