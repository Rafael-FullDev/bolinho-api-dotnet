# Bolinho API (.NET)

API REST desenvolvida com **C#**, **ASP.NET Core**, **Entity Framework Core** e **SQL Server LocalDB** para gerenciamento de bolinhos.

Este projeto foi criado com foco em aprendizado de desenvolvimento backend, boas práticas, organização em camadas e integração com banco de dados.

---

## Sobre o projeto

A Bolinho API permite cadastrar, listar, buscar, atualizar, deletar e filtrar bolinhos.

A aplicação foi construída utilizando uma arquitetura simples e organizada, separando responsabilidades entre:

- Controller
- Service
- Repository
- Mapper
- DTOs
- Model
- DbContext

---

## Funcionalidades

- Criar bolinhos
- Listar bolinhos
- Buscar bolinho por ID
- Atualizar bolinho
- Deletar bolinho
- Filtrar bolinhos por nome
- Filtrar bolinhos por status
- Categorizar bolinhos
- Armazenar URL de imagem
- Retornar respostas padronizadas com `ApiResponse`

---

## Tecnologias utilizadas

- C#
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server LocalDB
- Swagger / OpenAPI
- LINQ
- Git e GitHub

---

## Arquitetura do projeto

```txt
Controllers/
    BolinhoController.cs

DTOs/
    BolinhoCreateDto.cs
    BolinhoUpdateDto.cs
    BolinhoResponseDto.cs
    BolinhoFiltroDto.cs

Data/
    AppDbContext.cs

Mappings/
    BolinhoMapper.cs

Migrations/
    Arquivos gerados pelo Entity Framework

Models/
    Bolinho.cs

Repository/
    IBolinhoRepository.cs
    BolinhoRepository.cs

Responses/
    ApiResponse.cs

Services/
    IBolinhoService.cs
    BolinhoService.cs

Program.cs
appsettings.json
```

---

## Fluxo da aplicação

```txt
Cliente / Swagger / Front-end
        ↓
Controller
        ↓
Service
        ↓
Repository
        ↓
AppDbContext
        ↓
SQL Server LocalDB
```

---

## Principais conceitos aplicados

### Controller

Responsável por receber as requisições HTTP e retornar as respostas da API.

### Service

Responsável pela regra de negócio e por coordenar as ações da aplicação.

### Repository

Responsável pelo acesso aos dados usando Entity Framework Core.

### DTOs

Responsáveis por controlar quais dados entram e saem da API.

### Mapper

Responsável por converter objetos entre DTOs e Models.

### ApiResponse

Classe usada para padronizar as respostas da API.

Exemplo de resposta:

```json
{
  "sucesso": true,
  "mensagem": "Bolinho criado com sucesso.",
  "dados": {},
  "erros": null
}
```

---

## Banco de dados

O projeto utiliza **SQL Server LocalDB** com Entity Framework Core.

A connection string fica em:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=BolinhoDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

## Como executar o projeto

### 1. Clonar o repositório

```bash
git clone https://github.com/Rafael-FullDev/bolinho-api-dotnet.git
```

### 2. Acessar a pasta do projeto

```bash
cd bolinho-api-dotnet
```

### 3. Restaurar os pacotes

```bash
dotnet restore
```

### 4. Aplicar as migrations no banco

```bash
dotnet ef database update
```

### 5. Rodar o projeto

```bash
dotnet run
```

### 6. Acessar o Swagger

```txt
https://localhost:xxxx/swagger
```

A porta pode variar de acordo com a configuração local do projeto.

---

## Endpoints principais

| Método | Rota           | Descrição                 |
| ------ | -------------- | ------------------------- |
| GET    | /bolinhos      | Lista todos os bolinhos   |
| GET    | /bolinhos/{id} | Busca um bolinho por ID   |
| POST   | /bolinhos      | Cria um novo bolinho      |
| PUT    | /bolinhos/{id} | Atualiza um bolinho       |
| DELETE | /bolinhos/{id} | Deleta um bolinho         |

---

## Filtros disponíveis

A listagem de bolinhos permite filtros via query string.

Exemplos:

```txt
GET /bolinhos?nome=chocolate
GET /bolinhos?pronto=true
GET /bolinhos?nome=ninho&pronto=true
```

---

## Exemplo de criação de bolinho

### Requisição

```json
{
  "nome": "Bolinho de Chocolate",
  "descricao": "Bolinho caseiro com cobertura de chocolate",
  "pronto": true,
  "categoria": "Chocolate",
  "imagemUrl": "https://exemplo.com/bolinho-chocolate.jpg"
}
```

### Resposta

```json
{
  "sucesso": true,
  "mensagem": "Bolinho criado com sucesso.",
  "dados": {
    "id": 1,
    "nome": "Bolinho de Chocolate",
    "descricao": "Bolinho caseiro com cobertura de chocolate",
    "pronto": true,
    "categoria": "Chocolate",
    "imagemUrl": "https://exemplo.com/bolinho-chocolate.jpg"
  },
  "erros": null
}
```

---

## Validações

O projeto utiliza Data Annotations nos DTOs para validar os dados recebidos.

Exemplos de validações:

- Nome obrigatório
- Nome com limite de caracteres
- Descrição obrigatória
- Categoria obrigatória
- URL da imagem com limite de caracteres

---

## Comandos úteis

### Criar uma migration

```bash
dotnet ef migrations add NomeDaMigration
```

### Aplicar migration no banco

```bash
dotnet ef database update
```

### Rodar build do projeto

```bash
dotnet build
```

### Rodar a aplicação

```bash
dotnet run
```

---

## Status do projeto

Projeto em desenvolvimento.

Funcionalidades já implementadas:

- CRUD completo
- Banco de dados com Entity Framework
- DTOs
- Service
- Repository
- Mapper
- ApiResponse
- Filtros
- Categoria
- ImagemUrl

---

## Próximos passos

- Conectar a API com um front-end
- Criar uma interface com Bootstrap ou React
- Criar painel administrativo
- Implementar autenticação com JWT
- Melhorar tratamento global de erros
- Adicionar paginação
- Criar testes unitários

---

## Autor

Desenvolvido por Rafael Ferreira Rodrigues.

[LinkedIn](https://www.linkedin.com/in/rafael-full-dev/)
