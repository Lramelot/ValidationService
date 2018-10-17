using Microsoft.EntityFrameworkCore;
using ServiceValidation.Core.Domain;

namespace ServiceValidation.Repo
{
    public class InMemoryContext : DbContext
    {
        public InMemoryContext(DbContextOptions<InMemoryContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}