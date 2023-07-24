// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (APIs) da Plataforma Cessão Digital.

namespace CessaoDigital.Proxy.Comunicacao
{
    /// <summary>
    /// Exceção customizada que traduz a <see cref="DTOs.Falha"/> em uma exceção.
    /// </summary>
    public class ErroNaRequisicao : HttpRequestException
    {
        /// <summary>
        /// Inicializa a exceção
        /// </summary>
        /// <param name="excecao">Exceção disparada pela plataforma.</param>
        /// <param name="falha">Dados customizados da falha que foram informados pelo serviço.</param>
        public ErroNaRequisicao(HttpRequestException excecao, DTOs.Falha falha)
            : base(falha?.Mensagem ?? excecao.Message, excecao, excecao.StatusCode)
        {
            this.HelpLink = falha?.Link;

            if (!string.IsNullOrWhiteSpace(falha?.Descricao))
                this.Data.Add("Descricao", falha.Descricao);
        }
    }
}