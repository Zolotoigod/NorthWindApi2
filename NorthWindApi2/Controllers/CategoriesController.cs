using Microsoft.AspNetCore.Mvc;
using NorthWindApi2.DTO;
using NorthWindApi2.Services;

namespace NorthWindApi2.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService categoriesService;
        //private readonly ICategoriesPictureService pictureService;

        public CategoriesController(ICategoriesService categoriesService/*, ICategoriesPictureService pictureService*/)
        {
            this.categoriesService = categoriesService;
            //this.pictureService = pictureService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MyErrorMessage), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CategoryRequest request)
        {
            try
            {
                var id = await this.categoriesService.Create(request);
                return this.Ok(id);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex);
            }
        }

        [HttpGet("{offset}/{limit}")]
        [ProducesResponseType(typeof(IAsyncEnumerable<CategoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MyErrorMessage), StatusCodes.Status400BadRequest)]
        public async IAsyncEnumerable<CategoryResponse> GetCollection([FromRoute] int offset, [FromRoute] int limit)
        {
            var productCount = await categoriesService.GetCount();
            Response.Headers.Add(Defines.Total, productCount.ToString());
            await foreach (var category in this.categoriesService.GetCollection(offset, limit))
            {
                yield return category;
            }
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MyErrorMessage), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromRoute] int categoryId)
        {
            try
            {
                return this.Ok(await this.categoriesService.Get(categoryId));
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MyErrorMessage), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] int categoryId, [FromBody] CategoryRequest request)
        {
            try
            {
                await this.categoriesService.Update(categoryId, request);
                return this.Ok();
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        [HttpDelete("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MyErrorMessage), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] int categoryId)
        {
            try
            {
                await this.categoriesService.Destroy(categoryId);
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex);
            }
        }

        [HttpPut("{categoryId}/picture")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MyErrorMessage), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPicture([FromRoute] int categoryId)
        {
            try
            {
                //await this.pictureService.UpdatePicture(categoryId, Request.Body, (int)Request.ContentLength!);
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex);
            }
        }

        [HttpGet("{categoryId}/picture")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MyErrorMessage), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPicture(int categoryId)
        {
            try
            {
                /*var stream = await this.pictureService.ShowPicture(categoryId);
                var picture = new byte[stream.Length];
                await stream.ReadAsync(picture);

                var result = this.File(picture, "image/bmp", $"picture{categoryId}.bmp");
                return result;*/
                return Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex);
            }
        }

        [HttpDelete("{categoryId}/picture")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MyErrorMessage), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePicture(int categoryId)
        {
            try
            {
                //await this.pictureService.DestroyPicture(categoryId);
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex);
            }
        }
    }
}