using Blog.Entities.Concrete;
using Blog.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace Blog.Entities.Dtos
{
    public class CatergoryListDto : DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}
