using Parser_2022_;

namespace BackgroundParsers
{
    public class BackgroundParse : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Parse1.cherkassy();
            await Task.Delay(6000);
            Parse1.zakarpattia();
        }
    }
}