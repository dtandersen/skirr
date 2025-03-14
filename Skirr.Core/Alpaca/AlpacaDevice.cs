
namespace Skirr;

public class AlpacaDevice
{
    public required string DeviceType { get; init; }
    public required int DeviceNumber { get; init; }
    public bool Connected { get; set; }
    public required string Description { get; init; }
    public required string Info { get; init; }
    public required string Name { get; init; }
    public required List<string> Actions { get; init; }

    public AlpacaDevice()
    {
        Connected = false;
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
