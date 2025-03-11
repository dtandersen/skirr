using Shouldly;
using Skirr.Command;
using Skirr.Test.Data;

namespace Skirr.Test;

public class Tests
{
    [Test]
    public void Basic()
    {
        Ascom ascom = new Ascom();
        Connect connect = new Connect(ascom);
        ConnectRequest request = new ConnectRequest()
        {
            DeviceType = "covercalibrator",
            DeviceNumber = 1
        };

        ConnectResult result = new ConnectResult();

        connect.Execute(request, result);

        ascom.DeviceNumber.ShouldBe(1);
        result.ClientTransactionID.ShouldBe(1);
        result.ServerTransactionID.ShouldBe(1);
    }
}
