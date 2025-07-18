namespace Cartao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Cartao.Models.enums;

    public class Transacao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ContaId { get; set; }
        [Required]
        public TipoTransacao Tipo { get; set; }

        [Required]
        public double Valor { get; set; }

        public double SaldoAnterior { get; set; }
        public double SaldoPosterior { get; set; }

        [StringLength(200)]
        public string? Descricao { get; set; }

        public virtual Conta? Conta { get; set; }

        
    }
}