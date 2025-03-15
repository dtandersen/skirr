
using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using Skirr.Command;

namespace Skirr.Controller;

[ApiController]
public class WebSocketController : ControllerBase
{
    private readonly CommandFactory commandFactory;

    public WebSocketController(CommandFactory commandFactory)
    {
        this.commandFactory = commandFactory;
    }

    [Route("/ws")]
    public async Task Get()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            var command = commandFactory.RegisterClient();
            command.Execute(new RegisterClientRequest
            {
                Client = new WebSocketClient(webSocket)
            });
            await Echo(webSocket);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }

    private static async Task Echo(WebSocket webSocket)
    {
        var buffer = new byte[1024 * 4];
        var receiveResult = await webSocket.ReceiveAsync(
            new ArraySegment<byte>(buffer), CancellationToken.None);

        while (!receiveResult.CloseStatus.HasValue)
        {
            await webSocket.SendAsync(
                new ArraySegment<byte>(buffer, 0, receiveResult.Count),
                receiveResult.MessageType,
                receiveResult.EndOfMessage,
                CancellationToken.None);

            receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);
        }
        Console.WriteLine("websocket closed");
        await webSocket.CloseAsync(
            receiveResult.CloseStatus.Value,
            receiveResult.CloseStatusDescription,
            CancellationToken.None);
    }
}

public class WebSocketClient : SkirrClient
{
    public WebSocket WebSocket { get; init; }

    public WebSocketClient(WebSocket webSocket)
    {
        WebSocket = webSocket;
    }

    public void SetBrightness(int brightness)
    {
        var command = $"{brightness}";
        var buffer = System.Text.Encoding.UTF8.GetBytes(command);
        var segment = new ArraySegment<byte>(buffer);

        WebSocket.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
    }
}
