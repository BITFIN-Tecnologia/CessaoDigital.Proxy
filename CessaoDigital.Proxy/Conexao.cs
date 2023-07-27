// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using CessaoDigital.Proxy.Utilitarios;
using System.Diagnostics;

namespace CessaoDigital.Proxy
{
    /// <summary>
    /// Informações necessárias para iniciar a comunicação com o serviço.
    /// </summary>
    [DebuggerDisplay("{Ambiente}")]
    public class Conexao
    {
        private static readonly Dictionary<Ambiente, string> apis = new(3)
        {
            { Ambiente.Sandbox, "https://sandbox.cessaodigital.com.br/api/{0}/" },
            { Ambiente.Producao, "https://cessaodigital.com.br/api/{0}/" },
            { Ambiente.Local, "https://localhost:44312/api/{0}/" }
        };

        /// <summary>
        /// Inicializa a conexão com o mínimo necessário para estabelecer a comunicação com um determinado <see cref="Proxy.Ambiente"/>.
        /// </summary>
        /// <param name="ambiente">Ambiente de testes (Sandbox), produção ou local.</param>
        /// <param name="versao">Versão da API que deve ser utilizada.</param>
        /// <param name="codigoDoContratante">Código exclusivo do contratante.</param>
        /// <param name="chaveDeIntegracao">Chave de integração da Aplicação.</param>
        /// <param name="timeout">Define o tempo máximo de espera permitido para executar uma requisição. O tempo padrão é de 100 segundos.</param>
        /// <exception cref="ArgumentException">Se o <paramref name="codigoDoContratante"/> ou o <paramref name="chaveDeIntegracao"/> forem <see cref="Guid.Empty"/> ou se a <paramref name="versao"/> for vazia.</exception>
        public Conexao(Ambiente ambiente, string versao, Guid codigoDoContratante, string chaveDeIntegracao, TimeSpan? timeout = null)
        {
            this.Versao = !string.IsNullOrWhiteSpace(versao) ? versao : throw new ArgumentException("Versão não informada.", nameof(versao));

            this.CodigoDoContratante =
                codigoDoContratante != Guid.Empty ? codigoDoContratante : throw new ArgumentException("Código do Contratante não informado.", nameof(codigoDoContratante));

            this.ChaveDeIntegracao =
                !string.IsNullOrWhiteSpace(chaveDeIntegracao) ? chaveDeIntegracao : throw new ArgumentException("Chave de integração não informada.", nameof(chaveDeIntegracao));

            this.Timeout = timeout ?? TimeSpan.FromSeconds(100);

            this.Ambiente = ambiente;
            this.Url = new(string.Format(apis[ambiente], this.Versao));
        }

        /// <summary>
        /// Ambiente a qual a conexão se refere.
        /// </summary>
        public Ambiente Ambiente { get; private set; }

        /// <summary>
        /// Versão da API.
        /// </summary>
        public string Versao { get; private set; }

        /// <summary>
        /// Código do Contratante.
        /// </summary>
        public Guid CodigoDoContratante { get; private set; }

        /// <summary>
        /// Chave de Integração gerado para o contratante.
        /// </summary>
        public string ChaveDeIntegracao { get; private set; }

        /// <summary>
        /// Define o tempo máximo de espera permitido para executar uma requisição. O tempo padrão é de 100 segundos.
        /// </summary>
        public TimeSpan Timeout { get; private set; }

        /// <summary>
        /// Endereço base (HTTP) onde as API's estão hospedadas, que varia de acordo com o <see cref="Ambiente"/>.
        /// </summary>
        public Uri Url { get; private set; }

        /// <summary>
        /// Retorna a conexão em formato do header Authorization.
        /// </summary>
        /// <param name="comLabel">Indica se deve incluir a chave Authorization. O padrão é <c>true</c>.</param>
        /// <returns><see cref="String"/> representando a respectiva conexão.</returns>
        public string GerarCabecalho(bool comLabel = true) =>
            comLabel ?
                $"Autorization:{Protocolo.ApiKey} {$"{this.CodigoDoContratante}:{this.ChaveDeIntegracao}".EmBase64()}" :
                $"{$"{this.CodigoDoContratante}:{this.ChaveDeIntegracao}".EmBase64()}";
    }
}