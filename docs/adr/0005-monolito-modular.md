# ADR 0005 — Monólito modular

- **Estado:** aceite
- **Data:** 2026-11-27

## Contexto

O V1 tinha 250 tabelas num só `DbContext` e controllers de 3500 linhas.

## Decisão

Monólito modular: um módulo por área de negócio, com contratos públicos explícitos. Os módulos são compostos em tempo de compilação pelo projecto host.

## Alternativas consideradas

- **Microserviços:** custo operacional sem necessidade.
- **Plugins carregados em tempo de execução:** incompatíveis com Native AOT.

## Consequências

- Não há Marketplace dinâmico.
- As fronteiras entre módulos são impostas por referências de projecto.
