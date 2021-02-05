using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification
{
    public class ProductWithFilteringCount : BaseSpecification<Product>
    {
        public ProductWithFilteringCount(ProductSpecPrams proPrams) 
        :base(x =>
                 (string.IsNullOrEmpty(proPrams.Search) || x.Name.ToLower()
                .Contains(proPrams.Search)) && 
                (!proPrams.BrandId.HasValue || x.ProductBrandId == proPrams.BrandId)&&
                (!proPrams.TypeId.HasValue || x.ProductTypeId == proPrams.TypeId)
             )
        {
        }
    }
}