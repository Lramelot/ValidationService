using ServiceValidation.Service.Articles.Commands;

namespace ServiceValidation.Presentation.Models.Article
{
    public class Create
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateArticle ToCommand()
        {
            return new CreateArticle
            {
                Name = Name,
                Description = Description
            };
        }
    }
}