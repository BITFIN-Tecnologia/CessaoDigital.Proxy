// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using CessaoDigital.Proxy.Utilitarios;
using System.Text;

namespace CessaoDigital.Proxy.Comunicacao.APIs
{
    /// <summary>
    /// Conjuto de API's para gestão pela Instituição Financeira através do produto Antecipação à Fornecedores.
    /// </summary>
    public class Instituicao : API
    {
        /// <summary>
        /// Inicializa a API para Instituições Financeiras.
        /// </summary>
        /// <param name="proxy">Instância da classe <see cref="HttpClient"/> gerada pelo proxy.</param>
        public Instituicao(HttpClient proxy)
            : base(proxy) { }

        /// <summary>
        /// Contratação da Plataforma.
        /// </summary>
        /// <param name="contratacao">Informações sobre a contratação.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task Contratacao(DTOs.Contratacao contratacao, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Post, "instituicao/contratacao")
            {
                Content = new StringContent(Serializador.Serializar(contratacao), Encoding.UTF8, Protocolo.MediaTypeJson)
            })
                await Executar(requisicao, cancellationToken);
        }

        /// <summary>
        /// Concessão de Crédito.
        /// </summary>
        /// <param name="credito">Informações sobre a linha de crédito.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <remarks>Concede ou atualiza a linha de crédito para o Sacado.</remarks>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task Credito(DTOs.LinhaDeCredito credito, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Post, "instituicao/credito")
            {
                Content = new StringContent(Serializador.Serializar(credito), Encoding.UTF8, Protocolo.MediaTypeJson)
            })
                await Executar(requisicao, cancellationToken);
        }

        /// <summary>
        /// Relação de Fornecedores.
        /// </summary>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns>Retorna as Entidades com suas informações cadastrais.</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<IEnumerable<DTOs.Fornecedor>> Fornecedores(CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Get, "instituicao/fornecedores"))
                return await Executar(
                    requisicao,
                    async resposta => await resposta.Content.ReadAs<IEnumerable<DTOs.Fornecedor>>(cancellationToken),
                    cancellationToken);
        }

        /// <summary>
        /// Detalhes do Fornecedor.
        /// </summary>
        /// <param name="codigo">Código do Fornecedor.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns>Retorna os dados cadastrais, incluindo as contas bancárias utilizadas para crédito.</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<DTOs.Fornecedor> Fornecedor(Guid codigo, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Get, $"instituicao/fornecedores/{codigo}"))
            {
                return await this.Executar(requisicao, async resposta =>
                {
                    return await resposta.Content.ReadAs<DTOs.Fornecedor>(cancellationToken);
                }, cancellationToken);
            }
        }

        /// <summary>
        /// Status do Fornecedor
        /// </summary>
        /// <remarks>Permite à Instituição alternar o status do Fornecedor.</remarks>
        /// <param name="status">Status do Fornecedor.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task StatusDoFornecedor(DTOs.StatusDoFornecedor status, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Patch, $"instituicao/fornecedores/{status.Codigo}/status")
            {
                Content = new StringContent(Serializador.Serializar(status), Encoding.UTF8, Protocolo.MediaTypeJson)
            })
                await Executar(requisicao, cancellationToken);
        }

        /// <summary>
        /// Busca de Operações.
        /// </summary>
        /// <param name="parametros">Objeto contendo os parâmetros para busca e paginação.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns>Relação de operações que atendem os critérios de busca, incluindo informações para paginação dos resultados.</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<DTOs.BuscaDeAntecipacoes> Antecipacoes(DTOs.ParametrosDeBuscaDeAntecipacoes parametros, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Post, "instituicao/antecipacoes")
            {
                Content = new StringContent(Serializador.Serializar(parametros), Encoding.UTF8, Protocolo.MediaTypeJson)
            })
            {
                return await this.Executar(requisicao, async resposta =>
                {
                    return await resposta.Content.ReadAs<DTOs.BuscaDeAntecipacoes>(cancellationToken);
                }, cancellationToken);
            }
        }

        /// <summary>
        /// Detalhes da Operação.
        /// </summary>
        /// <param name="codigo">Código da Antecipação.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns>Retorna os dados completos da Operação, incluindo as notas fiscais negociadas.</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<DTOs.Antecipacao> Antecipacao(string codigo, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Get, $"instituicao/antecipacoes/{codigo}"))
            {
                return await this.Executar(requisicao, async resposta =>
                {
                    return await resposta.Content.ReadAs<DTOs.Antecipacao>(cancellationToken);
                }, cancellationToken);
            }
        }

        /// <summary>
        /// Status da Operação.
        /// </summary>
        /// <param name="codigo">Código da Antecipação.</param>
        /// <param name="status">Informações sobre o andamento da operação.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <remarks>Permite à Instituição notificar a evolução da Operação.</remarks>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task StatusDaAntecipacao(string codigo, DTOs.StatusDaAntecipacao status, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Patch, $"instituicao/antecipacoes/{codigo}/status")
            {
                Content = new StringContent(Serializador.Serializar(status), Encoding.UTF8, Protocolo.MediaTypeJson)
            })
                await Executar(requisicao, cancellationToken);
        }
    }
}