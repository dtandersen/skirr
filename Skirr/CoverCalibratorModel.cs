namespace Skirr.Model;

public class GetCoverCalibratorStateResponse
{
    public int ClientTransactionID { get; set; }
    public int ServerTransactionID { get; set; }
    public required int Value { get; set; }
}

public class GetCoverCalibratorCoverStateResponse
{
    public int ClientTransactionID { get; set; }
    public int ServerTransactionID { get; set; }
    public required int Value { get; set; }
}

public class GetCoverCalibratorMaxBrightnessResponse
{
    public int ClientTransactionID { get; set; }
    public int ServerTransactionID { get; set; }
    public required int Value { get; set; }
}

public class CoverCalibratorOpenCoverResponse : DeviceResponse
{
}

public class CoverCalibratorCloseCoverResponse : DeviceResponse
{
}

public class CoverCalibratorHaltCoverResponse : DeviceResponse
{
}

public class CoverCalibratorCalibratorOnForm : DeviceRequest
{
    public int Brightness { get; set; }
}

public class CoverCalibratorCalibratorOnResponse : DeviceResponse
{
}

public class CoverCalibratorCalibratorOffForm : DeviceRequest
{
}

public class CoverCalibratorCalibratorOffResponse : DeviceResponse
{
}

public class CoverCalibratorGetBrightnessForm : DeviceRequest
{
}

public class CoverCalibratorGetBrightnessResponse : DeviceResponse
{
    public int Value { get; set; }
}
