// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Informações sobre a nota fiscal mercantil.
    /// </summary>
    [DebuggerDisplay("{Emitente,nq} - Nro.: {Numero} - Valor: {Valor}")]
    public class NFe : Base
    {
        /// <summary>
        /// Entidade emissora da nota fiscal.
        /// </summary>
        public Entidade Emitente { get; set; }

        /// <summary>
        /// Entidade destinatária da nota fiscal.
        /// </summary>
        public Entidade Destinatario { get; set; }

        /// <summary>
        /// Chave do DANFE.
        /// </summary>
        public string Danfe { get; set; }

        /// <summary>
        /// Número da nota fiscal.
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Data/hora de emissão da nota fiscal.
        /// </summary>
        public DateTime DataDeEmissao { get; set; }

        /// <summary>
        /// Valor total da nota fiscal.
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Quantidade de parcelas constantes na nota fiscal.
        /// </summary>
        public int QuantidadeDeParcelas { get; set; }

        /// <summary>
        /// Representação da nota fiscal (XML).
        /// </summary>
        public string Conteudo { get; set; }

        /// <summary>
        /// Data de cadastro na Plataforma.
        /// </summary>
        public DateTime DataDeCadastro { get; set; }

        /// <summary>
        /// Status de autorização junto à SEFAZ.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Relação de parcelas da nota fiscal.
        /// </summary>
        public IList<Parcela> Parcelas { get; set; }

        /// <summary>
        /// Dados da parcela.
        /// </summary>
        [DebuggerDisplay("{Numero,nq} - {DataDeVencimento} - Valor: {Valor}")]
        public class Parcela
        {
            /// <summary>
            /// Número (sequencial) da parcela.
            /// </summary>
            public int Numero { get; set; }

            /// <summary>
            /// Data de vencimento.
            /// </summary>
            public DateTime DataDeVencimento { get; set; }

            /// <summary>
            /// Valor total da parcela.
            /// </summary>
            public decimal Valor { get; set; }

            /// <summary>
            /// Indica se a mesma já foi antecipada.
            /// </summary>
            public bool Antecipada { get; set; }
        }
    }
}