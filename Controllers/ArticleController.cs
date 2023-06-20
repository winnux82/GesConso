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
        public IActionResult Add([FromBody] Article article)
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


        // Modification d'un article
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Update(Article updatedArticle)
        {
            var article = context.Articles.Find(updatedArticle.Id);

            if (article == null)
            {
                return NotFound("Article not found.");
            }

            article.Denomination = updatedArticle.Denomination;
            article.Description = updatedArticle.Description;
            article.PuHtva = updatedArticle.PuHtva;
            article.CreatedAt = updatedArticle.CreatedAt;
            article.UpdatedAt = updatedArticle.UpdatedAt;
            article.DeletedAt = updatedArticle.DeletedAt;
 

            this.context.Articles.Update(article);
            this.context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, null);
        }

        // Effacer un article
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Delete(Article art)
        {
            try
            {
                var article = this.context.Articles.Find(art.Id);

                if (article == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Article not found.");
                }

                this.context.Articles.Remove(article);
                this.context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Impossible d'effacer cet article, il est lié à une ou plusieurs commandes");
            }
        }




    }
}
