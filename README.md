# CessaoDigital.Proxy
###### Comunicação com as API's da Plataforma Cessão Digital
Biblioteca .NET para consumo dos serviços (API's) fornecidos pela Plataforma Cessão Digital para integração entre sistemas. Essa biblioteca abstrai toda a complexidade de comunicação com o protocolo HTTP, simplificando o consumo pelos clientes, que acessarão as classes e métodos que refletem exatamente a documentação da API, não havendo a necessidade de lidar diretamente com código referente à infraestrutura.

Além da comunicação que já está embutida, a biblioteca também oferece recursos para _logging_, correlação de requisições e classes de DTOs (que também são definidas pelas API's). Isso garantirá uma experiência diferenciada para consumo dos serviços, já que o _proxy_ expõe em sua _interface_ pública, métodos e propriedades que refletem o negócio.

> Documentação das API's: [https://cessaodigital.com.br/integracao](https://cessaodigital.com.br/integracao)

> NUGET: [PM> Install-Package BITFIN.CessaoDigital.Proxy](https://www.nuget.org/packages/BITFIN.CessaoDigital.Proxy)

## Conexão e Autenticação
A classe que intermedia toda a comunicação é chamada de `ProxyDoServico`. Essa classe recebe em seu construtor os dados necessários para estabelecer a comunicação com os serviços. Todos os parâmetros necessários são informados através da classe `Conexao`, onde o **código do contratante** e a **chave de integração** são fornecidos no nomento da criação/contratação; além disso, é neste objeto que também deverá ser informado a versão da API a ser utilizada e para qual ambiente as requisições devem ser encaminhadas: **SANDBOX** ou **PRODUÇÃO**.

```csharp
var versao = "v1";
var codigoDoContratante = new Guid("985e0702-e94a-4954-b7a8-1f28c73c8122");
var chaveDeIntegracao = "TWpZd00yTXpPVGN...zWkRVM01qTmhNR0Zq";

using (var proxy = new ProxyDoServico(
    new Conexao(
        Ambiente.Sandbox,
        versao,
        codigoDoContratante,
        chaveDeIntegracao)))
{
    //consumo dos serviços (API's)
}
```

> A classe `Conexao` está associada, exclusivamente, à um único ambiente; pelo fato do _proxy_ receber a conexão em seu construtor, ele só poderá manipular os serviços (API's) referente aquele ambiente. Serão necessárias múltiplas instâncias do _proxy_ caso necessite, simultaneamente, interagir com mais de um ambiente. O _proxy_ é também encarregado de configurar a autenticação da conexão, nomeando e anexando os _headers_ exigidos pelo serviço para identificar quem é o cliente que está consumindo.

As configurações de conexão também estão expostas através da classe abstrata [Configuracao](https://github.com/BITFIN-Software/CessaoDigital.Proxy/blob/master/CessaoDigital.Proxy/Configuracoes/Configuracao.cs), possibilitando a extração destas informações de algum repositório, como por exemplo, dos arquivos de configurações ([App.config](https://github.com/BITFIN-Software/CessaoDigital.Proxy/blob/master/CessaoDigital.Proxy/Configuracoes/AppSettingsXml.cs), Web.config ou [appSettings.json](https://github.com/BITFIN-Software/CessaoDigital.Proxy/blob/master/CessaoDigital.Proxy/Configuracoes/AppSettingsJson.cs)) e com isso, não deixar estes parâmetros em "hard-code", possibilitando a alteração sem a necessidade de recompilar o programa.

## Logging
O _logging_ é um item de extrema importância em ambientes distribuídos, já que invariavelmente, precisamos depurar eventuais problemas que ocorrem. Se o código não estiver bem instrumentado em relação à isso, pode-se perder muito tempo para descobrir o problema e corrigí-lo. Para auxiliar no desenvolvimento e consumo pelos clientes, foi espalhado por toda biblioteca, pontos de captura de informações que podem ser relevantes para a análise. 

Para indicar ao _proxy_ que deseja capturar estas informações, será necessário determinar o local onde estes _logs_ serão armazenados. Nativamente, o biblioteca fornece uma implementação chamada `LogEmTexto` recebe as mensagens e as armazena em um `TextWriter`, porém, se desejar algum repositório mais específico, como uma base de dados por exemplo, basta implementar a _interface_ [ILogger](https://github.com/BITFIN-Software/CessaoDigital.Proxy/blob/master/CessaoDigital.Proxy/Logging/ILogger.cs), customizando cada um dos métodos.

`ILogger` herda da _interface_ `IDisposable`, e quando o _logger_ for envolvido em um bloco `using`, o método `Dispose` é chamado e as mensagens, que estão no `buffer` são armazenadas fisicamente. Uma vez que _logger_ esteja criado, basta informá-lo no construtor do _proxy_, que internamente fará uso, quando necessário, para armazenar as informações mais relevantes, que podem ocorrer durante a preparação e o envio das requisições e para armazenar o resultado recebido dos serviços.

```csharp
using (var log = new LogEmTexto(new StreamWriter("Log.txt", true)))
{
    using (var proxy = new ProxyDoServico(this.Conexao, log))
    {
        //consumo dos serviços (API's)
    }
}

Console.Write(File.ReadAllText("Log.txt"));
```
### Rastreio de Requisições
Opcionalmente, é possível gerar um "código de rastreio", que identifica unicamente a requisição que será enviada ao serviço. Isso permitirá correlacionar a mensagem ao processamento remoto realizado pelo serviço e, consequentemente, facilitar a depuração de eventuais problemas. Da mesma forma que o _log_, o gerador de códigos de rastreios é extensível, e pode ser customizado simplesmente implementando a _interface_ [IRastreio](https://github.com/BITFIN-Software/CessaoDigital.Proxy/blob/master/CessaoDigital.Proxy/Logging/IRastreio.cs). De qualquer forma, já existe um gerador nativo, chamado `RastreioComGuid`, que como o próprio nome sugere, para cada requisição, gera um novo _Guid_.

E, para informar que desejar utilizar um rastreador de requisições, basta informar o gerador de códigos no construtor da classe `ProxyDoServico`, como se vê no trecho de código abaixo. E, na sequência, o conteúdo do _log_ armazenado no arquivo texto. Note, que o Guid que se repete por todas as linhas, relacionam todas as informações associadas aquela requisição e sua respectiva resposta.

```csharp
using (var log = new LogEmTexto(new StreamWriter("Log.txt", true)))
{
    using (var proxy = new ProxyDoServico(this.Conexao, log, new RastreioComGuid()))
    {
        //consumo dos serviços (API's)
    }
}
```

```
11/02/2021 20:52:57 - Info - 2c83d520-138d-45d1-b29c-b9c4bf027ac2 - INÍCIO DO ESCOPO
11/02/2021 20:52:57 - Info - 2c83d520-138d-45d1-b29c-b9c4bf027ac2 - POST /api/v1/ancora/nfe
11/02/2021 20:52:57 - Info - 2c83d520-138d-45d1-b29c-b9c4bf027ac2 - Request.Type: ByteArrayContent
11/02/2021 20:52:57 - Info - 2c83d520-138d-45d1-b29c-b9c4bf027ac2 - Request.Content-Type: 
11/02/2021 20:52:57 - Info - 2c83d520-138d-45d1-b29c-b9c4bf027ac2 - Request.Headers: Authorization: TWpZd00yTXpPVGN...zWkRVM01qTmhNR0Zq;CD-Tracking: 2c83d520-138d-45d1-b29c-b9c4bf027ac2;Accept: application/json
11/02/2021 20:52:57 - Info - 2c83d520-138d-45d1-b29c-b9c4bf027ac2 - Response.StatusCode: Accepted
11/02/2021 20:52:57 - Info - 2c83d520-138d-45d1-b29c-b9c4bf027ac2 - Response.ReasonPhrase: Accepted
11/02/2021 20:52:57 - Info - 2c83d520-138d-45d1-b29c-b9c4bf027ac2 - Response.Type: HttpConnectionResponseContent
11/02/2021 20:52:57 - Info - 2c83d520-138d-45d1-b29c-b9c4bf027ac2 - Response.Content-Type: application/json; charset=utf-8
11/02/2021 20:52:57 - Info - 2c83d520-138d-45d1-b29c-b9c4bf027ac2 - FIM DO ESCOPO
```

> **Correlação com a Resposta:** Por fim, quando este código estiver presente na requisição, a Plataforma o devolverá, também, através do mesmo _header_ na resposta; com isso, a aplicação consumidora poderá realizar alguma consistência sobre ele, como correlacionar as mensagens, armazenamento de _logs_, etc.

> #### CONTATOS
>
> - Site: <https://cessaodigital.com.br>
> - E-mail Técnico: <dev@bitfin.com.br>
> - E-mail Comercial: <contato@cessaodigital.com.br>
> - Telefone (+WhatsApp): +55 (19) 9.9901-1065
