# Wiz - Azure Function

![](https://github.com/wizsolucoes/fn-wiz-template/workflows/.NET%20Core/badge.svg)

- [Desenvolvimento, por onde começar](#desenvolvimento-por-onde-começar)
- [Execução do projeto](#execução-do-projeto)
- [Estrutura](#estrutura)
- [Dependências](#dependências)
- [Build e testes](#build-e-testes)
- [NuGET privado](#nuget-privado)
- [CI/CD](#ci/cd)
- [README](#readme)

## Desenvolvimento, por onde começar

Passos para execução do projeto:

1. Abrir *Prompt de Comando* de sua preferência (**CMD** ou **PowerShell**);

2. Criar pasta para o projeto no local desejado;

3. Executar os seguintes comandos;
  > *dotnet new -i Wiz.Dotnet.Template.Function*    
    *dotnet new wizfunction -n [NomeProjeto]*

4. Incluir configurações de *varíaveis de ambiente* no caminho abaixo:

### **Visual Studio**

```
├── Wiz.[NomeProjeto] (solução)
  ├── Wiz.[NomeProjeto].Function (projeto)
    ├── local.settings.json
```

### **Visual Studio Code**

```
├── src (pasta física)
  ├── Wiz.[NomeProjeto].Function (projeto)
    ├── local.settings.json
```

Dentro do arquivo *local.settings.json*, há o conteúdo para modificação das variáveis:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "CONNECTION_STRING_STORAGE_AZURE",
    "APPINSIGHTS_INSTRUMENTATIONKEY": "KEY_APPLICATION_INSIGHTS",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet"
  }
}
```

5. *(Opcional)* Inserir chave do **Application Insights** conforme configurado no Azure.

Caso não há chave de configuração no Azure, não é necessário inserir para executar o projeto local.

## Execução do projeto

### **Visual Studio**

1. Executar projeto **Wiz.[NomeProjeto].Function** *(Tecla F5)*.

### **Visual Studio Code**

1. *(Recomendado)* Instalar extensões para desenvolvimento:
  + [ASP.NET core VS Code Extension Pack](https://marketplace.visualstudio.com/items?itemName=temilaj.asp-net-core-vs-code-extension-pack)
  + [Azure Functions](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions)
  + [GitLens — Git supercharged](https://marketplace.visualstudio.com/items?itemName=eamodio.gitlens)
  + [NuGet Package Manager](https://marketplace.visualstudio.com/items?itemName=jmrog.vscode-nuget-package-manager)
  + [vscode-icons](https://marketplace.visualstudio.com/items?itemName=vscode-icons-team.vscode-icons)

2. *(Recomendado)* Instalar extensões para testes:
  + [.NET Core Test Explorer](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer)
  + [Coverage Gutters](https://marketplace.visualstudio.com/items?itemName=ryanluker.vscode-coverage-gutters)

3. Executar projeto **Wiz.[NomeProjeto].Function** *(Tecla F5)*.

4. Aceitar instalação do pacote **Azure Functions Tools** para poder realizar *debug* do projeto;

5. Selecionar versão **.NET Stardand (v2)**;

A instalação do pacote também poderá ser feita de maneira manual com o seguinte comando:
  > *npm install -g azure-functions-core-tools@2*

6. Utilizar a função **task** para executar ações dentro do projeto. A função está presente no caminho do *menu* abaixo:

```
Terminal -> Run Task
```

7. Selecionar a função **task** a ser executada no projeto:
  + *clean* - Limpar solução 
  + *restore* - Restaurar pacotes da solução
  + *build* - Compilar pacotes da solução
  + *func: host start* - Executar function em modo *release*
  + *test* - Executar projeto de testes
  + *test with coverage* - Executar projeto de testes com cobertura

## Estrutura

Padrão das camadas do projeto:

1. **Wiz.[NomeProjeto].CrossCutting**: camada responsável por conter código que podem ser utilizados de forma transversal (mais de uma camada), não podendo ser isolados em um componente específico sem relação direta com todos os outros. Exemplos de funcionalidades dessa camada: Inversion Of Control (IoC), logging do sistema, segurança entre outros comum a todas camadas;
1. **Wiz.[NomeProjeto].Domain**: domínio da aplicação, responsável de manter as *regras de negócio* para as function(s);
2. **Wiz.[NomeProjeto].Infra**: responsável por fornecer capacidade técnicas para suportar as camadas superiores, como por exemplo envio de mensagens para outras aplicações, persistência dos dados da camada de domínio;
3. **Wiz.[NomeProjeto].Function**: responsável pela camada de *disponibilização* das function(s);
4. **Wiz.[NomeProjeto].Tests**: responsável pela camada de *testes unitários e de integração* dos projetos.

Formatação do projeto dentro do repositório:

```
├── src
  ├── Wiz.[NomeProjeto].CrossCutting (projeto)
  ├── Wiz.[NomeProjeto].Domain (projeto)
  ├── Wiz.[NomeProjeto].Infra (projeto)
  ├── Wiz.[NomeProjeto].Function (projeto)
  ├── Wiz.[NomeProjeto].Tests (projeto)
├── Wiz.[NomeProjeto] (solução)
```

## Dependências

* [Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/)

## Build e testes

* Obrigatoriedade de **não diminuir** os testes de cobertura.

### **Visual Studio**

1. Comandos para geração de build:
  + Debug: Executar via Test Explorer (adicionar breakpoint)
  + Release: Executar via Test Explorer (não adicionar breakpoint)

2. Ativar funcionalidade [Live Unit Testing](https://docs.microsoft.com/en-us/visualstudio/test/live-unit-testing?view=vs-2017) para executar testes em tempo de desenvolvimento (execução) do projeto.

3. Ativar funcionalidade [Code Coverage](https://docs.microsoft.com/en-us/visualstudio/test/using-code-coverage-to-determine-how-much-code-is-being-tested?view=vs-2017) para cobertura de testes.

As funcionalidades **Live Unit Testing** e **Code Coverage** estão disponíveis apenas na versão **Enterprise** do Visual Studio.

### **Visual Studio Code**

1. Executar **task** de teste desejada:
  + *test* - Executar projeto de testes
  + *test with coverage* - Executar projeto de testes com cobertura

2. Ativar **Watch** na parte inferior do Visual Studio Code para habilitar cores nas classes que descrevem a cobertura. É necessário executar os testes no modo *test with coverage*.

### **Sonar**

1. Dentro do arquivo dos projetos **(.csproj)** no campo **PropertyGroup**, é necessário adicionar um GUID no formato abaixo:

```
<PropertyGroup>
  <ProjectGuid>{b5c970c2-a7cc-4052-b07b-b599b83fc621}</ProjectGuid>
</PropertyGroup>
```

2. O GUID pode ser coletado no arquivo da solution ou criado pelo site: https://www.guidgenerator.com/.

## NuGet privado

### **Visual Studio**

1. Adicionar *url* do NuGet privado no caminho do *menu* abaixo:

```
Tools -> NuGet Package Manager -> Package Sources
```

### **Visual Studio Code**

1. Abrir *Prompt de Comando* de sua preferência (**CMD** ou **PowerShell**) ou utilizar o terminal do Visual Studio Code;

2. Executar script Powershell para adicionar permissão do NuGet na máquina local:

- https://github.com/microsoft/artifacts-credprovider/blob/master/helpers/installcredprovider.ps1 (Windows);
- https://github.com/microsoft/artifacts-credprovider/blob/master/helpers/installcredprovider.sh (Linux/Mac)

3. Localizar *source (src)* do projeto desejado para instalar o NuGet;

4. Executar comando para instalar NuGet privado e seguir instruções;
  > *dotnet add package [NomePacote] -s https://pkgs.dev.azure.com/[NomeOrganizacao]/_packaging/[NomeProjeto]/nuget/v3/index.json --interactive

## CI/CD

* Arquivo de configuração padrão: [azure-pipelines.yml](azure-pipelines.yml).
* Caso há necessidade de incluir mais *tasks* ao pipeline, verfique a documentação para inclusão: [Azure DevOps - Yaml Schema](https://docs.microsoft.com/en-us/azure/devops/pipelines/yaml-schema).

## README

* Incluir documentação padrão no arquivo [README.md](README.md).
* Após inclusão da documentação padrão, **excluir** este arquivo e TODAS as **classes** indentificadas como exemplo.
  + O serviço para busca de endereço **Via CEP** foi utilizado apenas como exemplo. O uso do serviço está disponível no *NuGet* corporativo.
