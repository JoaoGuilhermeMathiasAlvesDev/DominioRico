using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoCore.Bus
{
    public class MediartHandler : IMediartHandler
    {
        private readonly IMediator _mediator;

        public MediartHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublicarEvento<T>(T evento) where T : class
        {
            await _mediator.Publish(evento);
        }
    }
}
