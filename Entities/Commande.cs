using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GesConso.Entities
{
    public class Commande
    {
        [Key]
        [Column("Id_Commande")]
        public DateTime? Id { get; set; }
        [NotMapped]
        public string FormattedId => Id?.ToString("yyyyMMdd");


        [Column("DateCommande")]
        public DateTime? DateCommande { get; set; }

        [Column("PrixHtva")]
        public double? PrixHtva { get; set; }

        [Column("PrixTvaC")]
        public double? PrixTvaC { get; set; }

        [Column("CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [Column("DeletedAt")]
        public DateTime? DeletedAt { get; set; }


    }

}
