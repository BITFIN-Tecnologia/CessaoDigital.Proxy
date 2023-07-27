// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using CessaoDigital.Proxy.Utilitarios;
using System.Text;

namespace CessaoDigital.Proxy.Comunicacao.APIs
{
    /// <summary>
    /// Conjuto de API's para gestão pelo Sacado Âncora através do produto Antecipação à Fornecedores.
    /// </summary>
    public class Ancora : API
    {
        /// <summary>
        /// Inicializa a API para Sacados Âncora.
        /// </summary>
        /// <param name="proxy">Instância da classe <see cref="HttpClient"/> gerada pelo proxy.</param>
        public Ancora(HttpClient proxy)
            : base(proxy) { }

        /// <summary>
        /// Termos de Adesão.
        /// </summary>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns>Relação de Entidades (Fornecedores) cadastradas que aderiram à Plataforma para Antecipação.</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<IEnumerable<DTOs.TermoDeAdesao>> Adesoes(CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Get, "ancora/adesoes"))
                return await Executar(
                    requisicao,
                    async resposta => await resposta.Content.ReadAs<IEnumerable<DTOs.TermoDeAdesao>>(cancellationToken),
                    cancellationToken);
        }

        /// <summary>
        /// Linhas de Crédito.
        /// </summary>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns>Relação das linhas de crédito utilizadas pela Plataforma para realizar as antecipações.</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<IEnumerable<DTOs.LinhaDeCredito>> Credito(CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Get, "ancora/credito"))
                return await Executar(
                    requisicao,
                    async resposta => await resposta.Content.ReadAs<IEnumerable<DTOs.LinhaDeCredito>>(cancellationToken),
                    cancellationToken);
        }

        /// <summary>
        /// Busca de Operações.
        /// </summary>
        /// <param name="parametros">Objeto contendo os parâmetros para busca e paginação.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns>Relação de operações que atendem os critérios de busca, incluindo informações para paginação dos resultados.</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<DTOs.BuscaDeAntecipacoes> Antecipacoes(DTOs.ParametrosDeBusca parametros, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Post, "ancora/antecipacoes")
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
        /// <returns>Retorna todas as informações sobre uma determinada Operação.</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<DTOs.Antecipacao> Antecipacao(string codigo, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Get, $"ancora/antecipacoes/{codigo}"))
            {
                return await this.Executar(requisicao, async resposta =>
                {
                    return await resposta.Content.ReadAs<DTOs.Antecipacao>(cancellationToken);
                }, cancellationToken);
            }
        }

        /// <summary>
        /// Envio de uma única nota fiscal mercantil.
        /// </summary>
        /// <param name="xml">XML representando a nota fiscal mercantil.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns><see cref="Guid"/> representando a solicitação que foi enfileirada para processamento.</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<Guid> EnvioDeNFe(string xml, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Post, "ancora/nfe")
            {
                Content = new StringContent(xml, Encoding.UTF8, Protocolo.MediaTypeXml)
            })
            {
                return await this.Executar(requisicao, async resposta =>
                {
                    var info = Serializador.Deserializar<Dictionary<string, string>>(await resposta.Content.ReadAsStringAsync(cancellationToken));

                    return Guid.Parse(info["id"]);
                }, cancellationToken);
            }
        }

        /// <summary>
        /// Envio de múltiplas notas fiscais mercantis.
        /// </summary>
        /// <param name="zip">Arquivo compactado com as respectivas notas fiscais em formato XML.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns><see cref="Guid"/> representando a solicitação que foi enfileirada para processamento.</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<Guid> EnvioDeNFe(byte[] zip, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Post, "ancora/nfe")
            {
                Content = new ByteArrayContent(zip)
            })
            {
                requisicao.Content.Headers.ContentType = Protocolo.MediaTypeZip;

                return await this.Executar(requisicao, async resposta =>
                {
                    var info = Serializador.Deserializar<Dictionary<string, string>>(await resposta.Content.ReadAsStringAsync(cancellationToken));

                    return Guid.Parse(info["id"]);
                }, cancellationToken);
            }
        }

        /// <summary>
        /// Autorização de NF-e.
        /// </summary>
        /// <param name="autorizacoes">Relação de Notas Fiscais</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns>Relação das notas fiscais informadas e seu respectivo status de autorização para antecipação.</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<IEnumerable<DTOs.AutorizacaoDeNFe>> Antecipacoes(IEnumerable<DTOs.AutorizacaoDeNFe> autorizacoes, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Post, "ancora/nfe/autorizacao")
            {
                Content = new StringContent(Serializador.Serializar(autorizacoes), Encoding.UTF8, Protocolo.MediaTypeJson)
            })
            {
                return await this.Executar(requisicao, async resposta =>
                {
                    return await resposta.Content.ReadAs<IEnumerable<DTOs.AutorizacaoDeNFe>>(cancellationToken);
                }, cancellationToken);
            }
        }
    }
}