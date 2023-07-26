// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Dados do recebível negociado.
    /// </summary>
    [DebuggerDisplay("Sacado: {Sacado,nq} - {Numero,nq} - Valor: {Valor}")]
    public class Recebivel : Base
    {
        /// <summary>
        /// Contratante da Plataforma.
        /// </summary>
        public Contratante Contratante { get; set; }

        /// <summary>
        /// Dados da operação onde o recebível foi cessionado.
        /// </summary>
        public Operacao Operacao { get; set; }

        /// <summary>
        /// Dados do cedente que negociou o recebível.
        /// </summary>
        public Entidade Cedente { get; set; }

        /// <summary>
        /// Dados do sacado/pagador do recebível.
        /// </summary>
        public Entidade Sacado { get; set; }

        /// <summary>
        /// Informações do sacador/avalista do boleto para pagamento.
        /// </summary>
        public Entidade SacadorAvalista { get; set; }

        /// <summary>
        /// Banco ou Instituição Financeira onde o recebível está registrado para cobrança.
        /// </summary>
        public Banco Banco { get; set; }

        /// <summary>
        /// Código que identifica unicamente o recebível dentro da Plataforma.
        /// </summary>
        public Guid Codigo { get; set; }

        /// <summary>
        /// Data em que o recebível foi cadastrado na Plataforma.
        /// </summary>
        public DateTime DataDeCadastro { get; set; }

        /// <summary>
        /// Número do recebível. Em geral, refere-se ou número da duplicata ou do boleto.
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// DM (Duplicata Mercantil) ou DS (Duplicata de Serviço).
        /// </summary>
        public string Especie { get; set; }

        /// <summary>
        /// Data em que foi emitido o recebível.
        /// </summary>
        public DateTime DataDeEmissao { get; set; }

        /// <summary>
        /// Data de vencimento.
        /// </summary>
        public DateTime DataDeVencimento { get; set; }

        /// <summary>
        /// Data de vencimento efetiva (corrigindo fins de semana e/ou feriados (nacionais/estaduais/municipais)).
        /// </summary>
        public DateTime DataDeVencimentoEfetiva { get; set; }

        /// <summary>
        /// Dados do Protesto.
        /// </summary>
        public DadosDoProtesto Protesto { get; set; }

        /// <summary>
        /// Data em que o recebível foi negativado.
        /// </summary>
        public DateTime? DataDeNegativacao { get; set; }

        /// <summary>
        /// Valor de face do recebível, limitado à R$ 100.000.000,00.
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Valor de abatimento concedido para o recebível (incondicional).
        /// </summary>
        public decimal ValorDeAbatimento { get; set; }

        /// <summary>
        /// Valor líquido para pagamento (deduzido o valor do abatimento).
        /// </summary>
        public decimal ValorLiquido { get; set; }

        /// <summary>
        /// Valor total pago pelo recebível.
        /// </summary>
        public decimal ValorDePagamento { get; set; }

        /// <summary>
        /// Situação do recebível (Em Aberto, Liquidado, Liquidado em Cartório, Baixado, Recomprado pelo Cedente ou Recomprado pelo Sacado).
        /// </summary>
        public string Situacao { get; set; }

        /// <summary>
        /// Data da situação em que encontra-se o recebível.
        /// </summary>
        public DateTime? DataDaSituacao { get; set; }

        /// <summary>
        /// Cedente Desconhecido, Operação Improcedente, Valor Divergente, Pedido Cancelado, Mercadoria em Trânsito, Entrega Atrasada, Entregue Parcialmente e Mercadoria Entregue.
        /// </summary>
        public string ManifestoDoSacado { get; set; }

        /// <summary>
        /// Data da manifestação realizada pelo sacado.
        /// </summary>
        public DateTime? DataDoManifestoDoSacado { get; set; }

        /// <summary>
        /// Campo livre que identifica unicamente o recebível para o contratante.
        /// </summary>
        public string UsoDaEmpresa { get; set; }

        /// <summary>
        /// Código da agência bancária (sem dígito) onde o recebível está registrado.
        /// </summary>
        public string AgenciaBancaria { get; set; }

        /// <summary>
        /// Número da conta bancária (com dígito) onde o recebível está registrado.
        /// </summary>
        public string ContaBancaria { get; set; }

        /// <summary>
        /// Número da carteira bancária onde o recebível está registrado.
        /// </summary>
        public string CarteiraBancaria { get; set; }

        /// <summary>
        /// Convênio gerado pelo Banco cobrador. Para alguns bancos, este informação é obrigatória para geração do boleto de pagamento.
        /// </summary>
        public string? ConvenioDeCobranca { get; set; }

        /// <summary>
        /// Registrado ou Baixado.
        /// </summary>
        public string StatusDeCobranca { get; set; }

        /// <summary>
        /// Número bancário (nosso número) que o recebível foi registrado no Banco cobrador.
        /// </summary>
        public string NumeroBancario { get; set; }

        /// <summary>
        /// Dígito do número bancário.
        /// </summary>
        public string DigitoDoNumeroBancario { get; set; }

        /// <summary>
        /// Multa se pago vencido.
        /// </summary>
        public decimal Multa { get; set; }

        /// <summary>
        /// Juros aplicado por dia de atraso no pagamento.
        /// </summary>
        public decimal JurosDeMora { get; set; }

        /// <summary>
        /// Valor de bonificação por dia antecipado de pagamento.
        /// </summary>
        public decimal BonificacaoDiaria { get; set; }

        /// <summary>
        /// Tags de livre utilização pelo contratante; serão devolvidas em eventuais callbacks.
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Armazena a última data em que o recebível foi alterado.
        /// </summary>
        public DateTime DataDeAtualizacao { get; set; }

        /// <summary>
        /// Relação de descontos concedidos para o recebível.
        /// </summary>
        public List<Desconto> Descontos { get; set; }

        /// <summary>
        /// Documentos fiscais associados ao recebível.
        /// </summary>
        public List<DocumentoFiscal> DocumentosFiscais { get; set; }

        /// <summary>
        /// Mensagens que são estampadas no corpo do boleto de pagamento.
        /// </summary>
        public List<string> Mensagens { get; set; }

        /// <summary>
        /// Relação de ocorrências.
        /// </summary>
        public List<Ocorrencia> Ocorrencias { get; set; }

        /// <summary>
        /// Informações sobre o protesto.
        /// </summary>
        public class DadosDoProtesto
        {
            /// <summary>
            /// Número do cartório onde o protesto foi registrado.
            /// </summary>
            public string Cartorio { get; set; }

            /// <summary>
            /// Data em que o recebível será protestado se não for pago.
            /// </summary>
            public DateTime? DataParaProtesto { get; set; }

            /// <summary>
            /// Data em que ocorreu a sustação do protesto.
            /// </summary>
            public DateTime? DataDeSustacao { get; set; }

            /// <summary>
            /// Data em que ocorreu o protesto do recebível.
            /// </summary>
            public DateTime? DataDeProtesto { get; set; }

            /// <summary>
            /// Número do protocolo gerado pelo cartório.
            /// </summary>
            public string Protocolo { get; set; }
        }

        /// <summary>
        /// Informação sobre descontos à conceder.
        /// </summary>
        [DebuggerDisplay("Até {Data}: {Valor}")]
        public class Desconto
        {
            /// <summary>
            /// Data limite para desconto.
            /// </summary>
            public DateTime Data { get; set; }

            /// <summary>
            /// Valor do desconto.
            /// </summary>
            public decimal Valor { get; set; }
        }

        /// <summary>
        /// Eventos ocorridos sobre o recebível.
        /// </summary>
        [DebuggerDisplay("{Data} {Tipo,nq} - {Mensagem,nq}")]
        public class Ocorrencia
        {
            /// <summary>
            /// Tipo da ocorrência.
            /// </summary>
            public string Tipo { get; set; }

            /// <summary>
            /// Data da ocorrência.
            /// </summary>
            public DateTime Data { get; set; }

            /// <summary>
            /// Mensagem complementar.
            /// </summary>
            public string Mensagem { get; set; }
        }
    }
}