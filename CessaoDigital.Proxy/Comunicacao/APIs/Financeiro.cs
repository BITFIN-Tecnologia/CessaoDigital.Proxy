// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using CessaoDigital.Proxy.Utilitarios;

namespace CessaoDigital.Proxy.Comunicacao.APIs
{
    /// <summary>
    /// Informações financeiras sobre a contratação do serviço.
    /// </summary>
    public class Financeiro : API
    {
        /// <summary>
        /// Inicializa a API de informações financeiras.
        /// </summary>
        /// <param name="proxy">Instância da classe <see cref="HttpClient"/> gerada pelo proxy.</param>
        public Financeiro(HttpClient proxy)
            : base(proxy) { }

        /// <summary>
        /// Relação de Fechamentos.
        /// </summary>
        /// <param name="cancellationToken">Instrução para eventual cancelamento da requisição.</param>
        /// <returns>Relação de Fechamentos realizados.</returns>
        /// <remarks>Fechamentos financeiros que resumem o consumo mensal do contratante.</remarks>
        /// <exception cref="ErroNaRequisicao">Exceção disparada se alguma falha ocorrer durante a requisição ou em seu processamento.</exception>
        public async Task<IEnumerable<DTOs.Fechamento>> Fechamentos(CancellationToken cancellationToken = default)
        {
            using (var requisicao = new HttpRequestMessage(HttpMethod.Get, "financeiro/fechamentos"))
                return await Executar(
                    requisicao,
                    async resposta => await resposta.Content.ReadAs<IEnumerable<DTOs.Fechamento>>(cancellationToken),
                    cancellationToken);
        }
    }
}