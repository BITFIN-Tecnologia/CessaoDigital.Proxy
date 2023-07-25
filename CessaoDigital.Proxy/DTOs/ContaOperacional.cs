// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Dados da Conta bancária em Instituição (FIDC, Factoring ou Securitizadora).
    /// </summary>
    [DebuggerDisplay("{Instituicao,nq}/{Numero,nq}")]
    public class ContaOperacional : Base
    {
        /// <summary>
        /// Dados da Entidade titular da conta.
        /// </summary>
        public Entidade Titular { get; set; }

        /// <summary>
        /// Instituição (FIDC, Factoring ou Securitizadora).
        /// </summary>
        public Instituicao Instituicao { get; set; }

        /// <summary>
        /// Número da Conta.
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Data de cadastro na Plataforma.
        /// </summary>
        public DateTime DataDeCadastro { get; set; }

        /// <summary>
        /// Indica se a Conta está disponível para utilização.
        /// </summary>
        public bool Ativa { get; set; }
    }
}