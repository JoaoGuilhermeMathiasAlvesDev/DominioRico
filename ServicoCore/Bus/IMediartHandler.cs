using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoCore.Bus
{
    public interface IMediartHandler
    {
        Task PublicarEvento<T>(T evento) where T : class;
    }
}
