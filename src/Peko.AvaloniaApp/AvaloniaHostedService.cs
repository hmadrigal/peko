using Avalonia;
using Avalonia.Controls.Templates;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Peko.AvaloniaApp
{
    internal class AvaloniaHostedService : IHostedService
    {
        private CancellationTokenSource? _cancellationToken;
        private readonly IServiceProvider _serviceProvider;
        private readonly IHostApplicationLifetime _lifetime;
        private readonly ILogger _logger;

        public AvaloniaHostedService(IServiceProvider serviceProvider, IHostApplicationLifetime lifetime, ILogger<AvaloniaHostedService> logger)
        {
            _serviceProvider = serviceProvider;
            _lifetime = lifetime;
            _logger = logger;

            _lifetime.ApplicationStopping.Register(OnApplicationStopping);
        }

        private void OnApplicationStopping()
        {
            _logger.LogDebug("Stopping application");
            if (_cancellationToken != null && !_cancellationToken.IsCancellationRequested)
                _cancellationToken.Cancel();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            _cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            var avaloniaUiTask = Task.Run(() =>
            {

                var args = Environment.GetCommandLineArgs();

                _logger.LogDebug("Starting application");

                var appBuilder = Program.BuildAvaloniaApp(_serviceProvider);
                appBuilder.StartWithClassicDesktopLifetime(args);

                _lifetime.StopApplication();

            }, _cancellationToken.Token);

            if (avaloniaUiTask.IsCompleted)
                return avaloniaUiTask;

            return Task.CompletedTask;

        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            if (_cancellationToken != null && !_cancellationToken.IsCancellationRequested)
                _cancellationToken.Cancel();

            return Task.CompletedTask;
        }
    }
}
