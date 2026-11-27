# ADR 0007 — Migrações na distro

- **Estado:** proposto
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

Pendente do teste exploratório descrito na Tarefa 9 do plano da fundação. Este ADR passa a `aceite` quando a evidência for registada aqui.
