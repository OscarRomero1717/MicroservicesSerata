using Catalog.PersistenceDataBase;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Testing
{
    static class AplicationBdcontextInMemory
    {
        public static  AplicationDBContext Get()
        {
            var option = new DbContextOptionsBuilder<AplicationDBContext>().UseInMemoryDatabase(databaseName: $"Catalog.Db").Options;
             return new AplicationDBContext(option);

        }
    }
}
