// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Status de formalização do Fornecedor.
    /// </summary>
    [DebuggerDisplay("Habilitado: {Habilitado}")]
    public class StatusDoFornecedor
    {
        /// <summary>
        /// Código que identifica o Fornecedor unificamente na Plataforma.
        /// </summary>
        public Guid Codigo { get; set; }

        /// <summary>
        /// Indica se o fornecedor está ou não habilitado.
        /// </summary>
        public bool Habilitado { get; set; }

        /// <summary>
        /// Mensagem customizada para justificar o status.
        /// </summary>
        public string Mensagem { get; set; }

        /// <summary>
        /// Permite customizar um limite de operações para o fornecedor.
        /// </summary>
        public decimal? Limite { get; set; }
    }
}