using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GesConso.Entities
{
    public class Commande
    {
        [Key]
        [Column("Id_Commande")]
        public Guid? Id { get; set; }

        [Column("Id_Date")]
        public DateTime? Id_Date { get; set; }

        [Column("DateCommande")]
        public DateTime? DateCommande { get; set; }

        [Column("PrixHtva")]
        public double? PrixHtva { get; set; }

        [Column("CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [Column("DeletedAt")]
        public DateTime? DeletedAt { get; set; }


    }

}
