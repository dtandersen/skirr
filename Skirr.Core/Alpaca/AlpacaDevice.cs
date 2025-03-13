namespace Skirr;

public class AlpacaDevice
{
    public required string DeviceType { get; init; }
    public required int DeviceNumber { get; init; }
    public bool Connected { get; set; }

    public AlpacaDevice()
    {
        Connected = false;
    }
}

public class ConfiguredDevices
{
    public List<AlpacaDevice> Devices { get; set; }

    public ConfiguredDevices()
    {
        Devices = new List<AlpacaDevice>();
    }

    public void AddDevice(AlpacaDevice device)
    {
        Devices.Add(device);
    }

    public AlpacaDevice? Find(string deviceType, int deviceNumber)
    {
        return Devices.Find(device => device.DeviceType == deviceType && device.DeviceNumber == deviceNumber);
    }
}

public class DeviceType
{
    public static string CoverCalibrator = "covercalibrator";
}

public class DeviceError
{
    public static int InvalidDevice = 0x401;
}
