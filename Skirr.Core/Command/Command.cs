namespace Skirr.Command;

public interface Command<REQ, RES>
{
    public void Execute(REQ request, RES result);
}
