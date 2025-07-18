using System.ComponentModel.DataAnnotations;

namespace Cartao.Models
{
    public class CartaoAtm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 16)]
        public string NumeroCartao { get; set; } = string.Empty;
        [Required]
        [StringLength(4, MinimumLength = 4)]
        public int Senha { get; set; }
        [Required]
        public DateTime DataVencimento { get; set; }
        [Required]
        public bool Ativo { get; set; }
        [Required]
        public int ContaId { get; set; }

        // Navigation property

        public virtual Conta? Conta { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public DateTime DataUltimoAcesso { get; set; }

        public int TentativasLogin { get; set; }

        public bool Bloqueado { get; set; } = false;

        public DateTime? DataBloqueio { get; set; }
    }
}