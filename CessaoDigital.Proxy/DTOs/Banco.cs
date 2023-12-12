// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Dados do Banco.
    /// </summary>
    [DebuggerDisplay("{Codigo,nq} - {Nome,nq}")]
    public class Banco : Base
    {
        /// <summary>
        /// Código que identifica o Banco no SPB.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// "Nome comercial do Banco.
        /// </summary>
        public string Nome { get; set; }
    }
}