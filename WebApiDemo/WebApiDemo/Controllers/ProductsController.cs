using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.DataAccess;
using WebApiDemo.Entities;

namespace WebApiDemo.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductDal _productDal;

        public ProductsController(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var products = _productDal.GetAll();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
        {
            try
            {
                //   var product = _productDal.GetAsync(p => p.ProductId == productId);
                var product = _productDal.Get(p => p.ProductId == productId);

                if (product == null)
                {
                    return NotFound($"There is no product with Id = {productId}");
                }
                return Ok(product);
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();

        }
        //[HttpPost("")]
        //public IActionResult Post([FromBody] Product product)
        //{
        //    return Ok(product);
        //}
        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                _productDal.Add(product);
                return new StatusCodeResult(201);
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Put(Product product)
        {
            try
            {
                _productDal.Update(product);
                return Ok(product);
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }

        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            try
            {
                _productDal.Delete(new Product { ProductId = productId});
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }

        [HttpGet("GetProductsWithDetails")]
        public IActionResult GetProductsWithDetails()
        {
            try
            {
              var result =  _productDal.GetProductsWithDetails();

                return Ok(result);
            }
            catch 
            {

                
            }
            return BadRequest();
        }
    }
}
