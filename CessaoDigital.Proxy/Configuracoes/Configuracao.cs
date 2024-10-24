// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

namespace CessaoDigital.Proxy.Configuracoes
{
    /// <summary>
    /// Base para arquivos de configuração.
    /// </summary>
    public abstract class Configuracao
    {
        /// <summary>
        /// Retorna a conexão correspondente ao nome informado.
        /// </summary>
        /// <param name="nome">Nome da conexão.</param>
        /// <returns>Objeto <see cref="Proxy.Conexao"/> correspodente. Nulo será retornado se não houver a conexão com o nome.</returns>
        public Conexao Conexao(string nome) =>
            this.Conexoes?.FirstOrDefault(c => string.Compare(this.ConexaoPadrao, nome, true) == 0);

        /// <summary>
        /// Relação de conexões configuradas.
        /// </summary>
        public IEnumerable<Conexao> Conexoes { get; protected set; }

        /// <summary>
        /// Indica qual conexão será utilizada por padrão.
        /// </summary>
        public string ConexaoPadrao { get; protected set; }
    }
}