using System.ComponentModel.DataAnnotations;

namespace CGenius.Models
{
    public class ScriptVendas
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long IdCompra { get; set; }

        [Required]
        public long IdProduto { get; set; }

        [Required]
        public long IdChamada { get; set; }

        [Required]
        public string CpfCliente { get; set; }  

        [Required]
        public string DescricaoScript { get; set; }
    }
}
