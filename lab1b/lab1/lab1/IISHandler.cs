using System.Net.WebSockets;

namespace WebSockets
{
    public class IISHandler
    {
        WebSocket socket;

        public async Task WebSocketRequest(HttpContext context)
        {
            socket = await context.WebSockets.AcceptWebSocketAsync();
            string s = await Receive();
            await Send(s);
            int i = 0;   
            while (socket.State == WebSocketState.Open)
            {
                Thread.Sleep(1000);
                await Send($"[{i++}]");
            }
        }

        private async Task<string> Receive()
        {
            string rc = string.Empty;
            var buffer = new ArraySegment<byte>(new byte[512]);
            var result = await socket.ReceiveAsync(buffer, CancellationToken.None);
            rc = System.Text.Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
            return rc;
        }

        private async Task Send(string s)
        {
            var sendbuffer = new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes($"Ответ: {s}"));
            await socket.SendAsync(sendbuffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
