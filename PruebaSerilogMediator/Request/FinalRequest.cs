using MediatR;
using Microsoft.Extensions.Logging;

namespace PruebaSerilogMediator.Request
{
    public class FinalRequest : IRequest
    {
        public FinalRequest()
        {
            Despedida = "";
        }
        public string Despedida { get; set; }

        public class Handler : IRequestHandler<FinalRequest>
        {
            private readonly ILogger<Handler> logger;
            public Handler(ILogger<Handler> logger)
            {
                this.logger = logger;
            }

            public Task Handle(FinalRequest request, CancellationToken cancellationToken)
            {
                logger.LogInformation("Nos despedimos diciendo {despedida}", request.Despedida);
                return Task.CompletedTask;
            }
        }
    }
}
