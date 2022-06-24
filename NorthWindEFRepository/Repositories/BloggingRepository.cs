using NorthWindEFRepository.Contexts;

namespace NorthWindEFRepository.Repositories
{
    public class BloggingRepository
    {
        private readonly BloggingContext context;

        public BloggingRepository(BloggingContext setContext)
        {
            context = setContext;
        }
    }
}
