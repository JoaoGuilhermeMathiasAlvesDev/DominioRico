using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoCore.Data
{
    public interface IUnitofWork
    {
        Task<bool> Commit();
    }
}
