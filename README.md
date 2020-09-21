===================================================
=       Yet-Shop ( E-commerce didático )          =
===================================================

### Visão geral
Este projeto foi desenvolvido com os princípios de 'Clean Code' & 'Clean Architecture', segue algumas das referências na nossa [wiki](https://github.com/marcelobiberg/YetShop/wiki). 

Este projeto consiste em dois banco de dados
* Catálogo de produtos
* Autenticação ( Microsoft Identity )


### API-DDD
A base do proejto ( API-DDD ) foi desenvolvida com a base no projeto  modelo da Microsoft eShopOnWeb. Abaixo um guia inicial do projeto
( [Guia para iniciante](https://github.com/dotnet-architecture/eShopOnWeb/wiki/Getting-Started-for-Beginners) ).
Toda a regra de negócio fica do lado da API.

![image](https://user-images.githubusercontent.com/13973962/93723506-6146d980-fb75-11ea-96f9-5789424f1788.png)

### UI-MVC
Desenvolvida  a interface do usuário ( UI-MVC ) em ASP.NET Core 3.1 MVC para consumir a API-DDD, as chamadas são realizadas através do [Refit](https://github.com/marcelobiberg/YetShop/wiki/Refit-(-httpClient-de-maneira-simples-e-pr%C3%A1tica-)) 



### Adicionar migrations e atualizar o banco de dados

1. No projeto yet.Infrasctructure via Powershell executar os seguintes comandos:

## Migrations

Adicionar "migration" para o banco de catálago de produtos
```
add-migration CatalogoIncial -Context CatalogoContexto -o 'Copie o caminho completo do diretório Data/Migrations'
```
Adicionar "migration" para o banco de autenticação ( Identity )
```
add-migration IdentityIncial -Context AppIdentityDbContext -o 'Copie o caminho completo do diretório Identity/Migrations'
```

## Update-database

Cria o banco de dados do catálago baseado na 'Migration' criada acima
```
update-database -Context CatalogoContexto
```
Cria o banco de dados de autenticação
```
update-database -Context AutenticacaoContexto
```

## Tecnologias
### API
* ASP.NET Core 3.1.2
* EF Core 3.1.2
* Identity Core 3.1.2
* Ardalis.ApiEndpoints 2.0.0
* AutoMapper 10.0.0
* AutoMapper.Extensions.Microsoft.DependencyInjection 8.0.1
* Microsoft.AspNetCore.Authentication.JwtBearer 3.1.7
* Microsoft.EntityFrameworkCore.Design 3.1.7
* Swashbuckle.AspNetCore 5.5.1
* Swashbuckle.AspNetCore.Annotations 5.5.1
* Microsoft SQL Server Express (64-bit)

### Asp.NetCore MVC
* BuildBundlerMinifier 3.2.449
* Bootstrap 4.3.1 
* Jquery 3.5.1
* Refit 5.2.1


## Acesso ao projeto

Segue URL para acessar o projeto em desenvolvimento . . .
