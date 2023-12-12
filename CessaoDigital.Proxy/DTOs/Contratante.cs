// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Contratante da Plataforma.
    /// </summary>
    [DebuggerDisplay("{Entidade,nq}")]
    public class Contratante : Base
    {
        /// <summary>
        /// Informações sobre a entidade contratante.
        /// </summary>
        public Entidade Entidade { get; set; }
    }
}