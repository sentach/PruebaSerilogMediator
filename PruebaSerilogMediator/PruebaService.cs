using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PruebaSerilogMediator.Request;

namespace PruebaSerilogMediator
{
    internal class PruebaService : IHostedService
    {
        private readonly ILogger<PruebaService> _logger;
        private readonly IMediator _mediator;
        public PruebaService(ILogger<PruebaService> log, IMediator mediator) 
        {
            _logger = log;
            _mediator = mediator;
        }
        Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Inciando el servicio");
            var req = new InitialRequest { Nombre = "Prueba" };
            _mediator.Send(req, cancellationToken);
            return Task.CompletedTask;
        }

        Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Parando el servicio");
            var req = new FinalRequest { Despedida = "Hasta pronto" };
            _mediator.Send(req, cancellationToken);
            return Task.CompletedTask;
        }
    }
}