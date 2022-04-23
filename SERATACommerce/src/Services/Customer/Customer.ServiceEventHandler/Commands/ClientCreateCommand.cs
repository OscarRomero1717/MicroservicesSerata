using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.ServiceEventHandler.Commands
{
    public class ClientCreateCommand :  INotification
    {
        public string ClientName { get; set; }
    }
}
