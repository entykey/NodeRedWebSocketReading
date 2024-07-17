using System;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

public class WebSocketService
{
    private ClientWebSocket _client;
    private readonly string _webSocketUrl = "ws://113.161.84.132:8800/blazor";

    public event Action<string> OnMessageReceived;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _client = new ClientWebSocket();
        try
        {
            await _client.ConnectAsync(new Uri(_webSocketUrl), cancellationToken);
            Console.WriteLine("WebSocket connected successfully.");

            var buffer = new byte[1024 * 4];
            while (_client.State == WebSocketState.Open)
            {
                var result = await _client.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine($"Received message: {message}");
                OnMessageReceived?.Invoke(message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"WebSocket connection failed: {ex.Message}");
        }
    }
}
