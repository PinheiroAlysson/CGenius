using System.ComponentModel.DataAnnotations;

namespace CGenius.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeCliente {  get; set; }

        [Required]
        public string CpfCliente { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Email { get; set; }

        public string PreferenciaContato { get; set; }

        [Required]
        public DateTime DtNascimento { get; set; }
    }
}
