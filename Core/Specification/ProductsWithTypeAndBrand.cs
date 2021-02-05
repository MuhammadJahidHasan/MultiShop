using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypeAndBrand : BaseSpecification<Product>
    {
        public ProductsWithTypeAndBrand(ProductSpecPrams proPrams)

             :base(x =>
             
                (!proPrams.BrandId.HasValue || x.ProductBrandId == proPrams.BrandId)&&
                (!proPrams.TypeId.HasValue || x.ProductTypeId == proPrams.TypeId)
             )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(proPrams.PageSize * (proPrams.PageIndex-1), proPrams.PageSize);
            
            if(!string.IsNullOrEmpty(proPrams.Sort)){

                 switch(proPrams.Sort){

                     case "priceAsc":
                           AddOrderBy(p => p.Price);
                           break;
                     case "priceDesc":
                           AddOrderByDesc(p => p.Price);
                           break;
                     default:
                           AddOrderBy(x => x.Name);
                           break;            
                 }


            }
           
        }

        public ProductsWithTypeAndBrand(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}