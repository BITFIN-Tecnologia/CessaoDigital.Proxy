// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
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
        /// /// <param name="proxy">Instância da classe <see cref="HttpClient"/> gerada pelo proxy.</param>
        public Instituicao(HttpClient proxy)
            : base(proxy) { }

        /// <summary>
        /// Permite à Instituição alternar o status do Fornecedor.
        /// </summary>
        /// <param name="status">Status do Fornecedor.</param>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        public async Task AtualizarFornecedor(DTOs.StatusDoFornecedor status, CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Patch, $"instituicao/fornecedores/{status.Codigo}/status")
            {
                Content = new StringContent(Serializador.Serializar(status), Encoding.UTF8, this.MimeType.MediaType)
            })
                await Executar(requisicao, cancellationToken);
        }
    }
}