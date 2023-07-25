// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Entidade que representa uma Pessoa Física ou Jurídica.
    /// </summary>
    [DebuggerDisplay("{Documento,nq} - {Nome,nq}")]
    public class Entidade : Base
    {
        /// <summary>
        /// Nome/Razão Social da entidade.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Documento (CNPJ/CPF) da entidade.
        /// </summary>
        public string Documento { get; set; }

        /// <summary>
        /// PJ (Pessoa Jurídica) ou PF (Pessoa Física).
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Endereço da empresa ou de residência.
        /// </summary>
        public Endereco Endereco { get; set; }

        /// <summary>
        /// Endereço de e-mail para eventual comunicação/notificação.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Telefone para contato da entidade.
        /// </summary>
        public string Telefone { get; set; }
    }
}