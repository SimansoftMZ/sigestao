# AGENTS.md — siGestão

Regras para qualquer assistente de IA que trabalhe neste repositório.

## Idioma

Toda a documentação, comentários, mensagens de commit e de erro são em **português de Moçambique**.

## Regras comuns

- **Alterações mínimas.** Antes de escrever, procura o que já existe no repositório e reutiliza.
- **AOT.** Sem reflexão, sem geração de código em tempo de execução, JSON só por source generators. Nunca suprimir avisos `IL2xxx` ou `IL3xxx`; corrige a causa.
- **Portabilidade entre SGBD.** O modelo EF Core não usa funcionalidades específicas de um SGBD nem SQL escrito à mão. Ver `docs/adr/0004-sgbd.md`.
- **Nomes.** Conceitos de negócio em português sem acentos nos identificadores; sufixos técnicos do framework em inglês. O termo de cada conceito está em `docs/guias/glossario.md`.
- **Dependências.** Só com licença permissiva (MIT, Apache-2.0, BSD). As versões ficam em `Directory.Packages.props`.
- **Segredos.** Nunca em código, configuração versionada ou logs.
- **Branches:** `<tipo>/<tema>`. **Commits:** `tipo(âmbito): descrição`, em português.
- **Decisões de arquitectura** registam-se em `docs/adr/`. Não contrariar um ADR sem o substituir por outro.

## Fluxo de trabalho com agentes

| Etapa | Agente | Modelo | Corre |
|---|---|---|---|
| 1. Planear | `planejador` | opus | Sempre |
| 2. Testes que falham | `testador` | sonnet | Sempre |
| 3. Código | `codificador` | sonnet | Sempre |
| 4. Suites | `testador` | sonnet | Sempre |
| 5. Revisão de dados | `guardiao-dados` | sonnet | Se o diff toca em modelo EF Core ou migrações |
| 6. Revisão | `revisor-pr` | sonnet | Sempre |
| 7. Documentação | `documentador` | haiku | Se o plano o indicar |

## Regras do fluxo

- O plano aprovado pelo humano é o contrato das etapas seguintes. Aprova-se uma vez.
- Cada agente recebe só o que precisa: o caminho do plano e, quando revê, o diff.
- Um commit por etapa que altera ficheiros: `wip(<tema>): <etapa>`.
- No máximo dois regressos ao código, por suites falhadas ou por achados de revisão; ao terceiro, pára e pergunta ao humano.

## Papéis

- **Planejador:** escreve o plano. Não escreve código nem testes.
- **Testador:** escreve testes que falham pelo motivo certo; depois corre todas as suites e reporta.
- **Codificador:** faz a menor alteração que põe os testes verdes. Não altera `tests/`.
- **Guardião de dados:** revê modelo e migrações quanto a portabilidade e integridade. Só lê.
- **Revisor de PR:** revê o diff quanto a correcção, AOT e nomes. Só lê.
- **Documentador:** actualiza `docs/`, `AGENTS.md` e os ADR afectados.
