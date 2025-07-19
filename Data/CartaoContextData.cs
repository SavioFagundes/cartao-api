

using Cartao.Models;
using Microsoft.EntityFrameworkCore;

namespace Cartao.Data
{
    public class CartaoContextData : DbContext
    {
        public CartaoContextData(DbContextOptions<CartaoContextData> options) : base(options)
        {
        }

        public DbSet<CartaoAtm> CartoesAtm { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartaoAtm>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.NumeroCartao).IsRequired().HasMaxLength(16);
                entity.Property(e => e.Senha).IsRequired().HasMaxLength(4);
                entity.HasOne(e => e.Conta)
                      .WithMany(c => c.Cartoes)
                      .HasForeignKey(e => e.ContaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            // Configurações da Conta
            modelBuilder.Entity<Conta>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.NumeroConta).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Agencia).IsRequired().HasMaxLength(4);
                entity.Property(e => e.TitularNome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.TitularCpf).IsRequired().HasMaxLength(11);
                entity.Property(e => e.Saldo).HasPrecision(18, 2);
                entity.HasIndex(e => e.NumeroConta).IsUnique();
                entity.HasIndex(e => e.TitularCpf).IsUnique();
            });

            // Configurações da Transacao
            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Valor).HasPrecision(18, 2);
                entity.Property(e => e.SaldoAnterior).HasPrecision(18, 2);
                entity.Property(e => e.SaldoPosterior).HasPrecision(18, 2);
                entity.Property(e => e.Descricao).HasMaxLength(200);
                entity.HasOne(e => e.Conta)
                      .WithMany(c => c.Transacoes)
                      .HasForeignKey(e => e.ContaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Seed Data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>().HasData(
                new Conta { Id = 1, NumeroConta = "1234567890", Agencia = "0001", TitularNome = "João Silva", TitularCpf = "12345678901", Saldo = 1000.00m },
                new Conta { Id = 2, NumeroConta = "0987654321", Agencia = "0002", TitularNome = "Maria Oliveira", TitularCpf = "10987654321", Saldo = 2000.00m }
            );

            modelBuilder.Entity<CartaoAtm>().HasData(
                new CartaoAtm { Id = 1, NumeroCartao = "1234567812345678", Senha = "1234", ContaId = 1 },
                new CartaoAtm { Id = 2, NumeroCartao = "8765432187654321", Senha = "4321", ContaId = 2 }
            );
        }
    }
}