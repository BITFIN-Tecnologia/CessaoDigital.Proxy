// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Dados da Conta bancária em Instituição Financeira.
    /// </summary>
    [DebuggerDisplay("{Banco,nq}/{Agencia,nq}/{Numero,nq}-{Digito,nq}")]
    public class ContaBancaria : Base
    {
        /// <summary>
        /// Dados da Entidade titular da conta.
        /// </summary>
        public Entidade Titular { get; set; }

        /// <summary>
        /// Instituição Financeira.
        /// </summary>
        public Banco Banco { get; set; }

        /// <summary>
        /// Código da Agência.
        /// </summary>
        public string Agencia { get; set; }

        /// <summary>
        /// Número da Conta.
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Dígito da Conta.
        /// </summary>
        public string Digito { get; set; }

        /// <summary>
        /// Chave PIX associada à Conta.
        /// </summary>
        public string ChavePix { get; set; }

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