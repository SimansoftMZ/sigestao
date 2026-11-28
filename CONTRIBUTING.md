# Contribuir para o siGestão

## Antes de começar

- Para alterações grandes, abra primeiro uma issue e espere pela resposta.
- Leia [AGENTS.md](AGENTS.md) e [docs/guias/convencoes.md](docs/guias/convencoes.md).

## Ambiente

Use o SDK .NET 11 ou o devcontainer em `.devcontainer/`. Comandos:

```bash
dotnet build
dotnet test --no-build --coverlet
dotnet format --verify-no-changes
```

## Fluxo

1. Crie uma branch `<tipo>/<tema>`.
2. Faça commits no formato `tipo(âmbito): descrição`, em português.
3. Abra um pull request. O check «Compilar e testar» tem de estar verde antes do merge.

## Regras

- Lógica nova leva testes.
- O código tem de ser compatível com AOT: sem suprimir avisos `IL2xxx` ou `IL3xxx`.
- O modelo de dados tem de funcionar em todos os SGBD suportados.
- Só se aceitam dependências com licença MIT, Apache-2.0 ou BSD.

## CLA

O CLA é obrigatório para contribuições externas. Leia o [CLA](CLA.md) e assine comentando no pull request a frase indicada nesse ficheiro; o dono do código confirma a assinatura antes do merge. A razão está em [LICENCIAMENTO.md](LICENCIAMENTO.md). Enquanto o CLA estiver em rascunho, não se aceitam contribuições externas de código.

## Decisões de arquitectura

Propõem-se por ADR em [docs/adr/](docs/adr/).
