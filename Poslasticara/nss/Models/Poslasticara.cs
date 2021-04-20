using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace nss.Models
{
    [Table("Poslasticara")]
    public class Poslasticara
    {
        [Key]
        [Column("ID")]
        public int ID {get;set;}
        [Column("Naziv")]
        [MaxLength(255)]
        public string Naziv {get;set;}
        [Column("Kapacitet")]
        public int Kapacitet {get;set;}
        [Column("N")]
        public int N {get;set;}
        [Column("M")]
        public int M {get;set;}
        public virtual List<Stolovi> Stolovii {get;set;}
    }
}