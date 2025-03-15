namespace Skirr;

public class AlpacaException : Exception
{
    public int ErrorNumber { get; init; }

    public AlpacaException(string message) : base(message)
    {
    }
}

public class DeviceNotFoundException : AlpacaException
{
    public DeviceNotFoundException(string deviceType, int deviceNumber)
        : base(FormatMessage(deviceType, deviceNumber))
    {
        ErrorNumber = DeviceError.InvalidValue;
    }

    public static string FormatMessage(string deviceType, int deviceNumber)
    {
        return $"Device {deviceType}#{deviceNumber} not found";
    }
}

public class MethodNotImplementedException : AlpacaException
{
    public MethodNotImplementedException(string message)
        : base(message)
    {
        ErrorNumber = DeviceError.MethodNotImplemented;
    }
}
