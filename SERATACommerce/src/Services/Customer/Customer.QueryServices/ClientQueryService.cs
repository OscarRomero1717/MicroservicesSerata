
using Customer.Domain;
using Customer.PersitenceDataBase;
using Microsoft.EntityFrameworkCore;
using Service.CommonMapping;
using Service.CommonPaging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.QueryServices
{

    public interface ICustomerService
    {
        Task<DataCollection<ClientDto>> Get(int page, int take, IEnumerable<int> idClient = null);

        Task<ClientDto> GetByID(int id);
    }
    public class ClientQueryService : ICustomerService
    {
        private readonly AplicationDBContext _context;

        public ClientQueryService(AplicationDBContext context)
        {
            _context = context;
        }


        public async Task<DataCollection<ClientDto>> Get(int page, int take, IEnumerable<int> idClient = null)
        {

            var lista = await _context.Client.Where(x => idClient == null || idClient.Contains(x.ClientId))
                .OrderByDescending(x => x.ClientId).GetPagedAsync(page, take);

            return lista.MapTo<DataCollection<ClientDto>>();
        }

        public async Task<ClientDto> GetByID(int id)
        {

            return (await _context.Client.SingleAsync(x => x.ClientId == id)).MapTo<ClientDto>();

        }
    }
}
