# Sistema de Controle de Estoque

## 📜 Sobre o Projeto

O objetivo deste sistema é fornecer o controle de estoque, permitindo o cadastro de produtos e o gerenciamento detalhado de seus lotes, incluindo quantidade, data de validade, preço e status.

A API foi construída seguindo as melhores práticas de desenvolvimento, como arquitetura em camadas, injeção de dependência e tratamento de erros.

## ✨ Funcionalidades

-   **Gerenciamento de Produtos:**
    -   CRUD completo para produtos (Nome, Marca, Peso).
    -   Validação para evitar produtos duplicados (mesmo nome, marca e peso).
-   **Gerenciamento de Lotes de Produtos (`ProductInfo`):**
    -   CRUD para informações de lote (Produto associado, quantidade, preço, data de fabricação e validade).
    -   Validação de regras de negócio (ex: data de validade não pode ser anterior a hoje, quantidade deve ser positiva).
    -   Inativação de lotes com registro de justificativa.
    -   Consulta de lotes por produto e por status (Ativo/Inativo).

## 🚀 Tecnologias Utilizadas

-   **Backend:** .NET 8 / ASP.NET Core Web API
-   **ORM:** Entity Framework Core
-   **Mapeamento:** AutoMapper
-   **Banco de Dados:** SQL Server
-   **Arquitetura:** Arquitetura Limpa (Clean Architecture) em camadas.

## 🏗️ Arquitetura

O projeto segue uma **Arquitetura em Camadas** para garantir a separação de responsabilidades, facilitando a manutenção, testabilidade e evolução do sistema.

-   `Domain`: O coração da aplicação. Contém as entidades de negócio (`Product`, `ProductInfo`), DTOs, exceções customizadas e as interfaces dos repositórios e serviços. Não depende de nenhuma outra camada.
-   `Service`: Contém a lógica de negócio e as regras da aplicação. Orquestra as operações e utiliza as abstrações da camada de domínio.
-   `Infrastructure`: Implementa as interfaces definidas no domínio, principalmente os repositórios. É responsável pelo acesso a dados (Entity Framework Core) e outros serviços externos.
-   `API`: A camada de apresentação. Expõe as funcionalidades através de uma API RESTful, lida com requisições HTTP e respostas.

## ⚙️ Pré-requisitos

-   .NET 8 SDK
-   SQL Server
-   Uma IDE ou editor de código (Visual Studio 2022 ou VS Code).

## 🏁 Como Executar o Projeto

Siga os passos abaixo para configurar e executar a aplicação localmente.

**1. Clone o repositório:**

```bash
git clone "https://github.com/carolfranca0310/sistema_estoque.git"
cd <NOME_DA_PASTA_DO_PROJETO>
```

**2. Configure a Conexão com o Banco de Dados:**

-   Abra o arquivo `appsettings.json` que está no projeto da API.
-   Altere a string de conexão `DefaultConnection` para apontar para o seu banco de dados.

Exemplo para SQL Server:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=EstoqueDB;User Id=SEU_USUARIO;Password=SUA_SENHA;TrustServerCertificate=true"
  }
}
```

**3. Restaure as dependências:**

Abra um terminal na raiz do projeto e execute:

```bash
dotnet restore
```

**4. Aplique as Migrations do Entity Framework Core:**

As *migrations* criam e atualizam a estrutura do seu banco de dados com base nas entidades do projeto.

```bash
# Navegue até a pasta do projeto de API
cd src/InventoryManagement.API 

# Execute o comando para aplicar as migrations
dotnet ef database update
```

> **Nota:** Se você não tiver o `dotnet-ef` instalado, instale-o globalmente com o comando:
> `dotnet tool install --global dotnet-ef`

**5. Execute a Aplicação:**

Ainda no terminal, dentro da pasta do projeto de API, execute:

```bash
dotnet run
```

A API estará em execução. Por padrão, você pode acessá-la em `https://localhost:7294` ou `http://localhost:5294`. Abra o navegador em `https://localhost:7294/swagger` para ver a documentação interativa da API e testar os endpoints.
