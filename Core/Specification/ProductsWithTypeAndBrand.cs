using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypeAndBrand : BaseSpecification<Product>
    {
        public ProductsWithTypeAndBrand()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}