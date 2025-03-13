
namespace Skirr.Command;

public class InvalidDeviceException : Exception
{
    public DeviceResult Error { get; init; }

    public InvalidDeviceException(DeviceResult error)
    {
        Error = error;
    }
}
