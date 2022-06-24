using Microsoft.AspNetCore.Mvc;
using NorthWindApi2.DTO;
using NorthWindApi2.Services;

namespace NorthWindApi2.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService service)
        {
            this.productService = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MyErrorMessage), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct(ProductRequest product)
        {
            try
            {
                var id = await this.productService.CreateProduct(product);
                return this.Ok(id);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        [HttpGet("{offset}/{limit}")]
        [ProducesResponseType(typeof(IAsyncEnumerable<ProductResponse>), StatusCodes.Status200OK)]
        public async IAsyncEnumerable<ProductResponse> GetCollection([FromRoute] int offset, [FromRoute] int limit)
        {
            var productCount = await productService.GetCount();
            Response.Headers.Add("totalProduct", productCount.ToString());
            await foreach (var product in this.productService.GetCollection(offset, limit))
            {
                yield return product;
            }
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MyErrorMessage), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromRoute] int productId)
        {
            try
            {
                return this.Ok(await this.productService.Get(productId));
            }
            catch (Exception)
            {
                return BadRequest(); // added handler
            }
        }

        [HttpPut("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MyErrorMessage), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] int productId, [FromBody] ProductRequest request)
        {
            try
            {
                await this.productService.UpdateProduct(productId, request);
                return this.Ok();
            }
            catch (Exception)
            {
                return BadRequest(); // added handler
            }
        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MyErrorMessage), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] int productId)
        {
            try
            {
                await this.productService.DestroyProduct(productId);
                return this.Ok();
            }
            catch (Exception)
            {
                return BadRequest(); // added handler
            }
        }
    }
}
