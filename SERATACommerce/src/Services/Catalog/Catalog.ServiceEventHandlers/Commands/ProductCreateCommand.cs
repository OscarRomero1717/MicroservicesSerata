using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.ServiceEventHandlers.Commands
{
    public class ProductCreateCommand : INotification
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }
    }
}
