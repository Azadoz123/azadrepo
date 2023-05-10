using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API._2.Filters;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API._2.Controllers
{

    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;
        private readonly IProductService _productService;

        public ProductsController(IService<Product> service, IMapper mapper, IProductService productService)
        {
            _service = service;
            _mapper = mapper;
            _productService = productService;
        }

        //GET api/products/GetProductsWithCategory
        //[HttpGet("GetProductsWithCategory")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory() 
        { 
            return CreateActionResult(await _productService.GetProductsWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
         //   var products = await _service.GetAllAsync();
            var products = await _productService.GetAllAsync();

            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            //  return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));

            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
         //   var product = await _service.GetByIdAsync(id);
            var product = await _productService.GetByIdAsync(id);

            if(product == null) {
                return CreateActionResult(CustomResponseDto<ProductDto>.Fail(400, "Bu id'ye sahip ürün bulunamadı."));
            }
            var productsDto = _mapper.Map<ProductDto>(product);
            //  return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
        //    var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));

            var productsDto = _mapper.Map<ProductDto>(product);
            //  return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
     //      await _service.UpdateAsync(_mapper.Map<Product>(productDto));
           await _productService.UpdateAsync(_mapper.Map<Product>(productDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
         //   var product = await _service.GetByIdAsync(id);
            var product = await _productService.GetByIdAsync(id);
        //    await _service.RemoveAsync(product);
            await _productService.RemoveAsync(product);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
