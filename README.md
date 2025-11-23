<img width="1463" height="790" alt="image" src="https://github.com/user-attachments/assets/ba27feea-3006-4f45-9f67-87bd8e8b28fd" />
📦 API Cadastro de ProdutosUma API RESTful simples desenvolvida com ASP.NET Core 9.0 para gerenciamento de um cadastro de produtos, utilizando EF Core com SQLite para persistência de dados e autenticação JWT para controle de acesso.✨ RecursosAPI RESTful: Endpoints para operações CRUD de produtos.Autenticação JWT: Sistema de Login (/Login) para geração de token de acesso.Controle de Acesso: Proteção dos endpoints de produto com [Authorize].Banco de Dados Local: Utiliza SQLite e Entity Framework Core para persistência de dados.Swagger/OpenAPI: Documentação interativa para testar os endpoints.🛠️ Tecnologias UtilizadasEste projeto foi construído utilizando as seguintes tecnologias:Linguagem: C#Framework: ASP.NET Core 9.0Banco de Dados: SQLite (via Entity Framework Core)Autenticação: JWT BearerPacotes Principais (vistos no .csproj e classes):Microsoft.EntityFrameworkCore.SqliteMicrosoft.AspNetCore.Authentication.JwtBearerMicrosoft.AspNetCore.OpenApiSwashbuckle.AspNetCore🚀 Como Executar o ProjetoPré-requisitosCertifique-se de ter o seguinte instalado em sua máquina:.NET 9 SDKUma IDE (Visual Studio, VS Code, Rider, etc.) é recomendada.Passos de Instalação e ExecuçãoClone o repositório:Bashgit clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio/Backend/CadastroProdutos
Restaure as dependências:Bashdotnet restore
Execute as Migrations do EF Core:O banco de dados SQLite (Produtos.db) é criado e as tabelas são configuradas usando as migrações.Bashdotnet ef database update
(O arquivo Produtos.db já está presente, mas este comando garante que o esquema esteja atualizado.)Execute a API:Bashdotnet run
A API estará rodando, por padrão, em http://localhost:5000 ou https://localhost:7000 (verifique launchSettings.json).🔑 Endpoints da APIVocê pode acessar a documentação interativa do Swagger em https://localhost:7000/swagger/index.html (ou a porta HTTP configurada) assim que a aplicação estiver rodando.Autenticação (Login)MétodoEndpointDescriçãoPOST/LoginGera um JWT para um usuário.Corpo da Requisição (Login.cs):JSON{
  "Username": "admin",
  "Password": "password" 
}
A senha e usuário para o exemplo do JWT podem ser fixos ou configurados no LoginController.cs ou appsettings.json.Produtos (Requer Autenticação JWT)MétodoEndpointDescriçãoGET/ProdutosLista todos os produtos.GET/Produtos/{id}Busca um produto por ID.POST/ProdutosCria um novo produto.PUT/Produtos/{id}Atualiza um produto existente.DELETE/Produtos/{id}Remove um produto.Modelo de Produto (Produto.cs):C#public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    // Outros campos...
}
