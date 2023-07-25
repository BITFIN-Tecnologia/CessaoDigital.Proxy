// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

namespace CessaoDigital.Proxy.Logging
{
    /// <summary>
    /// Gerador de código de rastreio com base no <see cref="Guid"/>.
    /// </summary>
    public sealed class RastreioComGuid : IRastreio
    {
        /// <summary>
        /// Ao gerar, o método <see cref="Guid.NewGuid()"/> é chamado.
        /// </summary>
        /// <returns>Retorna um <see cref="Guid"/> em formato <c>string</c>.</returns>
        public string Gerar() => Guid.NewGuid().ToString();
    }
}