// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

namespace CessaoDigital.Proxy.Configuracoes
{
    /// <summary>
    /// Base para arquivos de configuração.
    /// </summary>
    public abstract class Configuracao
    {
        /// <summary>
        /// Retorna a conexão correspondente à um determinado (<see cref="Ambiente"/>).
        /// </summary>
        /// <param name="ambiente">Ambiente para conexão.</param>
        /// <returns>Objeto <see cref="Proxy.Conexao"/> correspodente. Nulo será retornado se não houver uma conexão com o ambiente.</returns>
        public Conexao Conexao(Ambiente ambiente) =>
            this.Conexoes?.FirstOrDefault(c => c.Ambiente == ambiente);

        /// <summary>
        /// Relação de conexões configuradas.
        /// </summary>
        public IEnumerable<Conexao> Conexoes { get; protected set; }
    }
}