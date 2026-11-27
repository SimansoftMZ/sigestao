# ADR 0006 — Pacotes NuGet entre repositórios

- **Estado:** aceite
- **Data:** 2026-11-27

## Contexto

Existem dois repositórios e prevêem-se várias distros que têm de reutilizar a base.

## Decisão

A base publica pacotes NuGet `Simansoft.SiGestao.*` com SemVer. As distros (incluindo o `sigestao-pro`) consomem os pacotes; não há fork nem submódulo.

## Alternativas consideradas

- **Fork:** diverge da base.
- **Submódulo git:** traz atrito e acoplamento ao código-fonte.

## Consequências

- A base tem de manter SemVer e pontos de extensão explícitos.
- A primeira publicação no nuget.org é decisão do responsável do projecto.
