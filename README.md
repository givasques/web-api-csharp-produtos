# Product API – ASP.NET Core Web API

Uma Web API criada em C# com .NET, utilizando Entity Framework Core, AutoMapper, DTOs e suporte a atualizações parciais com JsonPatch.
O projeto foi desenvolvido com foco em prática, estudo e domínio dos conceitos fundamentais de APIs REST.


## Visão geral

- Model principal: Product

- DTOs: CreateProductDto, ReadProductDto, UpdateProductDto

- Mapeamento: AutoMapper (Profile: ProductProfile)

- Persistência: ProductContext (EF Core, Pomelo MySQL)
  

## Estrutura do projeto
```
  ProdutosApi/
  ├── Controllers/
  │   └── ProductController.cs
  ├── Data/
  │   └── ProductContext.cs
  ├── Dtos/
  │   ├── CreateProductDto.cs
  │   ├── ReadProductDto.cs
  │   └── UpdateProductDto.cs
  ├── Models/
  │   └── Product.cs
  ├── Profiles/
  │   └── ProductProfile.cs
  ├── Program.cs
  ├── appsettings.json
  └── ProductApi.csproj
```

## Endpoints (Controller)

- POST /Product → criar

- GET /Product?skip=0&take=10 → listar (padrão skip/take para paginação)

- GET /Product/{id} → buscar por id

- PUT /Product/{id} → atualizar todos os campos

- PATCH /Product/{id} → atualização parcial (JsonPatch)

- DELETE /Product/{id} → remover
  

## Dependências Utilizadas

- AutoMapper e AutoMapper.Extensions.Microsoft.DependencyInjection

- Microsoft.EntityFrameworkCore

- Microsoft.EntityFrameworkCore.Tools

- Pomelo.EntityFrameworkCore.MySql

- Microsoft.AspNetCore.Mvc.NewtonsoftJson (para JsonPatch)

