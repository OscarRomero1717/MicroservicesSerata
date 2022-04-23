using Customer.PersitenceDataBase;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Customer.ServiceEventHandler.Commands;
using System.Threading.Tasks;
using System.Threading;
using Customer.Domain;

namespace Customer.ServiceEventHandler
{
    public class ClientCreateEventHandler :INotificationHandler<ClientCreateCommand>
    {
        private readonly AplicationDBContext _dBContext;
        public ClientCreateEventHandler(AplicationDBContext dBContext) 
        {
            _dBContext = dBContext;
        }

        public async Task Handle (ClientCreateCommand command, CancellationToken cancellationToken) 
        {
            await _dBContext.AddAsync( new Client 
            {
                ClientName= command.ClientName,});

            await _dBContext.SaveChangesAsync();
        
        }

    }
}
