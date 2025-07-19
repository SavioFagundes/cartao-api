using System.ComponentModel.DataAnnotations;

namespace CaixaEletronico.DTOs.Requests
{
    public record VerificacaoCartaoRequest
    {
        [Required(ErrorMessage = "O número do cartão é obrigatório")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "O número do cartão deve ter exatamente 16 dígitos")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "O número do cartão deve conter apenas dígitos")]
        public string NumeroCartao { get; set; } = string.Empty;

        [StringLength(4, MinimumLength = 4, ErrorMessage = "A senha deve ter exatamente 4 dígitos")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "A senha deve conter apenas dígitos")]
        public string? Senha { get; set; }
    }
}