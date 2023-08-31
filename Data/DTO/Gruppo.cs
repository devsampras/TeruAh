using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.DTO
{
    [Table("gruppi")]
    public class Gruppo
    {
        [Key]
        public int Id { get; set; }
        public string descrizione { get; set; }
        public Testamento testamento { get; set; }
        public string colore {get;set;}
        [NotMapped]
        public List<Libro> libri {get;set;}=new List<Libro>();
        public enum Testamento{
            AT,
            NT
        }
    }
}