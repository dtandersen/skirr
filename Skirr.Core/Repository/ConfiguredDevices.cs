using Skirr.Alpaca;
using Skirr.Command;

namespace Skirr.Repository;

public interface ConfiguredDevices
{
    public List<AlpacaDevice> Devices { get; set; }

    public void AddDevice(AlpacaDevice device);

    public T Find<T>(string deviceType, int deviceNumber) where T : AlpacaDevice;
}

public class InMemoryConfiguredDevices : ConfiguredDevices
{
    public List<AlpacaDevice> Devices { get; set; }

    public InMemoryConfiguredDevices()
    {
        Devices = new List<AlpacaDevice>();
    }

    public void AddDevice(AlpacaDevice device)
    {
        Devices.Add(device);
    }

    public T Find<T>(string deviceType, int deviceNumber) where T : AlpacaDevice
    {
        var device = Devices.Find(device => device.DeviceType == deviceType && device.DeviceNumber == deviceNumber);
        if (device == null)
        {
            throw new DeviceNotFoundException(deviceType, deviceNumber);
        }

        return (T)device;
    }
}

public class ConfiguredDevicesStub : InMemoryConfiguredDevices
{
    public ConfiguredDevicesStub() : base()
    {
        AddDevice(
            new CoverCalibratorDevice
            {
                DeviceType = DeviceType.CoverCalibrator,
                DeviceNumber = 1,
                Description = "Skirr cover calibrator",
                Info = "Skirr cover calibrator",
                Name = "Skirr cover calibrator",
                Actions = new List<string> { "brightness" },
                State = CoverCalibratorState.Ready
            });
    }
}
