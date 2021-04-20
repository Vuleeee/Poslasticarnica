using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace nss.Models
{  
    [Table("Stolovi")]
    public class Stolovi
    {
        [Key]
        [Column("ID")]
        public int ID{get; set;}

        [Column("ImeRezervacije")]
        [MaxLength(255)]
        public string ImeRezervacije{get; set;}

         [Column("Kapacitet")]
        public int Kapacitet{get; set;}
        [Column("MaxKapacitet")]
        public int MaxKapacitet{get; set;}
        [Column("Pusac")]
        [MaxLength(255)]
        public string Pusac{get; set;}
        [Column("S")]
        public int S{get; set;}
        public virtual List<Narudzbina> Narudzbinaa {get;set;}
        [JsonIgnore]
        public Poslasticara Poslasticara{get; set;}
        
       /*[JsonIgnore]
        public Narudzbina Narudzbina{get; set;}*/
    }
}