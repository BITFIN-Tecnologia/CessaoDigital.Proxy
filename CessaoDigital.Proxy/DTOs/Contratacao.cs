// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Representação da contratação entre Instituição, Sacado e Plataforma.
    /// </summary>
    [DebuggerDisplay("{Instituicao,nq}/{Sacado,nq}")]
    public class Contratacao
    {
        /// <summary>
        /// Dados da Instituição Financeira.
        /// </summary>
        public Instituicao Instituicao { get; set; }

        /// <summary>
        /// Dados do Sacado Âncora.
        /// </summary>
        public Entidade Sacado { get; set; }

        /// <summary>
        /// Informações sobre a linha de crédito concedida.
        /// </summary>
        public LinhaDeCredito LinhaDeCredito { get; set; }

        /// <summary>
        /// Representantes da Instituição Financeira para formalização do contrato com a Plataforma.
        /// </summary>
        public IEnumerable<Entidade> RepresentantesDaInstituicao { get; set; }

        /// <summary>
        /// Representantes do Sacado Âncora para formalização do contrato com a Plataforma.
        /// </summary>
        public IEnumerable<Entidade> RepresentantesDoContratante { get; set; }
    }
}