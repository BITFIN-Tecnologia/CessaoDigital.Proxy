// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Classe utilizada para recepcionar os callbacks gerados pela plataforma.
    /// </summary>
    [DebuggerDisplay("{Evento,nq}")]
    public class Callback
    {
        /// <summary>
        /// Descrição do evento ocorrido.
        /// </summary>
        public string Evento { get; set; }

        /// <summary>
        /// Alguma informação complementar relevante para este evento.
        /// </summary>
        /// <remarks>Dependendo da complexidade do callback, esta propriedade pode retornar um objeto serializado para complementar a informação.</remarks>
        public object Complemento { get; set; }

        /// <summary>
        /// Se a entidade que gerou o callback possuir tags associadas, elas serão informadas nesta propriedade.
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Data em que o callback ocorreu.
        /// </summary>
        public DateTime Data { get; set; }
    }
}