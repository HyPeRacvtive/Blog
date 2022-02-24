
using Blog.Data.Abstract;
using Blog.Data.Concrete;
using Blog.Data.Concrete.EFCore.Contexts;
using Blog.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Services.Concrete.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<BlogContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            return serviceCollection;
        }
    }
}
