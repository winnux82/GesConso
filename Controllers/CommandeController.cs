﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GesConso.Entities;
using System.Linq;

namespace GesConso.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommandeController : ControllerBase
    {
        private readonly Database context;

        public CommandeController(Database context)
        {
            this.context = context;
        }

        // GetAll
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            var commandes = this.context.Commandes.ToList();
            return StatusCode(StatusCodes.Status200OK, commandes);
        }

        // Ajout d'une commande
        [HttpPost]
        [AllowAnonymous]
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
        [AllowAnonymous]
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
            commande.CreatedAt = updatedCommande.CreatedAt;
            commande.UpdatedAt = updatedCommande.UpdatedAt;
            commande.DeletedAt = updatedCommande.DeletedAt;
 

            this.context.Commandes.Update(commande);
            this.context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, null);
        }

        // Effacer un commande
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Delete(Commande art)
        {
            var commande = this.context.Commandes.Find(art.Id);

            if (commande == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Agent not found.");
            }

            this.context.Commandes.Remove(commande);
            this.context.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, null);


        }



    }
}