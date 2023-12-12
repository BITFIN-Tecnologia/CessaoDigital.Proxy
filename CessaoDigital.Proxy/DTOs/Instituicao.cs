// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Dados da Instituição Financeira.
    /// </summary>
    [DebuggerDisplay("{Entidade,nq}")]
    public class Instituicao : Base
    {
        /// <summary>
        /// Dados cadastrais da Instituição Financeira.
        /// </summary>
        public Entidade Entidade { get; set; }

        /// <summary>
        /// FIDC, Factoring, Securitizadora ou ESC.
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Alias que identifica a Instituição.
        /// </summary>
        public string Alias { get; set; }
    }
}