# 👤 Pessoas API

API desenvolvida em **.NET 8** para gerenciamento de pessoas, com **arquitetura MVC**, autenticação com **JWT**, testes automatizados com **xUnit**, e documentação interativa via **Swagger**.

---

## 🚀 Tecnologias Utilizadas

<ul>
  <li><b>.NET 8 (ASP.NET Core Web API)</b></li>
  <li><b>Entity Framework Core</b> (ORM e acesso a dados)</li>
  <li><b>SQLite</b> (banco de dados em desenvolvimento)</li>
  <li><b>xUnit</b> (testes unitários)</li>
  <li><b>Moq</b> (mocks para testes)</li>
  <li><b>Swagger / Swashbuckle</b> (documentação e testes de endpoints)</li>
  <li><b>JWT (JSON Web Token)</b> para autenticação</li>
</ul>

---

## 📐 Arquitetura

A aplicação segue o padrão <b>MVC (Model-View-Controller)</b>:

- **Models** → representam as entidades (ex: `Pessoa`, `User`)  
- **DTOs** → objetos de transferência de dados (`PessoaCreateDtoV1`, `PessoaResponseDtoV1`, etc.)  
- **Controllers** → expõem os endpoints REST  
- **Services** → camada de regras de negócio  
- **Repositories** → camada de acesso a dados (interagindo com EF Core)  

---

## 📘 Documentação da API

A documentação está disponível em:

- **Swagger UI:**  
  <a href="/swagger">/swagger</a>

- **Swagger JSON:**  
  <a href="/swagger/v1/swagger.json">/swagger/v1/swagger.json</a>

---

## 🔑 Autenticação

A API implementa autenticação via <b>JWT (JSON Web Token)</b>.  
- Registro de usuários → <code>POST /api/users/register</code>  
- Login → <code>POST /api/users/login</code>  

Após o login, um **token JWT** é retornado e deve ser enviado no header:  

```http
Authorization: Bearer {token}
```

para acessar endpoints protegidos.

---

## 🧪 Testes Automatizados

Foram implementados **testes unitários com XUnit** garantindo qualidade e cobrindo cenários principais.  
- Meta de cobertura: **80%**  
- Ferramentas auxiliares: **Moq** para mocks, **coverlet** para relatórios de cobertura  

Rodar testes com cobertura:

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutput=./coverage/ /p:CoverletOutputFormat=lcov
```

---

## 📂 Endpoints Disponíveis (v1)

### Pessoas
- **Criar Pessoa**  
  <code>POST /api/v1/pessoas</code>

- **Listar Pessoas**  
  <code>GET /api/v1/pessoas</code>

- **Obter Pessoa por ID**  
  <code>GET /api/v1/pessoas/{id}</code>

- **Buscar por Nome**  
  <code>GET /api/v1/pessoas/nome?nome={nome}</code>

- **Buscar por CPF**  
  <code>GET /api/v1/pessoas/cpf?cpf={cpf}</code>

- **Atualizar Pessoa**  
  <code>PUT /api/v1/pessoas/{id}</code>

- **Excluir Pessoa**  
  <code>DELETE /api/pessoas/{id}</code>

---

### Usuários (Autenticação)
- **Registrar Usuário**  
  <code>POST /api/users/register</code>

- **Login (gera JWT)**  
  <code>POST /api/users/login</code>

---

## 📜 Esquemas (Schemas)

- **PessoaCreateDtoV1** → dados para criação de pessoa  
- **PessoaResponseDtoV1** → resposta com dados da pessoa  
- **PessoaUpdateDtoV1** → atualização de pessoa  
- **UserLoginDto** → dados de login  
- **UserRegisterDto** → dados de registro  

---

## 📦 Deploy

A aplicação pode ser publicada com:

```bash
dotnet publish -c Release -o ./publish
```

E já está rodando em ambiente **Azure App Service**:

👉 <a href="https://pessoasapi-victor.azurewebsites.net/swagger" target="_blank">https://pessoasapi-victor.azurewebsites.net/swagger</a>
