// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Discussão entre sacado e Instituição.
    /// </summary>
    [DebuggerDisplay("{Titulo,nq}")]
    public class Chamado : Base
    {
        /// <summary>
        /// Entidade geradora do chamado (sacado ou Instituição).
        /// </summary>
        public Entidade Remetente { get; set; }

        /// <summary>
        /// Entidade destinatária do chamado (sacado ou Instituição).
        /// </summary>
        public Entidade Destinatario { get; set; }

        /// <summary>
        /// Recebível associado à discussão.
        /// </summary>
        public Recebivel Recebivel { get; set; }

        /// <summary>
        /// Assunto ao qual se refere o chamado.
        /// </summary>
        public string Assunto { get; set; }

        /// <summary>
        /// Mensagem de questionamento ou resposta.
        /// </summary>
        public string Mensagem { get; set; }

        /// <summary>
        /// Data de abertura do chamado.
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Identificador único do chamado.
        /// </summary>
        public Guid Tracking { get; set; }
    }
}