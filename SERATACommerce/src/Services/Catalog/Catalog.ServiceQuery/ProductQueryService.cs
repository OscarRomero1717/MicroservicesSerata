using Catalog.PersistenceDataBase;
using Catolog.ServiceQuery;
using Microsoft.EntityFrameworkCore;
using Service.CommonPaging;
using Service.CommonMapping;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Catalog.ServiceQuery
{
    public interface IProdctQueryService
    {
        Task<DataCollection<ProductDto>> GetAllAsync(int page, int take, IEnumerable<int> products = null);
        Task<ProductDto> GetByIdAsync(int id);
    }

    public class ProductQueryService : IProdctQueryService
    {

        private readonly AplicationDBContext _context;
        public ProductQueryService(AplicationDBContext context)
        {
            _context = context;
        }


        public async Task<DataCollection<ProductDto>> GetAllAsync(int page, int take, IEnumerable<int> products = null)
        {
            
                var collection = await _context.Products.Where(x => products == null || products.Contains(x.ProductId))
                .OrderByDescending(x => x.ProductId).GetPagedAsync(page, take);

                return collection.MapTo<DataCollection<ProductDto>>();

        }


        public async Task<ProductDto> GetByIdAsync(int id)
        {
            return (await _context.Products.SingleAsync(x => x.ProductId == id)).MapTo<ProductDto>() ; 

        }

    }
}
