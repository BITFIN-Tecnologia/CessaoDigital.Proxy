// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Reporte do andamento da operação na Instituição Financeira.
    /// </summary>
    [DebuggerDisplay("{Status,nq}")]
    public class StatusDaAntecipacao
    {
        /// <summary>
        /// Status da Operação: Formalização, Financeiro, Concluída ou Rejeitada.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Termo de Cessão, em formato P7S, codificado em Base64. Será exigido quando o status for "Financeiro".
        /// </summary>
        public string TermoDeCessao { get; set; }

        /// <summary>
        /// Comprovante de Pagamento, em formato PDF, codificado em Base64. Será exigido quando o status for "Concluída".
        /// </summary>
        public string ComprovanteDePagamento { get; set; }

        /// <summary>
        /// Link para a certificadora digital encarregada de coletar as assinaturas no Termo de Cessão.
        /// </summary>
        public string LinkParaAssinatura { get; set; }

        /// <summary>
        /// Data/hora em que o crédito foi realizado. Será exigido quando o status for "Concluída".
        /// </summary>
        public DateTime? DataDeCredito { get; set; }

        /// <summary>
        /// Motivo pelo qual a Instituição está rejeitando a operação. Será exigido quando o status for "Rejeitada".
        /// </summary>
        public string MotivoDeRejeicao { get; set; }
    }
}