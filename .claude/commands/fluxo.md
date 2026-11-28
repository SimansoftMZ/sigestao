---
description: Leva um pedido do plano à documentação, com os agentes do projecto.
argument-hint: <descrição do pedido>
---

Executa o fluxo de `AGENTS.md` para: $ARGUMENTS

1. **Planear.** Chama `planejador` com o pedido. Mostra o resumo e **pára até o humano aprovar o plano**. Depois da aprovação, commit `wip(<tema>): plano`.
2. **Testes.** Chama `testador` (fase 1) com o caminho do plano. Commit `wip(<tema>): testes`.
3. **Código.** Chama `codificador` com o caminho do plano. Se o `codificador` contestar um teste, pára e pergunta ao humano. Commit `wip(<tema>): código`.
4. **Suites.** Chama `testador` (fase 2). Se falhar, volta ao passo 3.
5. **Diff.** Corre `git fetch origin` e grava `git diff origin/main...HEAD` e a lista de ficheiros na pasta temporária da sessão. Não uses a `main` local: pode estar desactualizada.
6. **Revisão de dados.** Se o diff toca em `DbContext`, configurações de entidades ou migrações, chama `guardiao-dados` com o caminho do diff.
7. **Revisão.** Chama `revisor-pr` com o caminho do diff.
8. Achados do `guardiao-dados` e achados N1 ou N2 do `revisor-pr` voltam ao passo 3.
9. **Documentação.** Se o plano o indicar, chama `documentador`. Commit `wip(<tema>): documentação`.
10. Resume ao humano: o que mudou, resultado das suites, achados N3 para issue.

Regras:
- `<tema>` é o tema do nome do ficheiro do plano (`AAAA-MM-DD-<tema>.md`).
- Os commits são feitos por ti, não pelos agentes.
- No máximo dois regressos ao passo 3 no total, a partir do passo 4 ou do passo 8; ao terceiro, pára e pergunta ao humano.
