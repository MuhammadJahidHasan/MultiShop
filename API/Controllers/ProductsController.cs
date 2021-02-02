using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
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
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {

            return Ok(await _repo.ListAllAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {

            return Ok(await _repo.GetByIdAsync(id));
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