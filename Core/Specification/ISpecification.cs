using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification
{
    public interface ISpecification<T> 
    {
        List<Expression<Func<T, object>>> Includes{get;}
        Expression<Func<T , bool>> Criteria{get;}
        Expression<Func<T , object>> OrderBy{get;}
        Expression<Func<T , object>> OrderByDesc{get;}
        int Take{get;}
        int Skip{get;}
        bool IsPagingEnabled{get;}
        
    }
}