using System;
using System.Linq.Expressions;
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

        public ProductsWithTypeAndBrand(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}