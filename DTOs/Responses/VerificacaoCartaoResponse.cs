namespace Cartao.DTOs.Responses
{

    public record VerificacaoCartaoResponse
    {
        public bool CartaoValido { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
        public DateTime? DataUltimoAcesso { get; set; }
        public CartaoInfoDto? CartaoInfo { get; set; }
    }
    public record CartaoInfoDto
    {
        public string NumeroCartaoMascarado { get; set; } = string.Empty;
        public DateTime DataVencimento { get; set; }
        public bool Ativo { get; set; }
        public bool Bloqueado { get; set; }
        public string TitularNome { get; set; } = string.Empty;
        public string ContaNumero { get; set; } = string.Empty;
        public string Agencia { get; set; } = string.Empty;
    }
}