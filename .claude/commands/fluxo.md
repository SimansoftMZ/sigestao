---
description: Leva um pedido do plano à documentação, com os agentes do projecto.
argument-hint: <descrição do pedido>
---

Executa o fluxo de `AGENTS.md` para: $ARGUMENTS

1. **Planear.** Chama `planejador` com o pedido. Mostra o resumo e **pára até o humano aprovar o plano**.
2. **Testes.** Chama `testador` (fase 1) com o caminho do plano. Commit `wip(<tema>): testes`.
3. **Código.** Chama `codificador` com o caminho do plano. Commit `wip(<tema>): código`.
4. **Suites.** Chama `testador` (fase 2). Se falhar, volta ao passo 3.
5. **Diff.** Grava `git diff main...HEAD` e a lista de ficheiros na pasta temporária da sessão.
6. **Revisão de dados.** Se o diff toca em `DbContext`, configurações de entidades ou migrações, chama `guardiao-dados` com o caminho do diff.
7. **Revisão.** Chama `revisor-pr` com o caminho do diff.
8. Achados N1 ou N2 voltam ao passo 3. No máximo dois ciclos; ao terceiro, pára e pergunta ao humano.
9. **Documentação.** Se o plano o indicar, chama `documentador`. Commit `wip(<tema>): documentação`.
10. Resume ao humano: o que mudou, resultado das suites, achados N3 para issue.
