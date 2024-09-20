using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyHostedService.Service
{
    public class HostedService : IHostedService, IDisposable
    {
        private Timer timer;

        public void Dispose()
        {
            timer=null;
        }

        private void RunningProject(object state)
        {
            Console.WriteLine($"{DateTime.Now:U} - My Hosted Project is running\n");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested) {
                timer = new Timer(RunningProject, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            }
            return Task.CompletedTask;

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.Now:U} - My Hosted Project stopped\n");
            return Task.CompletedTask;
        }
    }
}
