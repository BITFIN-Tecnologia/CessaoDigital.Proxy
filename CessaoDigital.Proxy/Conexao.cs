// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using CessaoDigital.Proxy.Utilitarios;
using System.Diagnostics;

namespace CessaoDigital.Proxy
{
    /// <summary>
    /// Informações necessárias para iniciar a comunicação com o serviço.
    /// </summary>
    [DebuggerDisplay("{Nome,nq}")]
    public class Conexao
    {
        /// <summary>
        /// Inicializa a conexão através da URL de produção onde a Plataforma está hospedada.
        /// </summary>
        /// <param name="nome">Nome que identifica unicamente a Conexão.</param>
        /// <param name="url">Endereço absoluto da Plataforma.</param>
        /// <param name="versao">Versão da API que deve ser utilizada.</param>
        /// <param name="codigoDoContratante">Código exclusivo do contratante.</param>
        /// <param name="chaveDeIntegracao">Chave de integração da Aplicação.</param>
        /// <param name="timeout">Define o tempo máximo de espera permitido para executar uma requisição. O tempo padrão é de 100 segundos.</param>
        /// <exception cref="ArgumentException">Se o <paramref name="codigoDoContratante"/> ou o <paramref name="chaveDeIntegracao"/> forem <see cref="Guid.Empty"/> ou se a <paramref name="versao"/> for vazia.</exception>
        public Conexao(string nome, string url, string versao, Guid codigoDoContratante, string chaveDeIntegracao, TimeSpan? timeout = null)
        {
            this.Nome =
                !string.IsNullOrWhiteSpace(nome) ? nome : throw new ArgumentException("O nome da aplicação não foi informada.", nameof(nome));

            this.Url =
                !string.IsNullOrWhiteSpace(url) && Uri.TryCreate(url, UriKind.Absolute, out var u) ? new(string.Format(u.ToString(), this.Versao)) : throw new ArgumentException("A URL está inválida.", nameof(url));

            this.Versao = !string.IsNullOrWhiteSpace(versao) ? versao : throw new ArgumentException("Versão não informada.", nameof(versao));

            this.CodigoDoContratante =
                codigoDoContratante != Guid.Empty ? codigoDoContratante : throw new ArgumentException("Código do Contratante não informado.", nameof(codigoDoContratante));

            this.ChaveDeIntegracao =
                !string.IsNullOrWhiteSpace(chaveDeIntegracao) ? chaveDeIntegracao : throw new ArgumentException("Chave de integração não informada.", nameof(chaveDeIntegracao));

            this.Timeout = timeout ?? TimeSpan.FromSeconds(100);
        }

        /// <summary>
        /// Nome que identifica unicamente a Conexão.
        /// </summary>
        public string Nome { get; private set; }

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
        /// Endereço base (HTTP) onde as API's estão hospedadas.
        /// </summary>
        public Uri Url { get; private set; }

        /// <summary>
        /// Retorna a conexão em formato do header Authorization.
        /// </summary>
        /// <param name="comLabel">Indica se deve incluir a chave Authorization. O padrão é <c>true</c>.</param>
        /// <returns><see cref="String"/> representando a respectiva conexão.</returns>
        public string GerarCabecalho(bool comLabel = true) =>
            comLabel ?
                $"Authorization:{Protocolo.ApiKey} {$"{this.CodigoDoContratante}:{this.ChaveDeIntegracao}".EmBase64()}" :
                $"{$"{this.CodigoDoContratante}:{this.ChaveDeIntegracao}".EmBase64()}";
    }
}