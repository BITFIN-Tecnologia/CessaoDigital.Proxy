// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

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
    }
}