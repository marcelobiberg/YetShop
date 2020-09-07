Yet Shop E-commerce didático 
===================================================

A base deste proejto foi desenvolvida com bae no projeto desenvolvido pela Microsoft, demonstrando uma arquitetura de aplicativo de processo único 
(monolítico) e um modelo de implantação. ( [Guia para iniciante](https://github.com/dotnet-architecture/eShopOnWeb/wiki/Getting-Started-for-Beginners) )

Este e-book foi utilizado no proejto como material de apoio. [ Architecting Modern Web Applications with ASP.NET Core and Azure](https://dotnet.microsoft.com/download/e-book/aspnet/pdf)

Este projeto foi desenvolvido com os princípios de 'Clean Code' & 'Clean Architecture', segue algumas das referências na nossa [wiki](https://github.com/marcelobiberg/YetShop/wiki). 

###Adicionar migrations e atualizar o banco de dados

1. No projeto yet.Infrasctructure via Powershell executar os seguintes comandos:

## Migrations

Adicionar "migration" para o banco de catálago de produtos
```
add-migration CatalogoIncial -Context CatalogoContext -o 'Caminho para Data/Migrations'
```
Adicionar "migration" para o banco de autenticação ( Identity )
```
add-migration IdentityIncial -Context AppIdentityDbContext -o 'Caminho para Identity/Migrations'
```

## Update-database

Cria o banco de dados do catálago baseado na 'Migration' criada acima
```
update-database CatalogoIncial
```
Cria o banco de dados de autenticação
```
update-database IdentityIncial
```

## Tecnologias
* ASP.NET Core 3.1.2
* EF Core 3.1.2
* Identity Core 3.1.2
* BuildBundlerMinifier 3.2.435
* SQL Server
* Bootstrap 3.2.435
* Jquery 3.3.1

## Acesso ao projeto

Segue URL para acessar o projeto em desenvolvimento . . .

## Reportar Bugs

Para relatar Bugs usar o sistemas de [Issues](https://github.com/marcelobiberg/YetShop/issues)
