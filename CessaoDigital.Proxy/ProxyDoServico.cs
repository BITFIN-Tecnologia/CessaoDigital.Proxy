// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using CessaoDigital.Proxy.Comunicacao;
using CessaoDigital.Proxy.Comunicacao.APIs;
using CessaoDigital.Proxy.Logging;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace CessaoDigital.Proxy
{
    /// <summary>
    /// Abstrai toda a comunicação com os serviços (API's) da Plataforma Cessão Digital.
    /// </summary>
    public class ProxyDoServico : IDisposable
    {
        private readonly HttpClient proxy;

        /// <summary>
        /// Inicializa o proxy.
        /// </summary>
        /// <param name="conexao">Dados da conexão com o ambiente.</param>
        /// <param name="logger">Instância de <see cref="ILogger"/> para gestão e armazenamento de logs gerados pelo proxy.</param>
        /// <param name="rastreioDeRequisicao">Gerador de códigos de rastreio de requisições.</param>
        /// <param name="webProxy">Especifica um proxy para ser utilizado ao realizar as requisições para os serviços.</param>
        /// <exception cref="ArgumentNullException">Se a <paramref name="conexao"/> não for informada.</exception>
        public ProxyDoServico(Conexao conexao, ILogger logger = null, IRastreio rastreioDeRequisicao = null, IWebProxy webProxy = null)
        {
            this.Conexao = conexao ?? throw new ArgumentNullException(nameof(conexao));

            this.proxy = new(new RastreioDaRequisicao(logger, rastreioDeRequisicao)
            {
                Proxy = webProxy,
                UseProxy = webProxy != null
            })
            {
                BaseAddress = conexao.Url,
                DefaultRequestVersion = HttpVersion.Version20,
                DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrLower,
                Timeout = conexao.Timeout
            };

            this.proxy.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    Protocolo.ApiKey,
                    Convert.ToBase64String(Encoding.UTF8.GetBytes($"{conexao.CodigoDoContratante}:{conexao.ChaveDeIntegracao}")));

            this.Ancora = new(proxy);
            this.Financeiro = new(proxy);
            this.Instituicao = new(proxy);
        }

        /// <summary>
        /// Dados de conexão com um dos <see cref="Ambiente"/>s disponíveis.
        /// </summary>
        public Conexao Conexao { get; }

        /// <summary>
        /// Conjuto de API's para gestão pelo Sacado Âncora através do produto Antecipação à Fornecedores.
        /// </summary>
        public Ancora Ancora { get; }

        /// <summary>
        /// Informações financeiras sobre a contratação do serviço.
        /// </summary>
        public Financeiro Financeiro { get; }

        /// <summary>
        /// Conjuto de API's para gestão pela Instituição Financeira através do produto Antecipação à Fornecedores.
        /// </summary>
        public Instituicao Instituicao { get; }

        /// <summary>
        /// Encerra e remove os recursos de comunicação utilizados por esta classe.
        /// </summary>
        public void Dispose()
        {
            this.proxy?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}