using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GesConso.Entities;
using System.Linq;

namespace GesConso.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly Database context;

        public ArticleController(Database context)
        {
            this.context = context;
        }

        // GetAll
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            var articles = this.context.Articles.ToList();
            return StatusCode(StatusCodes.Status200OK, articles);
        }
        // Ajout d'un article
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Add(Article article)
        {
            if (article != null)
            {
                this.context.Articles.Add(article);
                this.context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, null);
            }
            else
            {
                // L'article est null, vous pouvez retourner un code d'erreur approprié
                return StatusCode(StatusCodes.Status400BadRequest, "Article is null.");
            }
        }

    }
}
