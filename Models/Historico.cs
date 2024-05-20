using System.ComponentModel.DataAnnotations;

namespace CGenius.Models
{
    public class Historico
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long IdProduto { get; set; }

        [Required]
        public string CpfCliente { get; set; }

        [Required]
        public DateTime DataCompra { get; set; }
    }
}
