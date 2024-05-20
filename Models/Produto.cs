using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace CGenius.Models
{
    public class Produto
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string NomeProduto { get; set; }

        [Required]
        public string DescricaoProduto { get; set; }

        [Required]
        public decimal ValorProduto { get; set; }

        [Required]
        public virtual ICollection<Historico> Historicos { get; set; }
    }
}
