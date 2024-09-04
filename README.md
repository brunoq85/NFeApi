
# NFe Management API

Este repositório contém uma API desenvolvida em ASP.NET Core, utilizando várias tecnologias e padrões de projeto para gerenciar Notas Fiscais Eletrônicas (NFe). A API inclui funcionalidades como criação, leitura, atualização e exclusão (CRUD) de NFes, emitentes e itens.

## 🛠️ Tecnologias Utilizadas

- **ASP.NET Core Web API**: Framework para construir APIs RESTful com C#.
- **Entity Framework Core**: ORM para acesso e manipulação de dados no banco de dados SQLite.
- **SQLite**: Banco de dados leve utilizado para persistência de dados.
- **AutoMapper**: Biblioteca para mapeamento de objetos, facilitando a conversão entre classes de negócio e DTOs.
- **Swagger (Swashbuckle)**: Ferramenta para documentação da API, permitindo visualização e teste dos endpoints.
- **C#**: Linguagem de programação utilizada para desenvolvimento da API.

## 📦 Estrutura do Projeto

O projeto está organizado em camadas para facilitar a manutenção e a escalabilidade:

- **Camada de Apresentação**: Contém os controladores (controllers) que expõem os endpoints da API.
- **Camada de Aplicação**: Contém os DTOs (Data Transfer Objects) e o mapeamento utilizando AutoMapper.
- **Camada de Negócio**: Contém as classes de domínio que representam as entidades de negócio, como `NFe`, `Emitente` e `Item`.
- **Camada de Acesso a Dados**: Contém o contexto do Entity Framework Core e as classes de configuração das entidades (mapeamento).

## 🚀 Como Executar o Projeto

1. Clone o repositório:

   ```bash
   git clone https://github.com/brunoq85/NFeApi.git
   cd nfe-management-api
   ```

2. Instale as dependências do projeto:

   ```bash
   dotnet restore
   ```

3. Execute as migrações para criar o banco de dados:

   ```bash
   dotnet ef database update
   ```

4. Execute a aplicação:

   ```bash
   dotnet run
   ```

## 📚 Endpoints Disponíveis

- **/api/nfes**: Endpoints para gerenciar NFes.
- **/api/emitentes**: Endpoints para gerenciar emitentes.
- **/api/itens**: Endpoints para gerenciar itens.

## 📝 Mapeamento com AutoMapper

O AutoMapper foi configurado para mapear as seguintes classes de negócio para seus respectivos DTOs:

- `NFe` ⇄ `NFeDTO`
- `Emitente` ⇄ `EmitenteDTO`
- `Item` ⇄ `ItemDTO`

## 🌐 Documentação

A documentação da API é gerada automaticamente com o Swagger. Acesse `/swagger` para ver a documentação e testar os endpoints diretamente no navegador.

## 🔧 Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.

## 📄 Licença

Este projeto está licenciado sob a licença MIT. Consulte o arquivo `LICENSE` para obter mais informações.
