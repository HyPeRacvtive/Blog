using Blog.Entities.Concrete;
using Blog.Shared.Entities.Abstract;
using Blog.Shared.Utilities.Results.ComplexTypes;
using System.Collections.Generic;

namespace Blog.Entities.Dtos
{
    public class ArticleListDto:DtoGetBase
    {
        public IList<Article> Articles { get; set; }

    }
}
