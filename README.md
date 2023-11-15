# API de Localização do IBGE - Desafio balta.io

Este repositório contém o código-fonte de uma Web API desenvolvida como parte de um desafio criado e proposto pelo <a href="https://www.linkedin.com/in/andrebaltieri/">André Baltieri</a> (<a href="https://balta.io/">balta.io</a>). A API foi construída usando ASP.NET Core 7 e contém funcionalidades de gerenciamento de localizações, além de autenticação e autorização de usuários.

## Conteúdo:

- [Classificação das equipes](#classificação-das-equipes)
- [Funcionalidades da API](#funcionalidades-da-api-gear)
- [Requisitos](#requisitos-books)
- [Configuração](#configuração-arrowforward)
- [Uso](#uso-pencil2)
- [Considerações finais](#considerações-finais-checkeredflag)

<br>

## Classificação das equipes:

A classificação da sua equipe (Júnior, Pleno ou Sênior) é determinada pelo integrante mais experiente. Com base nisso, seu grupo deve seguir as entregas correspondentes:

### Júnior :baby:

- Implementar todas as funcionalidades base
- Usar .NET 7 ou superior
- Arquitetura: MVC ou Minimal APIs com estrutura de projeto simples
- Objetivo: Entregar uma API funcionando

### Pleno :man:

- Implementar todas as funcionalidades base
- Usar .NET 7 ou superior
- Arquitetura: Minimal APIs
- Incluir Testes de Unidade
- Objetivo: Entregar uma API funcionando, com boa arquitetura, organização, código limpo e testes de unidade.

### Sênior :older_man:

- Implementar todas as funcionalidades base
- Usar .NET 7 ou superior
- Arquitetura: Minimal APIs
- Incluir Testes de Unidade
- Implementar Funcionalidades Adicionais
- Objetivo: Entregar uma API funcionando, com boa arquitetura, organização, código limpo, testes de unidade e funcionalidades adicionais.

### Funcionalidades Adicionais (Sênior)

- Importação de Dados: Criar um endpoint para importar os dados a partir deste arquivo Excel: [SQL INSERTS - API de localidades IBGE.xlsx](https://github.com/andrebaltieri/ibge/blob/main/SQL%20INSERTS%20-%20API%20de%20localidades%20IBGE.xlsx).
- A API começará sem dados e os dados serão carregados via um endpoint que permita o upload do Excel.

<br>

## Funcionalidades da API :gear:
A Web API desenvolvida possui as seguintes funcionalidades:

### Autenticação e Autorização :closed_lock_with_key:
- A API implementa um sistema de autenticação com token JWT para proteger as rotas da API. Os usuários podem se autenticar e receber um token JWT para acessar recursos protegidos.

<br>

- Oberservação: Em desenvolvimento.

### Cadastro de E-mail e Senha :e-mail:
- Os usuários podem se cadastrar na aplicação fornecendo um e-mail e senha.

<br>

- Oberservação: Em desenvolvimento.

### Login (Token, JWT) :key:
- Após o cadastro, os usuários podem fazer login para obter um token JWT, que é utilizado para se autenticar nas rotas protegidas da API.

<br>

- Oberservação: Em desenvolvimento.

### CRUD de Localidade :pushpin:
- A API oferece operações CRUD para gerenciar localidades, incluindo a criação, leitura, atualização e exclusão de informações como código IBGE, sigla do estado e nome da cidade.

### Pesquisa por Cidade e por sigla do Estado :round_pushpin:
- Os usuários podem realizar pesquisas de localidades com base no nome da cidade ou da sigla do estado.

### Pesquisa por Código (IBGE) :earth_americas:
- É possível pesquisar localidades com base no código IBGE correspondente.

### Boas práticas da API :ballot_box_with_check:
- A API segue as boas práticas de desenvolvimento de APIs, como tratamento de erros e respostas consistentes.

### Versionamento :hash:
- A API pode incluir versionamento, facilitando futuras atualizações sem quebrar a compatibilidade com as versões anteriores.

### Padronização :warning:
- O código da API segue convenções de nomenclatura e padronização, tornando-o legível e consistente para os desenvolvedores.

### Documentação (Swagger) :green_circle:
- A API é documentada usando o Swagger, facilitando o uso e entendimento por parte dos desenvolvedores.

<br>

## Requisitos :books:

Antes de iniciar o projeto, certifique-se de atender aos seguintes requisitos:

- [Visual Studio](https://visualstudio.microsoft.com/), [Visual Studio Code](https://code.visualstudio.com/) ou [Rider](https://www.jetbrains.com/pt-br/rider/download/)
- [.NET Core SDK](https://dotnet.microsoft.com/download) instalado na sua máquina.
- Um banco de dados compatível com (MySQL) configurado.
- Pacotes e dependências listados no arquivo `.csproj` instalados.

<br>

## Configuração :arrow_forward:
Siga as etapas abaixo para configurar e executar o projeto:

1. Clone este repositório:

   ```sh
   git clone https://github.com/LLR798/DesafioAPI-IBGE.git

2. Acesse a pasta do projeto:
   ```sh
   cd WebApiWithAuth

3. Configure a conexão com o banco de dados no arquivo `appsettings.json`.

4. Execute o seguinte comando para aplicar as migrações e criar o banco de dados:
   ```sh
   dotnet ef database update

5. Inicie o projeto:
   ```sh
   dotnet run

A API estará disponível em `https://localhost:5182`.

<br>

## Uso :pencil2:
A API possui as seguintes rotas:

- `POST /Location/auth/register`: Registra um novo usuário.
- `POST /Location/auth/login`: Autentica um usuário e gera um token de acesso.
- `POST /Location`: Cria uma nova localização (requer autenticação).
- `PUT /Location/{id}`: Atualiza uma localização existente (requer autenticação).
- `DELETE /Location/{id}`: Exclui uma localização existente (requer autenticação).
- `GET /Location`: Obtém todas as localizações cadastradas.
- `GET /Location/{id}`: Obtém uma localização pelo Id.
- `GET /Location/state/{state}`: Obtém localizações pela sigla do estado.
- `GET /Location/city/{city}`: Obtém localizações pela cidade.

*IMPORTANTE: Lembre-se de autenticar-se antes de usar as rotas protegidas.*

## Considerações finais :checkered_flag:

Este repositório contém a API completa desenvolvida como parte do desafio DesafioIBGE. A API oferece funcionalidades básicas e de nível Junior proposto no desafio, seguindo as melhores práticas de desenvolvimento de software.
Divirta-se explorando e utilizando a API! Se tiver alguma dúvida ou sugestão, sinta-se à vontade para entrar em contato com a equipe de desenvolvimento.

Não se esqueça de deixar uma estrelinha no repositório :smiley:

© 2023 [Lucas Lumertz](https://lumertzdeveloper.netlify.app/)