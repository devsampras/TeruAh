using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DTO{
    [Table(name:"indice")]
    public class Libro{
        [Key]
        public int id{get;set;}
        public string titolo {get;set;}
        public string sigla {get;set;}
        [Column(name:"gruppo")]
        public int gruppo {get;set;}
    }
}