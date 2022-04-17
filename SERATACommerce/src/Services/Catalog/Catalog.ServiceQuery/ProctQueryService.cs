using Catalog.PersistenceDataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.ServiceQuery
{
    public class ProctQueryService
    {

        private readonly AplicationDBContext _context ;
        public  ProctQueryService (AplicationDBContext context) 
        {
            _context = context;
        }


    }
}
