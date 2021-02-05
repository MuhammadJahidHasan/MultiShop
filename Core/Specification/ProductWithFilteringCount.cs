using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification
{
    public class ProductWithFilteringCount : BaseSpecification<Product>
    {
        public ProductWithFilteringCount(ProductSpecPrams proPrams) 
        :base(x =>
             
                (!proPrams.BrandId.HasValue || x.ProductBrandId == proPrams.BrandId)&&
                (!proPrams.TypeId.HasValue || x.ProductTypeId == proPrams.TypeId)
             )
        {
        }
    }
}