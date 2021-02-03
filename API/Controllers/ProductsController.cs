using System.Collections.Generic;
using System.Threading.Tasks;
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

        public ProductsController(IGenericRepository<Product> repo,
        IGenericRepository<ProductType> typerepo,
        IGenericRepository<ProductBrand> brandrepo)
        {
            _repo = repo;
            _typerepo = typerepo;
           _brandrepo = brandrepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(
            [FromQuery] ProductSpecPrams proPrams)
        {
            var spec = new ProductsWithTypeAndBrand(proPrams);

            return Ok(await _repo.ListAllAsyncWithSpec(spec));
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