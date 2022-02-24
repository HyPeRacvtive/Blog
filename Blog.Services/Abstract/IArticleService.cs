using Blog.Entities.Dtos;
using Blog.Shared.Utilities.Results.Abstract;
using System.Threading.Tasks;

namespace Blog.Services.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> Get(int articleId);
        Task<IDataResult<ArticleListDto>> GetAll();
        Task<IDataResult<ArticleListDto>> GetAllByNoneDeleted();
        Task<IDataResult<ArticleListDto>> GetAllByNoneDeletedAndActive();
        Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId);


        Task<IResult> Add(ArticleAddDto ArticleAddDto, string createdByName);
        Task<IResult> Update(ArticleUpdateDto ArticleUpdateDto, string modifiedByName);
        Task<IResult> Delete(int articleId, string modifiedByName);
        Task<IResult> HardDelete(int articleId);
    }
}
