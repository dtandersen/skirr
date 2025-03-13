using Skirr.Command;

namespace Skirr;

public class CommandFactory
{
    public required ConfiguredDevices Devices { get; init; }

    public Connect Connect()
    {
        return new Connect(Devices);
    }
}
