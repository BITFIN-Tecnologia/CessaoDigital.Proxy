// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Relação de constantes utilizadas pela biblioteca.
    /// </summary>
    public class Constantes
    {
        /// <summary>
        /// Status de progresso da operação de antecipação.
        /// </summary>
        public class StatusDaAntecipacao
        {
            /// <summary>
            /// A operação está aguardando a formalização pelas partes.
            /// </summary>
            public const string Formalizacao = "Formalização";
            /// <summary>
            /// A operação está aguardando o pagamento.
            /// </summary>
            public const string Financeiro = "Financeiro";
            /// <summary>
            /// A operação foi concluída.
            /// </summary>
            public const string Concluida = "Concluída";
            /// <summary>
            /// A operação foi rejeitada.
            /// </summary>
            public const string Rejeitada = "Rejeitada";
        }
    }
}