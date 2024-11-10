// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Informações sobre a Linha de Crédito.
    /// </summary>
    [DebuggerDisplay("{ContaBancaria.Banco,nq} - Lim. Disp.: {LimiteDisponivel}")]
    public class LinhaDeCredito : Base
    {
        /// <summary>
        /// Data em que a linha de crédito foi cadastrada na Plataforma.
        /// </summary>
        public DateTime DataDeCadastro { get; set; }

        /// <summary>
        /// Número do Contrato junto à Instituição Financeira.
        /// </summary>
        public string NumeroDoContrato { get; set; }

        /// <summary>
        /// Limite total concedido pela Instituição Financeira.
        /// </summary>
        public decimal Limite { get; set; }

        /// <summary>
        /// Total utilizado do limite.
        /// </summary>
        public decimal LimiteUtilizado { get; set; }

        /// <summary>
        /// Indica se a Plataforma deverá impedir a Operação se não houver limite disponível.
        /// </summary>
        public bool AvaliaDisponibilidadeDeLimite { get; set; }

        /// <summary>
        /// Define o limitador de quanto um fornecedor poderá antecipar.
        /// </summary>
        public decimal? ConcentracaoPorFornecedor { get; set; }

        /// <summary>
        /// Taxa de juros aplicada nesta linha.
        /// </summary>
        public decimal TaxaDeJuros { get; set; }

        /// <summary>
        /// Taxa de rebate acordada cmo a Instituição.
        /// </summary>
        public decimal TaxaDeRebate { get; set; }

        /// <summary>
        /// Indica se incide ou não a cobrança de IOF.
        /// </summary>
        public bool IncideIof { get; set; }

        /// <summary>
        /// Tarifa por operação.
        /// </summary>
        public decimal Tac { get; set; }

        /// <summary>
        /// Quantidade de dias para ser acrescido ao prazo.
        /// </summary>
        public decimal Floating { get; set; }

        /// <summary>
        /// Tarifa de TED/PIX.
        /// </summary>
        public decimal TarifaDePagamento { get; set; }

        /// <summary>
        /// Tarifa de Registro no Banco Cobrador.
        /// </summary>
        public decimal TarifaDeCobranca { get; set; }

        /// <summary>
        /// Tarifa com formalização de Aditivo (assinaturas digitais).
        /// </summary>
        public decimal TarifaDeFormalizacaoDeAditivo { get; set; }

        /// <summary>
        /// Tarifa com formalização de Duplicata (assinaturas digitais).
        /// </summary>
        public decimal TarifaDeFormalizacaoDeDuplicata { get; set; }

        /// <summary>
        /// Conta na Instituição Financeira que concedeu o limite.
        /// </summary>
        public ContaBancaria ContaBancaria { get; set; }

        /// <summary>
        /// Conta na Instituição (FIDC, Factoring ou Securitizadora) que concedeu o limite.
        /// </summary>
        public ContaOperacional ContaOperacional { get; set; }

        /// <summary>
        /// Hora inicial em que esta linha está disponível para o recebimento de operações.
        /// </summary>
        public TimeSpan HoraInicialDasOperacoes { get; set; }

        /// <summary>
        /// Hora final em que esta linha recebe operações para análise e pagamento dentro do mesmo dia.
        /// </summary>
        public TimeSpan HoraFinalDasOperacoes { get; set; }

        /// <summary>
        /// Indica se a linha está ativa para a realização de operações.
        /// </summary>
        public bool Ativa { get; set; }

        /// <summary>
        /// Relação de fornecedores formalizados na linha de crédito.
        /// </summary>
        public IList<Fornecedor> Fornecedores { get; set; }
    }
}