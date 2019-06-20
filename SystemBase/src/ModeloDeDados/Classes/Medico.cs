using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModeloDeDados.Classes
{
    public  class Medico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Crm { get; set; }

        [StringLength(100)]
        public string Especialidade { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }
    }
}
