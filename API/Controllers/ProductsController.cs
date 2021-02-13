using System.Collections.Generic;
using System.Threading.Tasks;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _repo;
        private readonly IGenericRepository<ProductType> _typerepo;
        private readonly IGenericRepository<ProductBrand> _brandrepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> repo,
        IGenericRepository<ProductType> typerepo,
        IGenericRepository<ProductBrand> brandrepo,
        IMapper mapper)
        {
            _repo = repo;
            _typerepo = typerepo;
           _brandrepo = brandrepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<Product>>> GetProducts(
            [FromQuery] ProductSpecPrams proPrams)
        {
            var spec = new ProductsWithTypeAndBrand(proPrams);
            var countSpec = new ProductWithFilteringCount(proPrams);
            var totalItems = await _repo.CountAsync(countSpec);
            var products = await _repo.ListAllAsyncWithSpec(spec);
             var data = _mapper
                 .Map<IReadOnlyList<Product>, IReadOnlyList<Product>>(products);
            return Ok(new Pagination<Product>(proPrams.PageIndex, proPrams.PageSize, 
                   totalItems, data));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductsWithTypeAndBrand(id);
            return Ok(await _repo.GetWithEntitySpec(spec));
        }

         [HttpGet("types")]
         public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
         {

             return Ok(await _typerepo.ListAllAsync());
         }


        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {

            return Ok(await _brandrepo.ListAllAsync());
        }

    }
}