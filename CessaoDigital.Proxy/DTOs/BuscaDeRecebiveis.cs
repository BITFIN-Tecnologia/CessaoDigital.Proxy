// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Resultado da busca por recebíveis que foi realizada.
    /// </summary>
    public class BuscaDeRecebiveis
    {
        /// <summary>
        /// Relação dos recebíveis localizados.
        /// </summary>
        public IEnumerable<Recebivel> Dados { get; set; }

        /// <summary>
        /// Informações sobre a paginação do resultado.
        /// </summary>
        public Paginacao Paginador { get; set; }
    }
}