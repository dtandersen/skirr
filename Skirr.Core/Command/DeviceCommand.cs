namespace Skirr.Command;

public abstract class DeviceCommand<REQ, RES> : Command<REQ, RES>
    where REQ : DeviceRequest
    where RES : ErrorResult
{
    public ConfiguredDevices Devices { get; }

    public DeviceCommand(ConfiguredDevices devices)
    {
        Devices = devices;
    }

    public void Execute(REQ request, RES result)
    {
        AlpacaDevice? device = Devices.Find(request.DeviceType, request.DeviceNumber);
        if (device == null)
        {
            result.Invalid(new ErrorDto
            {
                ClientTransactionID = request.ClientTransactionId,
                ServerTransactionID = 0,
                ErrorNumber = 0x401,
                ErrorMessage = $"Invalid device: {request.DeviceType}#{request.DeviceNumber}"
            });
            return;
        }

        ExecuteDevice(device, request, result);
    }

    public abstract void ExecuteDevice(AlpacaDevice device, REQ request, RES result);
}

public class DeviceRequest
{
    public required string DeviceType;
    public required int DeviceNumber;
    public int ClientId;
    public int ClientTransactionId;
}

public class DeviceResult<T> : SuccessResult<T>, ErrorResult
    where T : DeviceDto
{
    public T? Result;

    public ErrorDto? Error;

    public void Invalid(ErrorDto error)
    {
        Error = error;
    }

    public void Success(T result)
    {
        Result = result;
    }
}

public class DeviceDto
{
    public int ClientTransactionID;
    public int ServerTransactionID;
    public int ErrorNumber;
    public string ErrorMessage = "";
}

public interface SuccessResult<RES> where RES : DeviceDto
{
    void Success(RES result);
}

public interface ErrorResult
{
    void Invalid(ErrorDto result);
}

public record ErrorDto
{
    public int ClientTransactionID;
    public int ServerTransactionID;
    public int ErrorNumber;
    public string ErrorMessage = "";
}
