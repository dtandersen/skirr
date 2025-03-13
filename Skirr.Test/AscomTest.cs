namespace Skirr.Test;

public class AscomTest
{
    protected ConfiguredDevices devices;

    public AscomTest()
    {
        devices = new ConfiguredDevices();
    }

    protected void GivenDevice(string deviceType, int deviceNumber)
    {
        GivenDevice(new AlpacaDevice() { DeviceType = deviceType, DeviceNumber = deviceNumber });
    }

    protected void GivenDevice(AlpacaDevice device)
    {
        devices.AddDevice(device);
    }
}
