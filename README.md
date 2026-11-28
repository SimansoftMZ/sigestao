# siGestão

Plataforma ERP de código aberto, moderna, desenvolvida pela Simansoft em .NET.

## Estado

Em fundação; ainda sem funcionalidades.

## Objectivos

- Gestão Comercial
- CRM
- Compras
- Inventário
- Contabilidade
- Arquitectura modular
- Multiempresa
- Integrações empresariais

## Começar

Requer o SDK .NET 11 ou o devcontainer em `.devcontainer/`.

```bash
dotnet build
dotnet test --no-build --coverlet
dotnet format --verify-no-changes
```

## Documentação

- [Visão geral da arquitectura](docs/arquitectura/visao-geral.md)
- [Decisões de arquitectura (ADR)](docs/adr/)
- [Guias](docs/guias/)

## Licença

O siGestão é distribuído sob a AGPL-3.0, com licença comercial disponível para quem quer comercializá-lo sem publicar o seu código. Ver [LICENCIAMENTO.md](LICENCIAMENTO.md).

## Contribuir

Ver [CONTRIBUTING.md](CONTRIBUTING.md).
