using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Api;

public class HardwareDbUpdate : BackgroundService
{
    private readonly HttpClient _httpClient;
    
    public HardwareDbUpdate(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(5, stoppingToken);
            if (DateTime.UtcNow.Hour == 0 && DateTime.UtcNow.Minute == 0)
                await _httpClient.PostAsync("http://localhost:3000/update-hardware-database", null, stoppingToken);
        }
    }
}