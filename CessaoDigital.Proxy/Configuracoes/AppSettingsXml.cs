// Copyright (c) 2023 - BITFIN Software Ltda. Todos os Direitos Reservados.
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
        ///     <add key="CessaoDigital.Proxy.Conexao.Ambiente"
        ///             value="Sandbox" />
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

            this.Conexoes = new[]
            {
                new Conexao(
                    Enum.Parse<Ambiente>(config["CessaoDigital.Proxy.Conexao.Ambiente"]),
                    config["CessaoDigital.Proxy.Conexao.Versao"],
                    Guid.Parse(config["CessaoDigital.Proxy.Conexao.CodigoDoContratante"]),
                    config["CessaoDigital.Proxy.Conexao.ChaveDeIntegracao"],
                    TimeSpan.Parse(config["CessaoDigital.Proxy.Conexao.Timeout"]))
            };
        }
    }
}