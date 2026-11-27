# Convenções de nomes

- Conceitos de negócio em português, sem acentos nem cedilhas nos identificadores: `Factura`, `LinhaFactura`, `Fornecedor`.
- Convenções do .NET: PascalCase, prefixo `I` nas interfaces, sufixo `Async`.
- Sufixos e padrões técnicos do framework ficam em inglês: `VendasDbContext`, `FacturaEndpoints`, `AddVendas()`, `*.Tests`.
- Sem prefixos de tipo (`Tb`) nem `_` em nomes de tabelas.
- Raiz dos namespaces e pacotes: `Simansoft.SiGestao`.
- Documentação, comentários, mensagens de commit e de erro em português de Moçambique.
- O [glossário](glossario.md) fixa o termo de cada conceito, para não haver sinónimos no código.

## Exemplos

| Certo | Errado | Porquê |
|---|---|---|
| `Factura` | `TbFactura`, `Invoice` | Sem prefixo de tipo; negócio em português |
| `LinhaFactura` | `Factura_Linha` | Sem `_` |
| `Armazem` | `Armazém` | Sem acentos em identificadores |
| `VendasDbContext` | `ContextoBdVendas` | Sufixo do framework em inglês |
| `AddVendas()` | `AdicionarVendas()` | Padrão do framework |
| `ObterFacturaAsync` | `ObterFactura` (assíncrono) | Sufixo `Async` |
