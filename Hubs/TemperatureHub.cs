using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class TemperatureHub : Hub
{
    public async Task SendTemperatureData(string timestamp, string temperature)
    {
        await Clients.All.SendAsync("ReceiveTemperatureData", timestamp, temperature);
    }
}
