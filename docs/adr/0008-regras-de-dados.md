# ADR 0008 — Regras de dados

- **Estado:** aceite
- **Data:** 2026-11-27

## Contexto

No V1, o filtro de empresa era feito à mão em cada query, as chaves eram compostas e a numeração usava `MAX + 1`, com condição de corrida.

## Decisão

Multi-empresa por filtro global, chaves `Guid` versão 7, numeração de documentos fiscais por sequência com bloqueio, valores monetários em `decimal` com precisão explícita.

## Alternativas consideradas

- **Chaves naturais compostas:** rejeitadas.
- **Filtro de empresa manual:** rejeitado.

## Consequências

A compatibilidade do filtro global com o modelo compilado depende do resultado do ADR `0003-aot.md`.
