// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Status do recebível para conciliação.
    /// </summary>
    [DebuggerDisplay("{UsoDaEmpresa,nq}")]
    public class Conciliacao
    {
        /// <summary>
        /// Código que identifica unicamente o recebível dentro da Plataforma.
        /// </summary>
        public Guid Codigo { get; set; }

        /// <summary>
        /// Campo livre que identifica unicamente o recebível para o contratante.
        /// </summary>
        public string UsoDaEmpresa { get; set; }

        /// <summary>
        /// Situação do recebível (Em Aberto, Liquidado, Liquidado em Cartório, Baixado, Recomprado pelo Cedente ou Recomprado pelo Sacado).
        /// </summary>
        public string Situacao { get; set; }

        /// <summary>
        /// Registrado ou Baixado.
        /// </summary>
        public string StatusDeCobranca { get; set; }
    }
}