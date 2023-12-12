// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Parâmetros gerais para busca de informações.
    /// </summary>
    public class ParametrosDeBuscaDeRecebiveis
    {
        /// <summary>
        /// Documento (CNPJ/CPF) da Instituição.
        /// </summary>
        public string DocumentoDaInstituicao { get; set; }

        /// <summary>
        /// Documento (CNPJ/CPF) do cedente.
        /// </summary>
        public string DocumentoDoCedente { get; set; }

        /// <summary>
        /// Documento (CNPJ/CPF) do sacado.
        /// </summary>
        public string DocumentoDoSacado { get; set; }

        /// <summary>
        /// Data inicial do período.
        /// </summary>
        public DateTime DataInicial { get; set; }

        /// <summary>
        /// Data final do período.
        /// </summary>
        public DateTime DataFinal { get; set; }

        /// <summary>
        /// Emissao, Operacao, Cadastro, Vencimento ou Situacao.
        /// </summary>
        public string BaseDaData { get; set; }

        /// <summary>
        /// Em Aberto, Liquidado, Liquidado em Cartório, Baixado, Recomprado pelo Cedente ou Recomprado pelo Sacado.
        /// </summary>
        public string Situacao { get; set; }

        /// <summary>
        /// Código que identifica unicamente a operação dentro da Instituição.
        /// </summary>
        public string CodigoDaOperacao { get; set; }

        /// <summary>
        /// Número do recebível. Em geral, refere-se ou número da duplicata ou do boleto.
        /// </summary>
        public string NumeroDoRecebivel { get; set; }

        /// <summary>
        /// Campo livre que identifica unicamente o recebível para o contratante.
        /// </summary>
        public string UsoDaEmpresa { get; set; }

        /// <summary>
        /// Tags de livre utilização pelo contratante.
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Informações sobre a paginação da consulta.
        /// </summary>
        public Paginacao Paginador { get; set; }
    }
}