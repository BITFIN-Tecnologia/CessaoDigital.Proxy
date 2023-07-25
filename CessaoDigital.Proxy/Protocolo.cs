// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

namespace CessaoDigital.Proxy
{
    /// <summary>
    /// Constantes utilizadas na comunicação.
    /// </summary>
    public static class Protocolo
    {
        /// <summary>
        /// Scheme de autorização.
        /// </summary>
        public const string ApiKey = "CD-ApiKey";

        /// <summary>
        /// Chave para correlação de requisição e resposta.
        /// </summary>
        public const string CodigoDeRastreio = "CD-Tracking";

        /// <summary>
        /// Formato padrão de serialização das requisições e resposta.
        /// </summary>
        public const string MimeType = "application/json";
    }
}