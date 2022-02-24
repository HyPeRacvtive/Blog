using Blog.Entities.Concrete;
using Blog.Entities.Dtos;
using Blog.Shared.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int categoryId);
        Task<IDataResult<CatergoryListDto>> GetAll();
        Task<IDataResult<CatergoryListDto>> GetAllByNoneDeleted();
        Task<IDataResult<CatergoryListDto>> GetAllByNoneDeletedAndActive();
        Task<IResult> Add(CategoryAddDto categoryAddDto,string createdByName);
        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IResult> Delete(int CategoryId, string modifiedByName);
        Task<IResult> HardDelete(int CategoryId);
    }
}
