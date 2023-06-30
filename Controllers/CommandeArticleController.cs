using GesConso.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GesConso.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommandeArticleController : ControllerBase
    {
        private readonly Database context;

        public CommandeArticleController(Database context)
        {
            this.context = context;
        }

        // GetAll
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll(Guid commandId)
        {
            var commandeArticles = this.context.CommandeArticle.Where(x => x.Id_Commande == commandId).ToList();
            return StatusCode(StatusCodes.Status200OK, commandeArticles);
        }

        // Ajout d'une commandeArticle
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Add([FromBody] CommandeArticle commandeArticle)
        {
            Console.WriteLine(commandeArticle);
            if (commandeArticle.Id_Article != null && commandeArticle.Id_Commande != null)
            {

                this.context.CommandeArticle.Add(commandeArticle);
                this.context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, null);
            }
            else
            {
                // La commandeArticle est null, vous pouvez retourner un code d'erreur approprié
                return StatusCode(StatusCodes.Status400BadRequest, "Commande is null.");
            }
        }


        // Modification d'une commandeArticle
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Update(CommandeArticle updatedCommandeArticle)
        {
            var commandeArticle = context.CommandeArticle.Find(updatedCommandeArticle.Id);

            if (commandeArticle == null)
            {
                return NotFound("Commande not found.");
            }

            commandeArticle.Quantite = updatedCommandeArticle.Quantite;
            commandeArticle.CreatedAt = updatedCommandeArticle.CreatedAt;
            commandeArticle.UpdatedAt = updatedCommandeArticle.UpdatedAt;
            commandeArticle.DeletedAt = updatedCommandeArticle.DeletedAt;


            this.context.CommandeArticle.Update(commandeArticle);
            this.context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, null);
        }

        // Effacer un commandeArticle
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Delete(CommandeArticle artCom)
        {
            var commandeArticle = this.context.CommandeArticle.Find(artCom.Id);

            if (commandeArticle == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Commande d'article not found.");
            }

            this.context.CommandeArticle.Remove(commandeArticle);
            this.context.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, null);


        }



    }
}
