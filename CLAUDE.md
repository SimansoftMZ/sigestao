# CLAUDE.md

@AGENTS.md

## Sobre o projecto

siGestão é um ERP de código aberto da Simansoft. Este repositório é a base: núcleo, módulos, contratos e kit de testes. As distros (como o siGestão Pro) são hosts que consomem os pacotes `Simansoft.SiGestao.*`.

## Comandos

| Acção | Comando |
|---|---|
| Compilar | `dotnet build` |
| Testar | `dotnet test --no-build --coverlet` |
| Verificar formatação | `dotnet format --verify-no-changes` |
| Corrigir formatação | `dotnet format` |

## Arquitectura

- `src/` — projectos de produção. `tests/` — um projecto `*.Tests` por projecto de produção.
- `docs/arquitectura/visao-geral.md` — visão geral.
- `docs/adr/` — decisões. `docs/especificacoes/` e `docs/planos/` — ficheiros com nome `AAAA-MM-DD-<tema>`.

## CI/CD

Os workflows estão em `.github/workflows/`. O check obrigatório é «Compilar e testar» (`ci.yml`).
