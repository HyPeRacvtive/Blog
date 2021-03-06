using AutoMapper;
using Blog.Data.Abstract;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos;
using Blog.Services.Abstract;
using Blog.Shared.Utilities.Results.Abstract;
using Blog.Shared.Utilities.Results.ComplexTypes;
using Blog.Shared.Utilities.Results.Concrete;
using System;
using System.Threading.Tasks;

namespace Blog.Services.Concrete
{
    public class ArticleManager : IArticleService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(ArticleAddDto ArticleAddDto, string createdByName)
        {
            var article = _mapper.Map<Article>(ArticleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserId = 1;
            await _unitOfWork.Articles.AddAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{ArticleAddDto.Title} başlıklı makale başarıyla eklenmiştir");
        }

        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var result = await _unitOfWork.Articles.AnyAsync(a => a.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
                article.IsDeleted = true;
                article.ModifiedByName = modifiedByName;
                article.ModifiedDate = DateTime.Now;
                await _unitOfWork.Articles.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{article.Title} başlıklı makale başarıyla Silinmiştir");
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, "Böyle Bir Makale Bulunamadı", null);
        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId, a => a.User, a => a.Category);
            if (article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, "Böyle Bir Makale Bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(null, a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            };
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler Bulunamadı", null);

        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var result = await _unitOfWork.Categories.AnyAsync(c => c.Id == categoryId);
            if (result)
            {
                var articles = await _unitOfWork.Articles.GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted && a.IsActive, a => a.User, a => a.Category);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success
                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler Bulunamadı", null);
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Böyle Bir Kategori Bulunamadı", null);

        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNoneDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => a.IsDeleted == false, a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            };
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler Bulunamadı", null);

        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNoneDeletedAndActive()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted && a.IsDeleted, a => a.User, a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            };
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler Bulunamadı", null);
        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var result = await _unitOfWork.Articles.AnyAsync(a => a.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);

                await _unitOfWork.Articles.DeleteAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{article.Title} başlıklı makale başarıyla Silinmiştir");
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, "Böyle Bir Makale Bulunamadı", null);
        }

        public async Task<IResult> Update(ArticleUpdateDto ArticleUpdateDto, string modifiedByName)
        {
            var article = _mapper.Map<Article>(ArticleUpdateDto);
            article.ModifiedByName = modifiedByName;
            await _unitOfWork.Articles.UpdateAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{ArticleUpdateDto.Title} başlıklı makale başarıyla Veritabanından Silinmiştir");
        }
    }
}
