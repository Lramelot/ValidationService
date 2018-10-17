using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceValidation.Core.Exceptions;
using ServiceValidation.Presentation.Filters;
using ServiceValidation.Presentation.Models.Article;
using ServiceValidation.Service.Articles;

namespace ServiceValidation.Presentation.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        #region Index

        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetArticles();
            var model = new Index {Articles = articles};

            return View(model);
        }

        #endregion

        #region Create

        [ImportModelState]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Create model)
        {
            var command = model.ToCommand();
            await _articleService.CreateArticleAsync(command);

            return RedirectToAction("Index");
        }

        #endregion
    }
}