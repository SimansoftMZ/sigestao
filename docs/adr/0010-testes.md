# ADR 0010 — Testes

- **Estado:** aceite
- **Data:** 2026-11-27

## Contexto

O V1 não tinha testes, e os testes têm de correr na nuvem sem instalações. A cobertura usa o pacote `coverlet.MTP` (licença MIT) e os testes correm com `dotnet test --no-build --coverlet`.

## Decisão

- **Unitários:** xUnit v3, sem infra-estrutura.
- **Integração:** Testcontainers, com SGBD real em Docker; correm iguais no computador do programador, no Codespaces e no GitHub Actions. Não se usa SQLite nem provedor em memória como substituto.
- **Dados fictícios:** gerador com semente fixa e dados moçambicanos (NUIT, províncias, nomes), num projecto de kit de testes reutilizável pelas distros e por ambientes de demonstração. Entra na Fase 1.
- **Sem instalação:** `.devcontainer` com SDK .NET 11 e Docker; abrir no Codespaces basta para compilar e testar.

O [guia de testes](../guias/testes.md) descreve a estratégia e como correr cada tipo.

## Alternativas consideradas

- **SQLite ou provedor em memória:** não detectam diferenças entre SGBD.
- **VSTest:** o xUnit v3 4.x usa Microsoft.Testing.Platform.

## Consequências

- Os testes de integração exigem Docker.
- O `global.json` fixa o executor de testes.
