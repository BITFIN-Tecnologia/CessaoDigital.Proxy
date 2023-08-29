// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using CessaoDigital.Proxy.Utilitarios;
using System.Text;

namespace CessaoDigital.Proxy.Comunicacao.APIs
{
    /// <summary>
    /// Gestão de recebíveis negociados pela Instituição Financeira enviados ao Portal para Sacados.
    /// </summary>
    public class Recebiveis : API
    {
        /// <summary>
        /// Inicializa a API para Recebíveis.
        /// </summary>
        /// <param name="proxy">Instância da classe <see cref="HttpClient"/> gerada pelo proxy.</param>
        public Recebiveis(HttpClient proxy)
            : base(proxy) { }

        /// <summary>
        /// Envio de Recebíveis.
        /// </summary>
        /// <param name="recebiveis">Relação de recebíveis negociados para registro.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns>Relação com o status de registro para cada um dos recebíveis enviados.</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<IEnumerable<DTOs.Processamento>> Adicionar(IEnumerable<DTOs.Recebivel> recebiveis, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Post, "recebiveis")
            {
                Content = new StringContent(Serializador.Serializar(recebiveis), Encoding.UTF8, Protocolo.MediaTypeJson)
            })
            {
                return await this.Executar(requisicao, async resposta =>
                {
                    return await resposta.Content.ReadAs<IEnumerable<DTOs.Processamento>>(cancellationToken);
                }, cancellationToken);
            }
        }

        /// <summary>
        /// Atualização de Recebíveis.
        /// </summary>
        /// <param name="recebiveis">Relação de recebíveis (já registrados) para atualização.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns>Relação com o status de atualização para cada um dos recebíveis enviados.</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<IEnumerable<DTOs.Processamento>> Atualizar(IEnumerable<DTOs.Recebivel> recebiveis, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Put, "recebiveis")
            {
                Content = new StringContent(Serializador.Serializar(recebiveis), Encoding.UTF8, Protocolo.MediaTypeJson)
            })
            {
                return await this.Executar(requisicao, async resposta =>
                {
                    return await resposta.Content.ReadAs<IEnumerable<DTOs.Processamento>>(cancellationToken);
                }, cancellationToken);
            }
        }

        /// <summary>
        /// Exclusão de Recebível.
        /// </summary>
        /// <param name="codigo">Código do Recebível.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns>Status de exclusão do recebível.</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<DTOs.Processamento> Remover(Guid codigo, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Delete, $"recebiveis/{codigo}"))
            {
                return await this.Executar(requisicao, async resposta =>
                {
                    return await resposta.Content.ReadAs<DTOs.Processamento>(cancellationToken);
                }, cancellationToken);
            }
        }

        /// <summary>
        /// Detalhes do Recebível.
        /// </summary>
        /// <param name="codigo">Código do Recebível.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns>Informações sobre a situação atual do recebível.</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<DTOs.Recebivel> Detalhes(Guid codigo, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Get, $"recebiveis/{codigo}"))
            {
                return await this.Executar(requisicao, async resposta =>
                {
                    return await resposta.Content.ReadAs<DTOs.Recebivel>(cancellationToken);
                }, cancellationToken);
            }
        }

        /// <summary>
        /// Chamados do Recebível.
        /// </summary>
        /// <param name="codigo">Código do Recebível.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns>Chamados gerados para o recebível (discussão entre sacado e Instituição).</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<IEnumerable<DTOs.Chamado>> Chamados(Guid codigo, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Get, $"recebiveis/{codigo}/chamados"))
            {
                return await this.Executar(requisicao, async resposta =>
                {
                    return await resposta.Content.ReadAs<IEnumerable<DTOs.Chamado>>(cancellationToken);
                }, cancellationToken);
            }
        }

        /// <summary>
        /// Responder Chamado.
        /// </summary>
        /// <param name="recebivel">Recebível relacionado.</param>
        /// <param name="chamado">Informações sobre o chamado que está sendo respondido.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task ResponderChamado(DTOs.Recebivel recebivel, DTOs.Chamado chamado, CancellationToken cancellationToken = default) =>
            await ResponderChamado(recebivel.Codigo, chamado, cancellationToken);

        /// <summary>
        /// Responder Chamado.
        /// </summary>
        /// <param name="codigo">Código do Recebível.</param>
        /// <param name="chamado">Informações sobre o chamado que está sendo respondido.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task ResponderChamado(Guid codigo, DTOs.Chamado chamado, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Post, $"recebiveis/{codigo}/chamados/{chamado.Tracking}")
            {
                Content = new StringContent(Serializador.Serializar(chamado), Encoding.UTF8, Protocolo.MediaTypeJson)
            })
                await Executar(requisicao, cancellationToken);
        }

        /// <summary>
        /// Conciliação de Recebíveis.
        /// </summary>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns>Relação dos recebíveis adicionados na Plataforma para fins de conciliação e sincronismo com a base de dados do contratante.</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<IEnumerable<DTOs.Recebivel>> Conciliacao(CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Get, "recebiveis/conciliacao"))
            {
                return await this.Executar(requisicao, async resposta =>
                {
                    return await resposta.Content.ReadAs<IEnumerable<DTOs.Recebivel>>(cancellationToken);
                }, cancellationToken);
            }
        }

        /// <summary>
        /// Busca de Recebíveis.
        /// </summary>
        /// <param name="parametros">Objeto contendo os parâmetros para busca e paginação.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns>Informações sobre a situação atual do recebível.</returns>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<DTOs.BuscaDeRecebiveis> Buscar(DTOs.ParametrosDeBuscaDeRecebiveis parametros, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Put, "recebiveis/busca")
            {
                Content = new StringContent(Serializador.Serializar(parametros), Encoding.UTF8, Protocolo.MediaTypeJson)
            })
            {
                return await this.Executar(requisicao, async resposta =>
                {
                    return await resposta.Content.ReadAs<DTOs.BuscaDeRecebiveis>(cancellationToken);
                }, cancellationToken);
            }
        }
    }
}