// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Parâmetros gerais para busca de informações.
    /// </summary>
    public class ParametrosDeBuscaDeAntecipacoes
    {
        /// <summary>
        /// Documento (CNPJ/CPF) do fornecedor.
        /// </summary>
        public string DocumentoDoFornecedor { get; set; }

        /// <summary>
        /// Data inicial do período.
        /// </summary>
        public DateTime? DataInicial { get; set; }

        /// <summary>
        /// Data final do período.
        /// </summary>
        public DateTime? DataFinal { get; set; }

        /// <summary>
        /// Cadastro ou Status.
        /// </summary>
        public string BaseDaData { get; set; }

        /// <summary>
        /// Informações sobre a paginação da consulta.
        /// </summary>
        public Paginacao Paginador { get; set; }
    }
}