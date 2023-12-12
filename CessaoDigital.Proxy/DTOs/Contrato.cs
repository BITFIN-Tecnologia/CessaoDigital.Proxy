// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Informações referente à um determinado Contrato gerado pela Plataforma.
    /// </summary>
    [DebuggerDisplay("{Tipo,nq} #{Codigo,nq}")]
    public class Contrato : Base
    {
        /// <summary>
        /// Tipo do Contrato (Exemplo: Plataforma para Sacados, Antecipação à Fornecedores, etc.).
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Código que identifica unicamente o Contrato na Plataforma.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Data de geração do Contrato.
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Informações sobre a assinatura digital do Contrato.
        /// </summary>
        public DocumentoDigital Formalizacao { get; set; }
    }
}