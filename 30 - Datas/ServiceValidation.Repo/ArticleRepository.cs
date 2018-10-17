using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceValidation.Core.Domain;

namespace ServiceValidation.Repo
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly InMemoryContext _context;

        public ArticleRepository(InMemoryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> GetArticlesAsync()
        {
            var articles = await _context.Articles.ToListAsync();
            return articles;
        }

        public async Task CreateArticleAsync(Article entity)
        {
            await _context.Articles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}