using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceValidation.Core.Domain;
using ServiceValidation.Core.Exceptions;
using ServiceValidation.Repo;
using ServiceValidation.Service.Articles.Commands;
using ServiceValidation.Service.Articles.Validators;
using ServiceValidation.Service.Validators;

namespace ServiceValidation.Service.Articles
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task CreateArticleAsync(CreateArticle command)
        {
            Validator.Validate<CreateArticleValidator, CreateArticle>(command);

            var article = new Article
            {
                Name = command.Name,
                Description = command.Description
            };

            await _articleRepository.CreateArticleAsync(article);
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            var articles = await _articleRepository.GetArticlesAsync();
            return articles;
        }
    }
}