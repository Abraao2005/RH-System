# RH-System

Sistema de Gestão de Funcionários, Férias e Relatórios desenvolvido com C# (.NET), Angular e SQL Server.

---

## 🧑‍💻 Tecnologias Utilizadas

- **.NET 8.0** (ASP.NET Core Web API)
- **Angular 16+**
- **SQL Server**
- **Entity Framework Core**
- **Bootstrap 5** (para estilização do frontend)

---

## ✅ Pré-Requisitos

Antes de rodar o projeto, certifique-se de ter instalado em sua máquina:

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download)
- [Node.js (v20+ recomendado)](https://nodejs.org/)
- [Angular CLI (v16+ recomendado)](https://angular.io/cli)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/) ou VS Code
- [Git](https://git-scm.com/)

---

## 🚀 Como Rodar o Projeto Localmente

### Backend (.NET API)

1. Clone o repositório:

   ```bash
   git clone https://github.com/Abraao2005/RH-System.git
   cd RH-System/backend


2. Configure a string de conexão no arquivo appsettings.json para conectar ao seu SQL Server:
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=RHSystemDB;User Id=SEU_USUARIO;Password=SUA_SENHA;TrustServerCertificate=True;"
}


3. Abra um terminal na pasta backend e rode as migrations para criar o banco e tabelas:

dotnet ef database update

4. Execute a API:
dotnet run

5. A api estara disponivel em:
http://localhost:7081/swagger/index.html


Frontend (Angular)

1. Abra um terminal na pasta frontend (ou onde estiver o código Angular):
cd RH-System/Rh.Angular

2. Instale as dependências do projeto:

npm install

3. Inicie o servidor de desenvolvimento Angular:
ng serve

4. Acesse o frontend no navegador:

http://localhost:4200


Banco de Dados
Utilizamos SQL Server como banco de dados.

O banco será criado automaticamente usando o Entity Framework Core com as migrations do projeto.

Caso prefira, os scripts SQL para criação manual das tabelas podem ser encontrados na pasta /sql (caso esteja disponível).

Certifique-se de que o SQL Server está rodando e que o usuário informado na string de conexão tem permissões para criar banco e tabelas.


Funcionalidades
Tela Principal: lista todos os funcionários cadastrados.

Tela Funcionários: cadastro, edição, visualização detalhada e desligamento de funcionários.

Tela Férias: listagem, cadastro, edição e exclusão de férias vinculadas aos funcionários.

Tela Relatório: gera e exibe relatório PDF dos funcionários.


⚠️ Observação Importante
Devido ao tempo limitado, o front-end em Angular não foi totalmente implementado, ficando apenas a funcionalidade de listagem dos funcionários.
A API em C# .NET está completa e funcional, atendendo a todos os requisitos especificados.


👤 Autor
Abraão Oliveira
GitHub: https://github.com/Abraao2005
Email: abraao20001@gmail.com

Contato
Caso tenha dúvidas ou queira colaborar, sinta-se à vontade para abrir uma issue no repositório ou me contatar diretamente pelo GitHub.