// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Dados do fornecedor.
    /// </summary>
    [DebuggerDisplay("{Entidade,nq}")]
    public class Fornecedor : Base
    {
        /// <summary>
        /// Código que identifica unificamente na Plataforma.
        /// </summary>
        public Guid Codigo { get; set; }

        /// <summary>
        /// Data em que foi habilitado.
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Entidade (pessoa física ou jurídica).
        /// </summary>
        public Entidade Entidade { get; set; }

        /// <summary>
        /// Limite máximo para antecipação definido para o fornecedor.
        /// </summary>
        public decimal? Limite { get; set; }

        /// <summary>
        /// Indica se o fornecedor está ou não habilitado.
        /// </summary>
        public bool? Habilitado { get; set; }
    }
}