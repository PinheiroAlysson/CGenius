using System.ComponentModel.DataAnnotations;

namespace CGenius.Models
{
    public class Atendente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeAtendente { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Setor { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
