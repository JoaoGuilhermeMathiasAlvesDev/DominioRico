﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoCore.Data
{
    public interface IRepository  <T> : IDisposable where T : IAggregateRoot
    {

        IUnitofWork UnitofWork { get; }
    }

}