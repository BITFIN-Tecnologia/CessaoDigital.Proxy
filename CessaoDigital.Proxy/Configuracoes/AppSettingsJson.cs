// Copyright (c) 2023 - BITFIN Tecnologia Ltda. Todos os Direitos Reservados.
// Código exclusivo para consumo dos serviços (API's) da Plataforma Cessão Digital.

using Microsoft.Extensions.Configuration;

namespace CessaoDigital.Proxy.Configuracoes
{
    /// <summary>
    /// Configurações baseadas no arquivo appsettings.json (JSON).
    /// </summary>
    public sealed class AppSettingsJson : Configuracao
    {
        /// <summary>
        /// Inicializa as configurações extraindo as informações do arquivo appsettings.json.
        /// </summary>
        /// <example>
        /// <code>
        ///{
        ///  "CessaoDigital.Proxy": {
        ///    "ConexaoPadrao": "Producao",
        ///    "Conexoes": [
        ///      {
        ///        "Ambiente": "Sandbox",
        ///        "Versao": "v1",
        ///        "CodigoDoContratante": "985e0702-e94a-4954-b7a8-1f28c73c8122",
        ///        "ChaveDeIntegracao": "TWpZd00yTXpPVGN...zWkRVM01qTmhNR0Zq",
        ///        "Timeout": "00:00:10"
        ///      },
        ///      {
        ///        "Ambiente": "Producao",
        ///        "Versao": "v1",
        ///        "CodigoDoContratante": "985e0702-e94a-4954-b7a8-1f28c73c8122",
        ///        "ChaveDeIntegracao": "zWkRVM01qTmhNR0Zq...TWpZd00yTXpPVGN",
        ///        "Timeout": "00:00:20"
        ///      }
        ///    ]
        ///  }
        ///}
        /// </code>
        /// </example>
        public AppSettingsJson()
        {
            var config =
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                    .Build();

            var conexoes =
                from c in config.GetSection("CessaoDigital.Proxy:Conexoes").GetChildren()
                select new Conexao(
                    Enum.Parse<Ambiente>(c["Ambiente"]),
                    c["Versao"],
                    Guid.Parse(c["CodigoDoContratante"]),
                    c["ChaveDeIntegracao"],
                    TimeSpan.Parse(c["Timeout"]));

            if (VerificarDuplicidades(conexoes, out var ambiente))
                throw new InvalidOperationException($"Existem duas ou mais conexões com o ambiente \"{ambiente}\".");

            this.Conexoes = conexoes;
            this.ConexaoPadrao = Enum.Parse<Ambiente>(config.GetSection("CessaoDigital.Proxy")["ConexaoPadrao"]);
        }

        private static bool VerificarDuplicidades(IEnumerable<Conexao> conexoes, out Ambiente? ambiente)
        {
            ambiente = conexoes.GroupBy(static c => c.Ambiente).FirstOrDefault(static c => c.Count() > 1)?.Key;

            return ambiente != null;
        }
    }
}