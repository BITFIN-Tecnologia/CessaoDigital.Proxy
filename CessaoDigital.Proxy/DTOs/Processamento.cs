// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Diagnostics;

namespace CessaoDigital.Proxy.DTOs
{
    /// <summary>
    /// Resultado processamento dos recebíveis enviados.
    /// </summary>
    [DebuggerDisplay("{Status,nq}")]
    public class Processamento
    {
        /// <summary>
        /// Constante para ação de Adição.
        /// </summary>
        public const string Adicao = "Adição";
        /// <summary>
        /// Constante para ação de Atualização.
        /// </summary>
        public const string Atualizacao = "Atualização";
        /// <summary>
        /// Constante para ação de Exclusão.
        /// </summary>
        public const string Exclusao = "Exclusão";

        /// <summary>
        /// Constante para status de Sucesso.
        /// </summary>
        public const string Sucesso = "Sucesso";
        /// <summary>
        /// Constante para status de Falha.
        /// </summary>
        public const string Falha = "Falha";

        /// <summary>
        /// Adição, Atualização ou Exclusão.
        /// </summary>
        public string Acao { get; set; }

        /// <summary>
        /// Campo livre que identifica unicamente o recebível para o contratante.
        /// </summary>
        public string UsoDaEmpresa { get; set; }

        /// <summary>
        /// Código que identifica unicamente o recebível dentro da Plataforma.
        /// </summary>
        public Guid Codigo { get; set; }

        /// <summary>
        /// Sucesso ou Falha.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Tags de livre utilização pelo contratante; serão devolvidas em eventuais callbacks.
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Mensagem gerada durante o processamento.
        /// </summary>
        public string Mensagem { get; set; }
    }
}