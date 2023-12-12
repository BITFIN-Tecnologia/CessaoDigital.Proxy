// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Informações de endereço.
    /// </summary>
    [DebuggerDisplay("{Cep,nq} - {Localidade,nq}/{Estado,nq}")]
    public class Endereco : Base
    {
        /// <summary>
        /// CEP do Logradouro ou Cidade.
        /// </summary>
        public string Cep { get; set; }

        /// <summary>
        /// Logradouro (Rua, Avenida, etc.).
        /// </summary>
        public string Logradouro { get; set; }

        /// <summary>
        /// Número do prédio ou da casa.
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Complemento (Andar, Edifício, etc.).
        /// </summary>
        public string Complemento { get; set; }

        /// <summary>
        /// Bairro.
        /// </summary>
        public string Bairro { get; set; }

        /// <summary>
        /// Localidade (Cidade).
        /// </summary>
        public string Localidade { get; set; }

        /// <summary>
        /// "Estado (UF).
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// País (Brasil).
        /// </summary>
        public string Pais { get; set; }
    }
}