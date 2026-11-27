# ADR 0002 — Plataforma

- **Estado:** aceite
- **Data:** 2026-11-27

## Contexto

O projecto é novo e não tem código legado que condicione a escolha da plataforma.

## Decisão

.NET 11 e C# 15 em todos os projectos. O .NET 11 é STS (suporte até Novembro de 2028); planear a subida para o .NET 12 LTS quando sair.

## Alternativas consideradas

- **.NET 10 LTS:** termina na mesma data (Novembro de 2028) e tem menos funcionalidades.

## Consequências

Há que subir para o .NET 12 LTS quando sair, antes do fim do suporte do .NET 11 em Novembro de 2028.
