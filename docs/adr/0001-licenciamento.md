# ADR 0001 — Licenciamento

- **Estado:** aceite
- **Data:** 2026-11-27

## Contexto

O siGestão é código aberto, mas quem o comercializa deve partilhar receitas com a Simansoft.

## Decisão

Licenciamento duplo: **AGPL-3.0** para todos, e **licença comercial** com partilha de receitas para quem quer comercializar sem abrir o seu código ou usar a marca siGestão. Contribuições externas exigem **CLA** assinado, para a Simansoft poder licenciar o código comercialmente. Só entram dependências com licença permissiva (MIT, Apache-2.0, BSD).

O modelo comercial resume-se assim:

- **AGPL-3.0** para todos: uso, modificação e distribuição livres, com a obrigação de publicar o código de qualquer versão distribuída ou servida em rede.
- **Licença comercial** (acordo de parceiro com partilha de receitas) para quem quer comercializar sem publicar o seu código.
- **Marca:** só parceiros podem comercializar com o nome e o logótipo siGestão.
- **Limite aceite:** quem cumprir a AGPL por inteiro e não usar a marca pode comercializar sem acordo.

`LICENCIAMENTO.md` explica este modelo em linguagem simples. O texto do acordo de parceiro, do CLA e o registo da marca são tratados fora do repositório, com apoio jurídico.

## Alternativas consideradas

- **MPL-2.0 e Apache-2.0:** não dão alavanca comercial.
- **Licença de código disponível:** deixa de ser open source.

## Consequências

- O CLA é obrigatório para contribuições externas.
- Quem cumprir a AGPL e não usar a marca pode vender sem acordo.
- A marca tem de ser registada.
- Os textos legais têm de ser validados por jurista.
