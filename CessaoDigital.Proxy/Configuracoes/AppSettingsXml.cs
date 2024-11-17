// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using SCfg = System.Configuration;

namespace CessaoDigital.Proxy.Configuracoes
{
    /// <summary>
    /// Configurações baseadas no arquivo app/web.config (XML).
    /// </summary>
    public sealed class AppSettingsXml : Configuracao
    {
        /// <summary>
        /// Inicializa as configurações extraindo as informações do arquivo app/web.config.
        /// </summary>
        /// <example>
        /// <code>
        /// <appSettings>
        ///     <add key="CessaoDigital.Proxy.Conexao.Nome"
        ///             value="ID123" />
        ///     <add key="CessaoDigital.Proxy.Conexao.Descricao"
        ///             value="Nome do Sacado" />
        ///     <add key="CessaoDigital.Proxy.Conexao.Url"
        ///             value="https://sacado1.cessaodigital.com.br" />
        ///     <add key="CessaoDigital.Proxy.Conexao.Versao"
        ///             value="v1" />
        ///     <add key="CessaoDigital.Proxy.Conexao.CodigoDoContratante"
        ///             value="985e0702-e94a-4954-b7a8-1f28c73c8122" />
        ///     <add key="CessaoDigital.Proxy.Conexao.ChaveDeIntegracao"
        ///             value="TWpZd00yTXpPVGN...zWkRVM01qTmhNR0Zq" />
        ///     <add key="CessaoDigital.Proxy.Conexao.Timeout"
        ///             value="00:00:10" />
        /// </appSettings>
        /// </code>
        /// </example>
        public AppSettingsXml()
        {
            var config = SCfg.ConfigurationManager.AppSettings;

            this.Conexoes =
            [
                new Conexao(
                    config["CessaoDigital.Proxy.Conexao.Nome"],
                    config["CessaoDigital.Proxy.Conexao.Descricao"],
                    config["CessaoDigital.Proxy.Conexao.Url"],
                    config["CessaoDigital.Proxy.Conexao.Versao"],
                    Guid.Parse(config["CessaoDigital.Proxy.Conexao.CodigoDoContratante"]),
                    config["CessaoDigital.Proxy.Conexao.ChaveDeIntegracao"],
                    TimeSpan.Parse(config["CessaoDigital.Proxy.Conexao.Timeout"]))
            ];
        }
    }
}