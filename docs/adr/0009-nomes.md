# ADR 0009 — Convenções de nomes

- **Estado:** aceite
- **Data:** 2026-11-27

## Contexto

O projecto exige português, mas o código segue as convenções do .NET.

## Decisão

- Conceitos de negócio em português, sem acentos nem cedilhas nos identificadores: `Factura`, `LinhaFactura`, `Fornecedor`.
- Convenções do .NET: PascalCase, prefixo `I` nas interfaces, sufixo `Async`.
- Sufixos e padrões técnicos do framework ficam em inglês: `VendasDbContext`, `FacturaEndpoints`, `AddVendas()`, `*.Tests`.
- Sem prefixos de tipo (`Tb`) nem `_` em nomes de tabelas.
- Raiz dos namespaces e pacotes: `Simansoft.SiGestao`.
- Documentação, comentários, mensagens de commit e de erro em português de Moçambique.
- `docs/guias/glossario.md` fixa o termo de cada conceito, para não haver sinónimos no código.

## Alternativas consideradas

- **Tudo em inglês:** afasta o código da linguagem do negócio.
- **Tudo em português:** colide com os padrões do framework.

## Consequências

O [glossário](../guias/glossario.md) é a fonte de verdade dos termos. As regras de pormenor estão em [convenções](../guias/convencoes.md).
