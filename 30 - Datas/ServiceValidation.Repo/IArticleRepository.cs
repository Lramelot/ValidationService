using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceValidation.Core.Domain;

namespace ServiceValidation.Repo
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetArticlesAsync();
        Task CreateArticleAsync(Article entity);
    }
}