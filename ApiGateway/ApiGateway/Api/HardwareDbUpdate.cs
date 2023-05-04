using Timer = System.Timers.Timer;


namespace ApiGateway.Api;

public class HardwareDbUpdate : BackgroundService
{
    private readonly HttpClient _httpClient;
    private Timer _timer;

    public HardwareDbUpdate(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _timer = new Timer(TimeSpan.FromMinutes(1).TotalMilliseconds);
        _timer.Elapsed += async (sender, e) => await UpdateHardwareDatabase();
        _timer.Start();

        return Task.CompletedTask;
    }

    private async Task UpdateHardwareDatabase()
    {
        if (DateTime.UtcNow.Hour == 0 && DateTime.UtcNow.Minute == 0)
        {
            await _httpClient.PostAsync("http://hardware_info_collector/update-hardware-database", null);
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _timer?.Stop();
        await base.StopAsync(stoppingToken);
    }
}