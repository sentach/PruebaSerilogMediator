using MediatR;
using Microsoft.Extensions.Logging;

namespace PruebaSerilogMediator.Request
{
    public class InitialRequest : IRequest
    {

        public string? Nombre { get; set; }

        public class Handler : IRequestHandler<InitialRequest>
        {
            private readonly ILogger<Handler> _logger;
            public Handler(ILogger<Handler> logger)
            {
                _logger = logger;
            }
            public Task Handle(InitialRequest request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("El request recibido es {nombre}", request.Nombre);
                return Task.CompletedTask;
            }
        }
    }
}
