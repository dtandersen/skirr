namespace Skirr.Command;

public interface Command<REQ, RES>
{
    public RES Execute(REQ request);
}
