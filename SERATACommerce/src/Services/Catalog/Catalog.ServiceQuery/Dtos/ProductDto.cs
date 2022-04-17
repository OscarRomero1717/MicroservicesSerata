

namespace Catolog.ServiceQuery
{
    public class ProductDto
    {
         public int ProductId { get; set; }

        public string NameProduct { get; set; } 

        public string DescriptionProduct { get; set; }

        public int Price { get; set; }

        public ProductInStockDto stock { get; set; }

    }
}
