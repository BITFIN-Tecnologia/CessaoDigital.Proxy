// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Net.Http.Headers;

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
        /// Indica ao que se refere a requisição.
        /// </summary>
        public const string Evento = "CD-Evento";

        /// <summary>
        /// Mime-type para JSON.
        /// </summary>
        public static readonly MediaTypeHeaderValue MediaTypeJson = new("application/json");

        /// <summary>
        /// Mime-type para XML.
        /// </summary>
        public static readonly MediaTypeHeaderValue MediaTypeXml = new("application/xml");

        /// <summary>
        /// Mime-type para ZIP.
        /// </summary>
        public static readonly MediaTypeHeaderValue MediaTypeZip = new("application/zip");
    }
}