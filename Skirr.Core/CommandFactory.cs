using Skirr.Command;
using Skirr.Repository;

namespace Skirr;

public class CommandFactory
{
    public required ConfiguredDevices Devices { get; init; }

    public CommandFactory(ConfiguredDevices devices)
    {
        Devices = devices;
    }

    public Connect Connect()
    {
        return new Connect(Devices);
    }

    public GetConnected GetConnected()
    {
        return new GetConnected(Devices);
    }

    public GetDescription GetDescription()
    {
        return new GetDescription(Devices);
    }
}
