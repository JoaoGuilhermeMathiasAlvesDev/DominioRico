using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoCore.Messages
{
    public abstract class Event : Message,INotification 
    {
        public DateTime TimesTamp { get; set; }

        protected Event() 
        {
            TimesTamp = DateTime.Now;        
        }
    }
}
