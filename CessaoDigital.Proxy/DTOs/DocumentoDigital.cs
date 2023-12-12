// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Representa um Documento que foi assinado digitalmente.
    /// </summary>
    [DebuggerDisplay("{Tipo,nq}")]
    public class DocumentoDigital : Base
    {
        /// <summary>
        /// Data de geração do Documento.
        /// </summary>
        public DateTime DataDeCadastro { get; set; }

        /// <summary>
        /// Tipo do Documento (Exemplo: Termo de Adesão, Termo de Cessão, etc.).
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Link de acesso à Certificadora.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Status de assinatura do Documento.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Data do Status.
        /// </summary>
        public DateTime DataDoStatus { get; set; }
    }
}