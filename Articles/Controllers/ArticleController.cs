using Articles.Models;
using Articles.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Articles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRep _articleRep;
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(ILogger<ArticleController> logger, IArticleRep articleRep)
        {
            _logger = logger;
            _articleRep = articleRep;
        }

        [HttpGet]
        public IActionResult GetArticles()
        {
            _logger.LogInformation("Fetching all articles.");
            return Ok(_articleRep.GetArticles());
        }
        [HttpPost]
        public IActionResult AddArticle(Article article)
        {
            _logger.LogInformation("Adding a new article.");
            return Ok(_articleRep.AddArticle(article));
        }
        //[HttpPost]
        //public IActionResult RemoveArticle(int id)
        //{
        //    _logger.LogInformation("Removing an article.");
        //    return Ok(_articleRep.RemoveArticle(id));
        //}
    }
}
