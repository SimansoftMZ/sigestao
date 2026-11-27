# ADR 0011 — Interface e consumidores

- **Estado:** aceite
- **Data:** 2026-11-27

## Contexto

Estão previstas implementações em MAUI e, possivelmente, em ASP.NET e Blazor.

## Decisão

A base é API-first e não assume linguagem nem framework de interface. Estão previstas implementações em MAUI e, possivelmente, em ASP.NET e Blazor; a escolha faz-se em especificação própria. Os pacotes visam apenas .NET moderno (`net11.0`).

A base pode ser usada a partir de qualquer linguagem .NET (C#, F#, VB) e de qualquer framework de interface. Regras:

- contratos e cliente HTTP ficam em pacotes sem dependências de interface;
- a API pública dos pacotes segue as regras CLS;
- a API HTTP publica OpenAPI, que serve também consumidores fora do .NET;
- os pacotes visam só `net11.0`; não há suporte para .NET Framework.

## Alternativas consideradas

- **Escolher já uma tecnologia de interface:** rejeitado; a escolha faz-se em especificação própria.
- **Suportar .NET Framework com `netstandard2.0`:** rejeitado; o responsável decidiu suportar só .NET moderno, e `netstandard2.0` impediria o uso das API e dos analisadores de AOT actuais.

## Consequências

- A API pública segue as regras CLS.
- O OpenAPI é publicado.
- Não há suporte para .NET Framework.
