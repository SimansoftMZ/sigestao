# ADR 0007 — Migrações na distro

- **Estado:** aceite
- **Data:** 2026-11-27

## Contexto

Há vários SGBD e várias distros, com conjuntos de módulos diferentes.

## Decisão

Cada módulo contribui com a configuração do seu modelo. As migrações vivem na distro, um projecto por provedor. A base inclui uma distro de referência, **Comunidade**, usada no CI e em demonstrações.

## Alternativas consideradas

- **Migrações dentro de cada módulo:** rejeitada; multiplica módulos por provedores.
- **Um único conjunto de migrações para todos os SGBD:** rejeitada; o SQL gerado difere entre provedores.

## Consequências

Cada distro gera as suas migrações ao actualizar a base. A distro Comunidade serve de referência e é o que o CI testa.

## Evidência

Mesmo teste exploratório do ADR 0004 (EF Core 11.0.0, Npgsql 11.0.0, SqlServer 11.0.0, `dotnet-ef` 11.0.0, SDK 11.0.100). Estrutura: `Modelo` (entidade e `DbContext`), `Migracoes.PostgreSql` e `Migracoes.SqlServer` (cada um refere `Modelo` e um só provedor) e `Host` (fábrica de tempo de desenho que escolhe o provedor pelo primeiro argumento e define `MigrationsAssembly`).

Os comandos do passo 4 funcionaram tal como estão, sem ajustes, incluindo a passagem de `-- PostgreSql` e `-- SqlServer` à fábrica:

```
dotnet ef migrations add Inicial --startup-project Host --project Migracoes.PostgreSql -- PostgreSql
dotnet ef migrations add Inicial --startup-project Host --project Migracoes.SqlServer -- SqlServer
```

Ambos terminaram com «Build succeeded.» e «Done.», sem erros nem avisos. Cada projecto ficou com a sua pasta `Migrations` (`*_Inicial.cs`, `*_Inicial.Designer.cs` e `ProvaDbContextModelSnapshot.cs`). O `Host` não precisou de referências adicionais.

Também funcionaram `dotnet ef migrations script` nos dois provedores (sem base de dados) e `dotnet ef database update` no PostgreSQL. O SQL gerado difere entre provedores (tipos, aspas, bloco de criação do histórico, `GO` só no SQL Server), o que confirma a rejeição de um conjunto único de migrações. O `database update` do projecto `Migracoes.SqlServer` aplicou-se no Azure SQL Edge (ARM64). No SQL Server 2022 não foi verificado: o contentor não arrancou em ARM64 por emulação (ver ADR 0004).

Fora do que o teste cobriu: migrações com vários módulos a contribuir para o mesmo modelo, e a actualização de uma base já existente. Não foram exercitadas.
