using MediatR;
using Microsoft.Extensions.Logging;
using PruebaSerilogMediator.Request;

namespace PruebaSerilogMediator.Handles;

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
