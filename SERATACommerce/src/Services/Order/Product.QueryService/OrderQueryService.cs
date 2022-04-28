using Order.PersistenceDataBase;
using Product.QueryService.Dtos;
using Service.CommonMapping;
using Service.CommonPaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.QueryService
{

    public interface IProductQueryService 
    {
        Task<DataCollection<OrderDetailDto>> Get(int page, int take, IEnumerable<int> ids = null);
    }
    public class OrderQueryService: IProductQueryService
    {
        private readonly AplicationDBContext _context;
        public OrderQueryService(AplicationDBContext context)
        {
            _context = context;
        }
       
        public async Task<DataCollection<OrderDetailDto>> Get(int page, int take, IEnumerable<int> ids = null)
        {

            //var lista = await _context.Detail.Where(x => ids == null || ids.Contains(x.OrderDetailId)).
            //    OrderBy(x => x.OrderDetailId).GetPagedAsync(page, take);

            //return lista.MapTo<DataCollection<OrderDetailDto>>();
            return  new DataCollection<OrderDetailDto>();

        }
    }
}
