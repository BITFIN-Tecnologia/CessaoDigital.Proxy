// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (APIs) da Plataforma Cessão Digital.

namespace CessaoDigital.Proxy.Utilitarios
{
    internal static class Estensoes
    {
        internal static async Task<T> ReadAs<T>(this HttpContent content, CancellationToken cancellationToken = default) where T : class =>
            Serializador.Deserializar<T>(await content.ReadAsStringAsync(cancellationToken));
    }
}