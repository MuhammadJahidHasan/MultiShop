using System.Linq;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : class
    {

        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
        ISpecification<TEntity> spec){

           var query = inputQuery;


           query = spec.Includes.Aggregate(query, (current,include) => current.Include(include));
           return query;
        }
        
    }
}