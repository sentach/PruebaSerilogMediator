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
                
    }
}
