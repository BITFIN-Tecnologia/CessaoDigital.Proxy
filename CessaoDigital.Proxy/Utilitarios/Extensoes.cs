// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using System.Text;

namespace CessaoDigital.Proxy.Utilitarios
{
    internal static class Estensoes
    {
        internal static async Task<T> ReadAs<T>(this HttpContent content, CancellationToken cancellationToken = default) where T : class =>
            Serializador.Deserializar<T>(await content.ReadAsStringAsync(cancellationToken));

        internal static byte[] EmBytes(this string conteudo) => Encoding.UTF8.GetBytes(conteudo);

        internal static string EmBase64(this string conteudo) => Convert.ToBase64String(conteudo.EmBytes());
    }
}