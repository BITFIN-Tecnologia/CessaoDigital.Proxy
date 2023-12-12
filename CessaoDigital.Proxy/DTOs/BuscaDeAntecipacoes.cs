// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Resultado da busca por antecipações que foi realizada.
    /// </summary>
    public class BuscaDeAntecipacoes
    {
        /// <summary>
        /// Relação dos antecipações localizadas.
        /// </summary>
        public IEnumerable<Antecipacao> Dados { get; set; }

        /// <summary>
        /// Informações sobre a paginação do resultado.
        /// </summary>
        public Paginacao Paginador { get; set; }
    }
}