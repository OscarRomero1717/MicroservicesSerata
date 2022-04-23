using Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.PersitenceDataBase.configuration
{
    public  class ClientConfiguration
    {

        public ClientConfiguration(EntityTypeBuilder<Client> entity) 
        {
            entity.HasKey(x => x.ClientId);
            entity.Property(x => x.ClientName).HasMaxLength(100).IsRequired();

          
        }
    }
}
