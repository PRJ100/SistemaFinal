using System.ComponentModel.DataAnnotations;

namespace ModeloDeDados.Classes
{
    public class Banco
    {
        [Key]
        public int BancoId { get; set; }
        [StringLength(50)]
        public string Nome { get; set; }
        public int Codigo { get; set; }
    }
}
