using AutoMapper;
using Blog.Data.Abstract;
using Blog.Entities.Concrete;
using Blog.Entities.Dtos;
using Blog.Services.Abstract;
using Blog.Shared.Utilities.Results.Abstract;
using Blog.Shared.Utilities.Results.ComplexTypes;
using Blog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category = await _uniteOfWork.Categories.GetAsync(c => c.Id == categoryId, c => c.Articles);
            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "Böyle Bir Kategori Bulunamadı.", new CategoryDto
            {
                Category=null,
                ResultStatus=ResultStatus.Error,
                Message= "Böyle Bir Kategori Bulunamadı."

            });
        }

        public async Task<IDataResult<CatergoryListDto>> GetAll()
        {
            var categories = await _uniteOfWork.Categories.GetAllAsync(null, c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CatergoryListDto>(ResultStatus.Success, new CatergoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<CatergoryListDto>(ResultStatus.Error, "Hiç Bir Kategori Bulunamadı", new CatergoryListDto
            {
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hiç Bir Kategori Bulunamadı"
            });
        }

        public async Task<IDataResult<CatergoryListDto>> GetAllByNoneDeleted()
        {
            var categories = await _uniteOfWork.Categories.GetAllAsync(null, c => !c.IsDeleted, c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CatergoryListDto>(ResultStatus.Success, new CatergoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<CatergoryListDto>(ResultStatus.Error, "Hiç Bir Kategori Bulunamadı", null);
        }

        public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;
            var addedCategory = await _uniteOfWork.Categories.AddAsync(category);
            await _uniteOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success, $" {categoryAddDto.Name} adlı kategori başarıyla eklenmiştir.", new CategoryDto
            {
                Category = addedCategory,
                ResultStatus = ResultStatus.Success,
                Message = $" {categoryAddDto.Name} adlı kategori başarıyla eklenmiştir."
            });
        }

        public async Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
            category.ModifiedByName = modifiedByName;
            var updatedCategory = await _uniteOfWork.Categories.UpdateAsync(category);
            await _uniteOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success, $" {categoryUpdateDto.Name} adlı kategori başarıyla Güncellenmiştir.",new CategoryDto
            {
                Category = updatedCategory,
                ResultStatus = ResultStatus.Success,
                Message = $" {categoryUpdateDto.Name} adlı kategori başarıyla eklenmiştir."
            });


        }

        public async Task<IResult> Delete(int CategoryId, string modifiedByName)
        {
            var category = await _uniteOfWork.Categories.GetAsync(c => c.Id == CategoryId);
            if (category != null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                await _uniteOfWork.Categories.UpdateAsync(category);
                await _uniteOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $" {category.Name} adlı kategori başarıyla Silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle Bir Kategori Bulunamadı.");

        }

        public async Task<IResult> HardDelete(int CategoryId)
        {
            var category = await _uniteOfWork.Categories.GetAsync(c => c.Id == CategoryId);
            if (category != null)
            {
                await _uniteOfWork.Categories.DeleteAsync(category);
                await _uniteOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $" {category.Name} adlı kategori başarıyla veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle Bir Kategori Bulunamadı.");
        }

        public async Task<IDataResult<CatergoryListDto>> GetAllByNoneDeletedAndActive()
        {
            var categories = await _uniteOfWork.Categories.GetAllAsync(null, c => !c.IsDeleted && c.IsActive, c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CatergoryListDto>(ResultStatus.Success, new CatergoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<CatergoryListDto>(ResultStatus.Error, "Hiç Bir Kategori Bulunamadı", null);
        }
    }
}
