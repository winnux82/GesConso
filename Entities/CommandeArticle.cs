using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GesConso.Entities
{
    public class CommandeArticle
    {
        [Key]
        [Column("Id_Commande")]
        public Guid? Id_Commande { get; set; }

        [Column("Id_Article")]
        public Guid? Id_Article { get; set; }

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
