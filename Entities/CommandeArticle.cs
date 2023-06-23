using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GesConso.Entities
{
    public class CommandeArticle
    {
        [Key]

        [Column("Id_CommandeArticle")]
        public Guid? Id { get; set; }

        [Column("Id_Commande")]
        public Guid? Id_Commande { get; set; }

        [Required(ErrorMessage = "Le champ Article est requis.")]
        [Column("Id_Article")]
        public Guid? Id_Article { get; set; }

        [Required(ErrorMessage = "Le champ quantité est requis.")]
        [Column("Quantite")]
        public int? Quantite { get; set; }

        [Column("CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [Column("DeletedAt")]
        public DateTime? DeletedAt { get; set; }


    }

}
