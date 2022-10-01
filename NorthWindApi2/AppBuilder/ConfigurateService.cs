using Microsoft.EntityFrameworkCore;
using NorthWindApi2.Services;
using NorthWindEFRepository;
using NorthWindEFRepository.Repositories;

namespace NorthWindApi2.AppBuilder
{
    public static class ServiceConfigurator
    {
        public static WebApplicationBuilder ConfigurateService(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<ICategoriesService, CategoriesService>()
                .AddSingleton<ICategoriesRepository, CategoriesRepository>()
                .AddSingleton<IProductService, ProductService>()
                .AddSingleton<IProductRepository, ProductsRepository>()
                .AddSingleton<IEmployeeService, EmployeeService>()
                .AddSingleton<IEmployeeRepository, EmployeeRepository>()
                .AddSingleton<IPictureService, CategoriesPictureService>()
                .AddSingleton<IPictureRepository, CategoriesRepository>()
                .AddSingleton<IBlogArticleRepository, BlogArticleRepository>()
                .AddSingleton<ILinkRepository, LinkRepository>()
                .AddSingleton<ICommentRepository, CommentRepository>()
                .AddSingleton<IBlogArticleService, BlogArticleService>()
                .AddSingleton<ICommentsService, CommentsService>()
                .AddSingleton<ILinkService, LinkService>();
                //.AddSingleton<ILogger,>();
            
            return builder;
        }

        public static WebApplicationBuilder ConfigureDB(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddDbContext<NorthWindContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb")), ServiceLifetime.Singleton)
                .AddDbContext<BloggingContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Blogging")), ServiceLifetime.Singleton);

            return builder;
        }
    }
}
