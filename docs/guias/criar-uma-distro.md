# Criar uma distro

## O que é uma distro

Uma distro é um host que referencia os pacotes `Simansoft.SiGestao.*` e acrescenta módulos próprios. O `sigestao-pro` é feito assim, e qualquer outro implementador pode fazer o mesmo. A arquitectura está em [visão geral](../arquitectura/visao-geral.md).

## Licença

A distro fica sob AGPL-3.0, salvo acordo de parceiro com a Simansoft. Ver [LICENCIAMENTO.md](../../LICENCIAMENTO.md).

## Passos

1. Escolher os módulos a incluir.
2. Escolher o SGBD (ver [ADR 0004](../adr/0004-sgbd.md)).
3. Gerar as migrações no projecto do provedor, na distro (ver [ADR 0007](../adr/0007-migracoes.md)).

> **Nota:** os comandos concretos são acrescentados quando existir a distro Comunidade (Fase 1).
