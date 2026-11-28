# Testes

## Tipos de teste

- **Unitários:** xUnit v3, sem infra-estrutura.
- **Integração:** Testcontainers, com SGBD real em Docker. Entram na Fase 1.

Não se usa SQLite nem provedor em memória como substituto do SGBD. A escolha de SGBD está em [ADR 0004](../adr/0004-sgbd.md).

Em máquinas ARM64 a imagem do SQL Server não arranca em Docker. Aí, os testes de integração correm localmente sobre PostgreSQL e, em substituição do SQL Server, sobre o Azure SQL Edge (`mcr.microsoft.com/azure-sql-edge`); o SQL Server verifica-se no CI.

## Como correr

| Acção | Comando |
|---|---|
| Compilar | `dotnet build` |
| Testar | `dotnet test --no-build --coverlet` |
| Verificar formatação | `dotnet format --verify-no-changes` |

## Nomes

Os testes chamam-se `Metodo_Cenario_Resultado`. Cada teste verifica um só comportamento.

## Dados fictícios

Um gerador com semente fixa e dados moçambicanos (NUIT, províncias, nomes), num kit de testes reutilizável pelas distros e por ambientes de demonstração. Entra na Fase 1.

## Sem instalar nada

Abra o repositório no Codespaces ou num devcontainer: o ambiente já traz o que é preciso para compilar e testar.

## Cobertura

O comando abaixo escreve o relatório em `TestResults/`:

```
dotnet test --no-build --coverlet --coverlet-output-format cobertura
```
