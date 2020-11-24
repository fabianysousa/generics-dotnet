<h1 align="center"> Tutorial Web Api ASP.NET Core e o MongoDB </h1>

---

## 📑 Sobre

Nesse repositório é colocado em prática e documentando os conceitos básicos da criação de uma API Web do [Tutorial: criar uma API Web com ASP.NET Core e o MongoDB](https://docs.microsoft.com/pt-br/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-3.1&tabs=visual-studio) da **Microsoft**.

### Deverá ser aprendido:

- [X] Configurar o MongoDB.
- [X] Criar um banco de dados do MongoDB.
- [X] Definir uma coleção e um esquema do MongoDB.
- [X] Executar operações CRUD do MongoDB a partir de uma API Web.
- [X] Personalizar a serialização JSON.

---

## 🧠 Conceitos aprendidos

Foi criado um banco de dados do MongoDB utilizando comandos shell, criei uma coleção e inseri dados no banco, além de exibir esses dados no cmd do Mongo.

| Comandos shell Mongo DB | Descrição |
|----------------|-----------|
| ``` mongo ``` | Conecte-se ao banco de dados de testes padrão |
| ``` use BookstoreDb ``` | Criando banco de dados ou abrindo conexão do banco p/ transações |
| ``` db.createCollection('Books') ``` | Criando coleção no banco de dados |
| ``` db.Books.insertMany([{objeto}]) ``` | Inserindo dados no banco de dados|
| ``` db.Books.find({}).pretty() ``` | Exibindo todos os dados no banco de dados |

Documentação dos [Database Commands do MongoDB](https://docs.mongodb.com/manual/reference/command/) .

Após criar o banco de dados do Mongo foi criando o projeto do tipo *aplicativo Web ASP.NET Core* no modelo *API* e logo em seguida adicionado o NuGet *MongoDB. Driver*. O NuGet pode ser instalado tanto pela plataforma *Visual Studio* como pelo cmd. Comando shell: 

``` Install-Package MongoDB.Driver -Version {VERSION} ```.

Em seguida foi criando um diretório Models na raiz do projeto e adicionado uma classe Book ao diretório. Nessa classe é modelado os dados e o comportamento por trás do processo de negócios. No ``` Id ``` é usado para mapear o objeto [Common Language Runtime(CLR)](https://docs.microsoft.com/pt-br/dotnet/standard/clr) para a coleção do MongoDB. 

É necessário configurar o banco de dados e isso é feito no ``` appsettings.json ``` da aplicação. Nesse arquivo é acrescentado informações como o nome da coleção do banco de dados, a conexão e o nome do banco de dados criado. Configuração utlizada na aplicação:

``` 
"BookstoreDatabaseSettings": {
    "BooksCollectionName": "Books",
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "BookstoreDb"
 },
 ```
 
Não podemos esquecer de adicionar a classe ``` BookstoreDatabaseSettings.cs ``` que será utilizada para armazenar o ``` appsettings.json ``` e registrar no contêiner de injeção de dependência ``` Startup.cs ``` a seção do arquivo ``` BookstoreDatabaseSettings ``` do ``` appsettings.json ```.

Posterior a isso é criado um diretório ``` Services ``` na raiz do projeto onde é adicionado a classe ``` BookService ```no diretório. Nessa classe é adicionado um serviço de operações CRUD. Essa classe deve ser adicionada no contêiner de inejão de dependência ``` services.AddSingleton<BookService>() ```. O *Singleton* é um *padrão de projeto* que serve para ara instacionar uma classe para toda uma aplicação.

Logo, é importânte que seja criando um diretório Controller onde deve ser inserido uma classe, no caso da aplicação, ``` BooksController ``` em que deve ser usada para executar operações CRUD utilizando os métodos de ação HTTP ``` GET ```, ``` POST ```, ``` PUT ``` e ``` DELETE ```.

Como proposto, devemos personalizar a serialização JSON. Na aplicação o uso de maiúsculas e minúsculas padrão dos nomes da propriedade deve ser alterado para corresponder ao uso de maiúsculas e minúsculas Pascal dos nomes de propriedade do objeto CLR e a propriedade ``` bookName ``` deve ser retornada como ``` Name ```. Para que essa personalização possa acontecer é necessário adicionar o NuGet ``` NewtonsoftJson ``` e em ``` Startup ``` deve ser encadeado no método AddControllers o código ``` .AddNewtonsoftJson(options => options.UseMemberCasing()); ```. Já no ``` Book.cs ``` é necessário adicionar a propriedade ``` [JsonProperty("Name")] ``` que irá reprensar o nome da propriedade de resposta JSON serializada da API Web.

---

## ⚙️ Tecnologias utilizadas

O projeto foi desenvolvido utilizando as seguintes tecnologias:

 - [MongoDB](https://docs.microsoft.com/pt-br/ef/)
 - [MongoDBCompass](https://www.postman.com/)
 
---

## ☄️ Como baixar o projeto
Pré-requisitos:

[Visual Studio 2019 16.4](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) ou posterior

[.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1) ou  ou posterior

[MongoDB](https://docs.mongodb.com/manual/tutorial/install-mongodb-on-windows/)

No promit command:

```bash

    # Clonar o repositório
    $ git clone https://github.com/fabianysousa/tutorial-web-api-aspnet-core-mongodb


    # Entrar no diretório
    $ cd tutorial-web-api-aspnet-core-mongodb
    
    # Rode o projeto
    $ dotnet run

```
---
## 💡 Insight

Fazer esse tutorial me forneceu o entendimento do funcionamento da aplicação e além de me promover a experiência de utilizar o o MongoDB como Banco de Dados a minha API. Aprender conceitos como CLR, serialização do JSON, Singleton foram novidades para mim. Sinto que estou crescendo cada vez mais no mundo do .NET. 

---

Desenvolvido ❤️ por Fabiany de Sousa Costa
