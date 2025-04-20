using System.Threading.Channels;

namespace MediationWorker;

public class MediationWorker(Channel<NewMediationItem> channel, ILogger<MediationWorker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await channel.Reader.WaitToReadAsync(stoppingToken))
        {
            while (channel.Reader.TryRead(out var item))
            {
                
            }
        }
    }
}