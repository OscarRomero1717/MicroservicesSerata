

namespace CatologDomain
{
    public class Product
    {
         public int ProductId { get; set; }

        public string NameProduct { get; set; } 

        public string DescriptionProduct { get; set; }

        public int Price { get; set; }

        public ProductInStock stock { get; set; }

    }
}
