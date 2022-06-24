using Microsoft.AspNetCore.Mvc;
using NorthWindApi2.DTO;
using NorthWindApi2.Services;

namespace NorthWindApi2.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class BlogArticlesController : ControllerBase
    {
        private readonly IBloggingService blogService;
        private readonly ILinkService linkService;
        private readonly ICommentsService commentService;

        public BlogArticlesController(
            IBloggingService blogService,
            ILinkService linkServic,
            ICommentsService commentService)
        {
            this.blogService = blogService;
            this.linkService = linkServic;
            this.commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArticleRequest article)
        {
            try
            {
                return this.Ok(await this.blogService.Create(article));
            }
            catch (Exception)
            {
                return this.BadRequest("Invalid request data");
            }
        }

        [HttpGet("{articleId}")]
        public async Task<IActionResult> Find([FromRoute] int articleId)
        {
            try
            {
                return this.Ok(await this.blogService.FindById(articleId));
            }
            catch (Exception)
            {
                return this.UnprocessableEntity(string.Format(Defines.ErrorMessage.NotFoundTemplate, "Article", articleId));
            }
        }

        [HttpPut("{articleId}")]
        public async Task<IActionResult> Update([FromRoute] int articleId, [FromBody] ArticleRequest article)
        {
            try
            {
                await this.blogService.Update(articleId, article);
                return this.Ok();
            }
            catch (Exception)
            {
                return this.UnprocessableEntity(string.Format(Defines.ErrorMessage.NotFoundTemplate, "Article", articleId));
            }
        }

        [HttpDelete("{articleId}")]
        public async Task<IActionResult> Delete([FromRoute] int articleId)
        {
            try
            {
                await this.blogService.Delete(articleId);
                return this.Ok();
            }
            catch (Exception)
            {
                return this.UnprocessableEntity(string.Format(Defines.ErrorMessage.NotFoundTemplate, "Article", articleId));
            }
        }

        [HttpGet("{offset}/{limit}")]
        public async IAsyncEnumerable<ArticleResponse> FindAny([FromRoute] int offset, [FromRoute] int limit)
        {
            await foreach (var article in this.blogService.FindAll(offset, limit))
            {
                yield return article;
            }
        }

        [HttpPost("{articleId}/products/{productId}")]
        public async Task<IActionResult> CreateLink([FromRoute] int articleId, [FromRoute] int productId)
        {
            try
            {
                return this.Ok(await this.linkService.CreateLink(articleId, productId));
            }
            catch (InvalidOperationException ex)
            {
                return this.UnprocessableEntity(ex.Message);
            }
        }

        [HttpGet("{articleId}/products")]
        public async IAsyncEnumerable<ProductResponse> GetRelatedProduct([FromRoute] int articleId)
        {
            await foreach (var product in this.linkService.GetRelatedProduct(articleId))
            {
                yield return product;
            }
        }

        [HttpDelete("{articleId}/products/{productId}")]
        public async Task<IActionResult> RemoveLick([FromRoute] int articleId, [FromRoute] int productId)
        {
            try
            {
                await this.linkService.RemoveLink(articleId, productId);
                return this.Ok();
            }
            catch (InvalidOperationException ex)
            {
                return this.UnprocessableEntity(ex.Message);
            }
        }

        [HttpPost("{articleId}/comments")]
        public async Task<IActionResult> AddComment([FromRoute] int articleId, [FromBody] string text)
        {
            try
            {
                return this.Ok(await this.commentService.AddComment(articleId, text));
            }
            catch (InvalidOperationException ex)
            {
                return this.UnprocessableEntity(ex.Message);
            }
        }

        [HttpGet("{articleId}/comments")]
        public async IAsyncEnumerable<ArticleCommentResponse> ReadArticleComment([FromRoute] int articleId)
        {
            await foreach (var comment in this.commentService.GetAllComments(articleId))
            {
                yield return comment;
            }
        }

        [HttpPut("{commentId}/comments")]
        public async Task<IActionResult> UpdateComment([FromRoute] int commentId, [FromBody] string text)
        {
            try
            {
                await this.commentService.UpdateComment(commentId, text);
                return this.Ok();
            }
            catch (InvalidOperationException ex)
            {
                return this.UnprocessableEntity(ex.Message);
            }
        }

        [HttpDelete("{commentId}/comments")]
        public async Task<IActionResult> DleteComment([FromRoute] int commentId)
        {
            try
            {
                await this.commentService.DeleteComment(commentId);
                return this.Ok();
            }
            catch (InvalidOperationException ex)
            {
                return this.UnprocessableEntity(ex.Message);
            }
        }
    }
}
