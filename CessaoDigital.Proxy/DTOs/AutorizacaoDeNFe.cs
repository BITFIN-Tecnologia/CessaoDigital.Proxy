// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Autorização para antecipação da NF-e.
    /// </summary>
    [DebuggerDisplay("{Danfe,nq}: {Status}")]
    public class AutorizacaoDeNFe
    {
        /// <summary>
        /// Número do DANFE.
        /// </summary>
        public string Danfe { get; set; }

        /// <summary>
        /// Status de autorização para antecipação: Autorizada, Já Autorizada ou Não Localizada.
        /// </summary>
        public string Status { get; set; }
    }
}