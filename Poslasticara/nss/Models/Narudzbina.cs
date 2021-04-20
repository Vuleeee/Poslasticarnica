using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace nss.Models
{
    [Table("Narudzbina")]
    public class Narudzbina
    {
        [Key]
        [Column("ID")]
        public int ID {get;set;}
        [Column("vrsta")]
        [MaxLength(255)]
        public string Vrsta {get;set;}
        [Column("cena")]
        public int Cena {get;set;}
        [Column("kolicina")]
        public int Kolicina {get;set;}
        
         [JsonIgnore]
        public Stolovi Stolove{get; set;}//stolovi sto
    }
}