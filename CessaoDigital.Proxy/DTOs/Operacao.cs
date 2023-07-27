// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Dados da operação de antecipação de recebível.
    /// </summary>
    [DebuggerDisplay("{Instituicao,nq} - {Data} - Código: {Codigo,nq}")]
    public class Operacao : Base
    {
        /// <summary>
        /// Instituição que adquiriu o recebível.
        /// </summary>
        public Instituicao Instituicao { get; set; }

        /// <summary>
        /// Código que identifica unicamente a operação dentro da Instituição.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Data em que a operação foi efetivada.
        /// </summary>
        public DateTime Data { get; set; }
    }
}