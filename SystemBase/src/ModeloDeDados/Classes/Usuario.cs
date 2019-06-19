using System.ComponentModel.DataAnnotations;

namespace ModeloDeDados.Classes
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [StringLength(50)]
        public string Login { get; set; }
        [StringLength(40)]
        public string Senha { get; set; }
        public int nivelAcesso { get; set; }
    }
}
