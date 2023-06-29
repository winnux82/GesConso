using GesConso.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GesConso.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class CommandeController : ControllerBase
    {
        private readonly Database context;

        public CommandeController(Database context)
        {
            this.context = context;
        }

        // GetAll
        [HttpGet]
        
        public IActionResult GetAll()
        {
            var commandes = this.context.Commandes.ToList();
            return StatusCode(StatusCodes.Status200OK, commandes);
        }
        // Récupérer une commande par son ID
        [HttpGet("get/{id}")]
        public IActionResult Get(Guid id)
        {
            var commande = this.context.Commandes.Find(id);

            if (commande == null)
            {
                Console.WriteLine("Commande not found.");
                return NotFound("Commande not found.");
            }

            Console.WriteLine(commande); // Afficher la commande dans la console du serveur

            return Ok(commande);
        }



        // Ajout d'une commande
        [HttpPost]
        
        public IActionResult Add([FromBody] Commande commande)
        {
            if (commande != null)
            {
                this.context.Commandes.Add(commande);
                this.context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, null);
            }
            else
            {
                // La commande est null, vous pouvez retourner un code d'erreur approprié
                return StatusCode(StatusCodes.Status400BadRequest, "Commande is null.");
            }
        }


        // Modification d'une commande
        [HttpPost]
        
        public IActionResult Update(Commande updatedCommande)
        {
            var commande = context.Commandes.Find(updatedCommande.Id);

            if (commande == null)
            {
                return NotFound("Commande not found.");
            }

            commande.Id_Date = updatedCommande.Id_Date;
            commande.DateCommande = updatedCommande.DateCommande;
            commande.PrixHtva = updatedCommande.PrixHtva;
            commande.PrixTvaC = updatedCommande.PrixTvaC;
            commande.CreatedAt = updatedCommande.CreatedAt;
            commande.UpdatedAt = updatedCommande.UpdatedAt;
            commande.DeletedAt = updatedCommande.DeletedAt;


            this.context.Commandes.Update(commande);
            this.context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, null);
        }

        // Effacer une commande
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Delete(Commande com)
        {
            try
            {
                var commande = this.context.Commandes.Find(com.Id);

                if (commande == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Commande not found.");
                }

                this.context.Commandes.Remove(commande);
                this.context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Impossible d'effacer cette commande, il y a des articles liés à cette commande");
            }

        }



    }
}
