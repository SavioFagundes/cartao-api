using System.ComponentModel.DataAnnotations;
namespace Cartao.Models
{
    public class Conta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string NumeroConta { get; set; } = string.Empty;
        [Required]
        [StringLength(4)]
        public string Agencia { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string TitularNome { get; set; } = string.Empty;
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string TitularCpf { get; set; } = string.Empty;
        [Required]
        public decimal Saldo { get; set; } = 0;
        [Required]
        public bool Ativo { get; set; } = true;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public virtual ICollection<CartaoAtm> Cartoes { get; set; } = new List<CartaoAtm>();
        public virtual ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}