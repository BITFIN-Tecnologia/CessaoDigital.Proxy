// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Operação de Antecipação de Notas Fiscais para Fornecedor.
    /// </summary>
    [DebuggerDisplay("{Fornecedor,nq}")]
    public class Antecipacao : Base
    {
        /// <summary>
        /// Entidade antecipadora dos recursos.
        /// </summary>
        public Contratante Sacado { get; set; }

        /// <summary>
        /// Entidade fornecedora que antecipou as pagamentos.
        /// </summary>
        public Fornecedor Fornecedor { get; set; }

        /// <summary>
        /// Conta Bancária para onde os recursos foram enviados.
        /// </summary>
        public ContaBancaria ContaDeDestino { get; set; }

        /// <summary>
        /// Tipo do Pagamento (TED ou PIX).
        /// </summary>
        public string TipoDePagamento { get; set; }

        /// <summary>
        /// Linha de créddito utilizada na Operação.
        /// </summary>
        public LinhaDeCredito LinhaDeCredito { get; set; }

        /// <summary>
        /// Código que identifica unicamente a antecipação na Plataforma.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Data de cadastro da Operação.
        /// </summary>
        public DateTime DataDeCadastro { get; set; }

        /// <summary>
        /// Status de andamento da Operação.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Data do Status.
        /// </summary>
        public DateTime DataDoStatus { get; set; }

        /// <summary>
        /// Resultado financeiro da Operação.
        /// </summary>
        public ResultadoDaAntecipacao Resultado { get; set; }

        /// <summary>
        /// Informações sobre a assinatura digital da Operação.
        /// </summary>
        public DocumentoDigital Formalizacao { get; set; }

        /// <summary>
        /// Data em que o crédito foi realizado.
        /// </summary>
        public DateTime? DataDeCredito { get; set; }

        /// <summary>
        /// Parcelas das Notas Fiscais vinculadas à Operação.
        /// </summary>
        public IEnumerable<Item> Itens { get; set; }

        /// <summary>
        /// Taxas e tarifas aplicadas na Operação.
        /// </summary>
        [DebuggerDisplay("Bruto: {TotalBruto} - Líquido: {TotalLiquido}")]
        public class ResultadoDaAntecipacao
        {
            /// <summary>
            /// Prazo médio (em dias).
            /// </summary>
            public decimal PrazoMedio { get; set; }

            /// <summary>
            /// Quantidade de parcelas antecipadas.
            /// </summary>
            public int QuantidadeDeParcelas { get; set; }

            /// <summary>
            /// Total bruto das parcelas.
            /// </summary>
            public decimal TotalBruto { get; set; }

            /// <summary>
            /// Tarifa por Operação.
            /// </summary>
            public decimal Tac { get; set; }

            /// <summary>
            /// Taxa de juros aplicada.
            /// </summary>
            public decimal TaxaDeJuros { get; set; }

            /// <summary>
            /// Total de juros apurado.
            /// </summary>
            public decimal TotalDeJuros { get; set; }

            /// <summary>
            /// Taxa de rebate aplicada.
            /// </summary>
            public decimal TaxaDeRebate { get; set; }

            /// <summary>
            /// Total de rebate apurado.
            /// </summary>
            public decimal TotalDeRebate { get; set; }

            /// <summary>
            /// Total de IOF apurado (se aplicável).
            /// </summary>
            public decimal TotalDeIof { get; set; }

            /// <summary>
            /// Tarifa de TED/PIX.
            /// </summary>
            public decimal TarifaDePagamento { get; set; }

            /// <summary>
            /// Tarifa de cobrança (por recebível).
            /// </summary>
            public decimal TarifaDeCobranca { get; set; }

            /// <summary>
            /// Tarifa de formalização do aditivo.
            /// </summary>
            public decimal TarifaDeFormalizacaoDeAditivo { get; set; }

            /// <summary>
            /// Tarifa de formalização por duplicata.
            /// </summary>
            public decimal TarifaDeFormalizacaoDeDuplicata { get; set; }

            /// <summary>
            /// Total de cobrança apurado.
            /// </summary>
            public decimal TotalDeCobranca { get; set; }

            /// <summary>
            /// Total de formalização apurado.
            /// </summary>
            public decimal TotalDeFormalizacao { get; set; }

            /// <summary>
            /// Total líquido da Operação.
            /// </summary>
            public decimal TotalLiquido { get; set; }

            /// <summary>
            /// Custo Efetivo Total (CET).
            /// </summary>
            public decimal TaxaEfetiva { get; set; }
        }

        /// <summary>
        /// Detalhes do item associado à Operação.
        /// </summary>
        [DebuggerDisplay("Parcela {Parcela,nq}")]
        public class Item
        {
            /// <summary>
            /// Nota Fiscal Mercantil.
            /// </summary>
            public NFe NotaFiscal { get; set; }

            /// <summary>
            /// Parcela associada.
            /// </summary>
            public NFe.Parcela Parcela { get; set; }

            /// <summary>
            /// Prazo (em dias) para vencimento da parcela.
            /// </summary>
            public int Prazo { get; set; }

            /// <summary>
            /// Valor de IOF da parcela (se aplicável).
            /// </summary>
            public decimal ValorDeIof { get; set; }

            /// <summary>
            /// Valor de juros da parcela.
            /// </summary>
            public decimal ValorDeJuros { get; set; }

            /// <summary>
            /// Valor de rebate da parcela.
            /// </summary>
            public decimal ValorDoRebate { get; set; }

            /// <summary>
            /// Valor líquido da parcela.
            /// </summary>
            public decimal ValorLiquido { get; set; }
        }
    }
}