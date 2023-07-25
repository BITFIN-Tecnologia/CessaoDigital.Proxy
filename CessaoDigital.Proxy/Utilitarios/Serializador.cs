// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Text;
using System.Text.Json;

namespace CessaoDigital.Proxy.Utilitarios
{
    internal static class Serializador
    {
        internal static class Json
        {
            private static readonly JsonSerializerOptions config = new()
            {
                WriteIndented = false,
                PropertyNameCaseInsensitive = true
            };

            internal static string Serializar(object objeto, bool identado = false) =>
                JsonSerializer.Serialize(objeto, objeto.GetType(), !identado ? config : new JsonSerializerOptions(config) { WriteIndented = true });

            internal static T Deserializar<T>(string conteudo) where T : class =>
                JsonSerializer.Deserialize<T>(conteudo, config);
        }

        internal static string Serializar(object objeto) =>
            Json.Serializar(objeto);

        internal static T Deserializar<T>(string conteudo) where T : class =>
            Json.Deserializar<T>(conteudo);

        internal static byte[] EmBytes(this string conteudo) => Encoding.UTF8.GetBytes(conteudo);
    }
}