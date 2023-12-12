// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Informações sobre a adesão à Plataforma para Antecipação à Fornecedores.
    /// </summary>
    public class TermoDeAdesao
    {
        /// <summary>
        /// Fornecedor (pessoa física ou jurídica) aderente da Plataforma.
        /// </summary>
        public Entidade Fornecedor { get; set; }

        /// <summary>
        /// Dados do termo que foi assinado.
        /// </summary>
        public Contrato Contrato { get; set; }
    }
}