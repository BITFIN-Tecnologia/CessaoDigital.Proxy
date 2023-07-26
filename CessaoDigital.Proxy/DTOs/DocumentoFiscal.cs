// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Documento fiscal que dá lastro ao recebível.
    /// </summary>
    [DebuggerDisplay("{Tipo,nq} - {CodigoDeVerificacao,nq}")]
    public class DocumentoFiscal : Base
    {
        /// <summary>
        /// Tipo de Documento (CTe, NFe e NFS).
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Código de verificação gerado pela Prefeitura ou pela Secretaria da Fazenda.
        /// </summary>
        public string CodigoDeVerificacao { get; set; }

        /// <summary>
        /// Data em que foi cadastrado o documento fiscal na Plataforma.
        /// </summary>
        public DateTime? DataDeCadastro { get; set; }

        /// <summary>
        /// Status de autorização (Interminado, Autorizado ou Cancelado).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Data do status.
        /// </summary>
        public DateTime? DataDoStatus { get; set; }

        /// <summary>
        /// Relação de eventos associados ao documento fiscal retornados pela SEFAZ.
        /// </summary>
        public List<Evento> Eventos { get; set; }

        /// <summary>
        /// Dados do evento gerado sobre o documento fiscal.
        /// </summary>
        [DebuggerDisplay("{Titulo,nq}")]
        public class Evento
        {
            /// <summary>
            /// Identificar do evento.
            /// </summary>
            public string IdDoEvento { get; set; }

            /// <summary>
            /// Nome do evento.
            /// </summary>
            public string Titulo { get; set; }

            /// <summary>
            /// Data de cadastro na Plataforma.
            /// </summary>
            public DateTime DataDeCadastro { get; set; }

            /// <summary>
            /// Data em que o evento foi gerado.
            /// </summary>
            public DateTime DataDoEvento { get; set; }

            /// <summary>
            /// Informação complementar e opcional.
            /// </summary>
            public string Complemento { get; set; }
        }
    }
}