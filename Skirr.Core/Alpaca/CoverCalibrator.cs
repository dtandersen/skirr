
using Skirr.Command.CoverCalibrator;

namespace Skirr.Alpaca;

public class CoverCalibratorDevice : AlpacaDevice
{
    public int State { get; set; }
    public int CoverState { get; set; }
    public int Brightness { get; set; }
    public int MaxBrightness { get; set; } = 255;

    public void Close()
    {
        CoverState = CoverCalibratorCoverState.Closed;
    }

    public void Open()
    {
        CoverState = CoverCalibratorCoverState.Open;
    }

    public void SetBrightness(int brightness)
    {
        Brightness = brightness;
    }
}

public class CoverCalibratorState
{
    public readonly static int Off = 1;
    public readonly static int Ready = 3;
}

public class CoverCalibratorCoverState
{
    public static readonly int Closed = 1;
    public static readonly int Open = 3;
}
