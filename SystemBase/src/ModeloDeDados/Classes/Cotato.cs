using System.ComponentModel.DataAnnotations;

namespace ModeloDeDados.Classes
{
    public class Cotato
    {
        [Key]
        public int ContatoId { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(16)]
        public string Numero { get; set; }
        [StringLength(25)]
        public string Tipo { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}