using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceValidation.Core.Domain;
using ServiceValidation.Service.Articles.Commands;

namespace ServiceValidation.Service.Articles
{
    public interface IArticleService
    {
        Task CreateArticleAsync(CreateArticle command);
        Task<IEnumerable<Article>> GetArticles();
    }
}