using Skirr.Command;
using Skirr.Command.CoverCalibrator;
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

    public SetConnected SetConnected()
    {
        return new SetConnected(Devices);
    }

    public GetDescription GetDescription()
    {
        return new GetDescription(Devices);
    }

    public GetDeviceInfo GetDeviceInfo()
    {
        return new GetDeviceInfo(Devices);
    }

    public GetName GetName()
    {
        return new GetName(Devices);
    }

    public GetSupportedActions GetSupportedActions()
    {
        return new GetSupportedActions(Devices);
    }

    public GetCoverCalibratorState GetCoverCalibratorState()
    {
        return new GetCoverCalibratorState(Devices);
    }

    public GetCoverCalibratorCoverState GetCoverCalibratorCoverState()
    {
        return new GetCoverCalibratorCoverState(Devices);
    }

    public ActivateCoverCalibrator ActivateCoverCalibrator()
    {
        return new ActivateCoverCalibrator(Devices);
    }

    public GetBrightness GetBrightness()
    {
        return new GetBrightness(Devices);
    }

    public RegisterClient RegisterClient()
    {
        return new RegisterClient(Devices);
    }
}
