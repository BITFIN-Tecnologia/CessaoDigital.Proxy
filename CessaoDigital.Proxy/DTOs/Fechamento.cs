// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Fechamento financeiro.
    /// </summary>
    [DebuggerDisplay("{Mes}/{Ano} - {Valor} - {Contratante,nq}")]
    public class Fechamento : Base
    {
        /// <summary>
        /// Entidade contratante.
        /// </summary>
        public Contratante Contratante { get; set; }

        /// <summary>
        /// Data de apuração.
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Ano do período de apuração.
        /// </summary>
        public int Ano { get; set; }

        /// <summary>
        /// Mês do período de apuração.
        /// </summary>
        public int Mes { get; set; }

        /// <summary>
        /// Quantidade de recebíveis registrados no período.
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Valor unitário por registro da faixa atingida.
        /// </summary>
        public decimal ValorUnitario { get; set; }

        /// <summary>
        /// Valor total apurado.
        /// </summary>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Data para pagamento da fatura.
        /// </summary>
        public DateTime DataDeVencimento { get; set; }

        /// <summary>
        /// Status de pagamento.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Data do status de pagamento.
        /// </summary>
        public DateTime DataDoStatus { get; set; }
    }
}