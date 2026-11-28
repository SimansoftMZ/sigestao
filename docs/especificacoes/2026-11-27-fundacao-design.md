# siGestão — Fundação (Fase 0): desenho

- **Estado:** rascunho para revisão
- **Data:** 2026-11-27
- **Âmbito:** repositório aberto `sigestao` e repositório privado `sigestao-pro`

## 1. Objectivo

Preparar os dois repositórios para que a implementação do ERP comece sobre regras já escritas: documentação, decisões de arquitectura registadas, agentes de IA, CI/CD e ambiente de testes. Esta fase não implementa funcionalidades de negócio.

## 2. Fora do âmbito

- Qualquer módulo de negócio (vendas, stock, RH, etc.).
- Escolha da tecnologia de interface (ver D11).
- Marketplace e carregamento de plugins em tempo de execução.
- Migração de dados do siGestaoV1.
- Deploy para ambientes de clientes.

## 3. Decisões

Cada linha dá origem a um ADR em `docs/adr/`.

| ID | Tema | Decisão |
|---|---|---|
| D1 | Licença | Licenciamento duplo: **AGPL-3.0** (só a versão 3, identificador SPDX `AGPL-3.0-only`; confirmado pelo responsável em 2026-11-28) para todos, e **licença comercial** com partilha de receitas para quem quer comercializar sem abrir o seu código ou usar a marca siGestão. Contribuições externas exigem **CLA** assinado, para a Simansoft poder licenciar o código comercialmente. Só entram dependências com licença permissiva (MIT, Apache-2.0, BSD). Ver secção 16. |
| D2 | Plataforma | .NET 11 e C# 15 em todos os projectos. O .NET 11 é STS (suporte até Novembro de 2028); planear a subida para o .NET 12 LTS quando sair. |
| D3 | AOT | Todas as bibliotecas são compatíveis com AOT (`IsAotCompatible`, analisadores de trimming e AOT a falhar o build, JSON por source generators, sem reflexão). Publicam em Native AOT os executáveis onde isso é suportado. Hosts com EF Core correm em JIT com ReadyToRun enquanto o Native AOT do EF Core for experimental. O modelo compilado só se usa quando o EF Core o suportar com filtros globais (alterado pelo teste exploratório e confirmado pelo responsável em 2026-11-28; ver ADR 0003). |
| D4 | SGBD | EF Core 11, code-first, um modelo único. **Nível 1:** PostgreSQL e SQL Server, testados em cada PR. **Nível 2:** MySQL e Oracle, que entram quando os respectivos provedores suportarem EF Core 11. O modelo fica pelo denominador comum: sem funcionalidades específicas de um SGBD. |
| D5 | Estilo | Monólito modular: um módulo por área de negócio, com contratos públicos explícitos. Os módulos são compostos em tempo de compilação pelo projecto host. |
| D6 | Ligação entre repos | A base publica pacotes NuGet `Simansoft.SiGestao.*` com SemVer. As distros (incluindo o `sigestao-pro`) consomem os pacotes; não há fork nem submódulo. |
| D7 | Migrações | Cada módulo contribui com a configuração do seu modelo. As migrações vivem na distro, um projecto por provedor. A base inclui uma distro de referência, **Comunidade**, usada no CI e em demonstrações. |
| D8 | Dados | Multi-empresa por filtro global, chaves `Guid` versão 7, numeração de documentos fiscais por sequência com bloqueio, valores monetários em `decimal` com precisão explícita. |
| D9 | Nomes | Ver secção 5. |
| D10 | Testes | Ver secção 9. |
| D11 | Interface e consumidores | A base é API-first e não assume linguagem nem framework de interface. Estão previstas implementações em MAUI e, possivelmente, em ASP.NET e Blazor; a escolha faz-se em especificação própria. Os pacotes visam apenas .NET moderno (`net11.0`). Ver secção 12. |

## 4. Repositórios

| | `sigestao` | `sigestao-pro` |
|---|---|---|
| Visibilidade | Pública | Privada |
| Produto | siGestão (base e distro Comunidade) | siGestão Pro |
| Licença | AGPL-3.0 | Proprietária |
| Conteúdo | Núcleo, módulos base, contratos, kit de testes | Host da distro, módulos e personalizações da Simansoft, migrações, deploy |
| Depende de | — | Pacotes `Simansoft.SiGestao.*` |

Outros implementadores criam a sua distro da mesma forma que o `sigestao-pro`: um host que referencia os pacotes da base e acrescenta os seus módulos. Pela AGPL, essas distros têm de disponibilizar o código-fonte a quem as recebe ou usa em rede; quem não o quiser fazer celebra um acordo de parceiro com a Simansoft (secção 16).

## 5. Convenções de nomes

- Conceitos de negócio em português, sem acentos nem cedilhas nos identificadores: `Factura`, `LinhaFactura`, `Fornecedor`.
- Convenções do .NET: PascalCase, prefixo `I` nas interfaces, sufixo `Async`.
- Sufixos e padrões técnicos do framework ficam em inglês: `VendasDbContext`, `FacturaEndpoints`, `AddVendas()`, `*.Tests`.
- Sem prefixos de tipo (`Tb`) nem `_` em nomes de tabelas.
- Raiz dos namespaces e pacotes: `Simansoft.SiGestao`.
- Documentação, comentários, mensagens de commit e de erro em português de Moçambique.
- `docs/guias/glossario.md` fixa o termo de cada conceito, para não haver sinónimos no código.

## 6. Estrutura do repositório `sigestao`

```
/
├─ README.md  CONTRIBUTING.md  CLA.md  LICENCIAMENTO.md  SECURITY.md  ROADMAP.md  LICENSE
├─ AGENTS.md  CLAUDE.md
├─ .editorconfig  .gitattributes  global.json
├─ Directory.Build.props  Directory.Packages.props  SiGestao.slnx
├─ .claude/
│  ├─ agents/            (6 agentes)
│  ├─ commands/fluxo.md
│  └─ settings.json     (criado pelo responsável do projecto)
├─ .devcontainer/devcontainer.json
├─ .github/
│  ├─ workflows/         (ci, codeql, publicar, revisao-ia; cla adiado)
│  ├─ ISSUE_TEMPLATE/  pull_request_template.md
│  └─ CODEOWNERS  dependabot.yml
├─ docs/
│  ├─ arquitectura/visao-geral.md
│  ├─ adr/               (0001 a 0011)
│  ├─ especificacoes/    (AAAA-MM-DD-<tema>-design.md)
│  ├─ planos/            (AAAA-MM-DD-<tema>.md)
│  └─ guias/             (glossario, convencoes, criar-uma-distro, testes)
├─ src/Simansoft.SiGestao.Nucleo/
└─ tests/Simansoft.SiGestao.Nucleo.Tests/
```

- `Directory.Build.props` fixa: `net11.0`, `Nullable`, avisos como erros, `IsAotCompatible`, nível de análise recomendado.
- `Directory.Packages.props` centraliza as versões dos pacotes.
- `src/` e `tests/` têm apenas um projecto mínimo e um teste, sem lógica de negócio, para provar que o pipeline funciona.

## 7. Agentes e fluxo

`AGENTS.md` contém as regras comuns e a descrição de cada papel, e serve qualquer assistente. `CLAUDE.md` importa-o e acrescenta comandos e arquitectura.

| Agente | Papel | Ferramentas | Modelo |
|---|---|---|---|
| `planejador` | Escreve o plano em `docs/planos/`; não toca em código | Read, Grep, Glob, Write | opus |
| `testador` | Escreve os testes que falham; depois corre todas as suites | Read, Grep, Glob, Bash, Edit, Write | sonnet |
| `codificador` | Faz a menor alteração que põe os testes verdes; não mexe em `tests/` | Read, Grep, Glob, Bash, Edit, Write | sonnet |
| `guardiao-dados` | Revê modelo EF Core e migrações quanto a portabilidade entre SGBD | Read, Grep, Glob | sonnet |
| `revisor-pr` | Revê o diff: correcção, compatibilidade AOT, nomes | Read, Grep, Glob | sonnet |
| `documentador` | Actualiza `docs/`, `AGENTS.md` e ADR | Read, Grep, Glob, Edit, Write | haiku |

O comando `/fluxo` encadeia: planear → aprovação humana do plano → testes → código → suites → revisão de dados (se houver alterações ao modelo) → revisão → documentação. O plano aprovado é o contrato das etapas seguintes.

Entram mais tarde, quando houver o que tratar: `simulador` (interface), `analisador-seguranca` (superfície de ataque) e `publicador` (releases).

## 8. CI/CD

Runners alojados pelo GitHub (`ubuntu-latest`).

| Workflow | Gatilho | O que faz |
|---|---|---|
| `ci.yml` | PR e push para `main` | Restaurar, compilar com avisos como erros (inclui analisadores AOT), `dotnet format --verify-no-changes`, testes com cobertura |
| `codeql.yml` | PR, push para `main`, semanal | Análise estática de segurança |
| `revisao-ia.yml` | PR | Revisão automática com a action do Claude, fixada por SHA. Exige um segredo configurado no repositório |
| `cla.yml` | PR | Verifica se o autor assinou o CLA. **Adiado:** a action prevista está arquivada; até haver uma via mantida, a verificação é manual (caixa no modelo de PR e aprovação do dono do código) |
| `publicar.yml` | Manual (`workflow_dispatch`) com versão | Empacota e publica os pacotes NuGet |

- Protecção da `main`: PR obrigatório, `ci` verde, uma aprovação.
- Dependabot actualiza pacotes NuGet e actions.
- A matriz de SGBD (PostgreSQL e SQL Server com Testcontainers) entra no `ci.yml` com o primeiro `DbContext`, na Fase 1. O workflow nocturno entra com o Nível 2.
- A primeira publicação no nuget.org é decisão do responsável do projecto: pacotes publicados não podem ser apagados.

## 9. Testes

- **Unitários:** xUnit v3, sem infra-estrutura.
- **Integração:** Testcontainers, com SGBD real em Docker; correm iguais no computador do programador, no Codespaces e no GitHub Actions. Não se usa SQLite nem provedor em memória como substituto.
- **Dados fictícios:** gerador com semente fixa e dados moçambicanos (NUIT, províncias, nomes), num projecto de kit de testes reutilizável pelas distros e por ambientes de demonstração. Entra na Fase 1.
- **Sem instalação:** `.devcontainer` com SDK .NET 11 e Docker; abrir no Codespaces basta para compilar e testar.
- `docs/guias/testes.md` descreve a estratégia e como correr cada tipo.

## 10. Testes exploratórios

Código descartável, feito antes de fechar os ADR correspondentes. As conclusões ficam escritas no ADR.

1. **EF Core 11 com Native AOT** (D3): modelo com filtro global por empresa, modelo compilado e queries pré-compiladas, sobre PostgreSQL. Pergunta: o que funciona e o que falha.
2. **Um modelo, dois SGBD** (D4, D7): o mesmo modelo a gerar migrações para PostgreSQL e SQL Server em projectos separados. Pergunta: que diferenças obrigam a regras no modelo.

## 11. Repositório `sigestao-pro`

Recebe o mínimo equivalente: `README`, `AGENTS.md` e `CLAUDE.md` (remetem para as regras da base e acrescentam as específicas), a mesma configuração de build, cópia dos agentes, `ci.yml` (compilar e testar) e aviso de licença proprietária. A criação do repositório no GitHub é feita pelo responsável do projecto.

## 12. Consumidores da base (D11)

A base pode ser usada a partir de qualquer linguagem .NET (C#, F#, VB) e de qualquer framework de interface (MAUI, ASP.NET, Blazor, etc.). Regras:

- contratos e cliente HTTP ficam em pacotes sem dependências de interface;
- a API pública dos pacotes segue as regras CLS;
- a API HTTP publica OpenAPI, que serve também consumidores fora do .NET;
- os pacotes visam só `net11.0`; não há suporte para .NET Framework.

## 13. Critérios de aceitação

1. `dotnet build` e `dotnet test` passam localmente e no CI, com avisos como erros.
2. Os analisadores de AOT e trimming estão activos e falham o build quando violados.
3. `dotnet format --verify-no-changes` passa.
4. Existe um ADR para cada decisão D1 a D11.
5. Os dois testes exploratórios têm conclusões escritas nos ADR de D3, D4 e D7.
6. O devcontainer compila e corre os testes sem instalações adicionais.
7. `/fluxo` percorre todas as etapas numa alteração trivial.
8. Um PR de teste mostra `ci` e `codeql` a correr.

## 14. Riscos

| Risco | Mitigação |
|---|---|
| Provedores de MySQL e Oracle demoram a suportar EF Core 11 | Nível 2 não bloqueia o Nível 1; regras de portabilidade aplicadas desde o início |
| Native AOT do EF Core continua experimental | Hosts com EF Core em JIT; reavaliar em cada versão |
| PR externo aceite sem CLA | Não se aceitam contribuições externas de código enquanto o CLA for rascunho; depois, aprovação obrigatória do dono do código e, quando houver via mantida, verificação automática no PR |
| Marca siGestão por registar | Registo tratado pela Simansoft; a política de marca só é oponível depois dele |
| Dependência com licença incompatível | Regra em `CONTRIBUTING.md` e na revisão de PR |
| .NET 11 perde suporte em Novembro de 2028 | Subida para .NET 12 LTS planeada no `ROADMAP.md` |

## 15. Fases seguintes

Cada fase tem especificação e plano próprios.

1. **Plataforma:** multi-empresa, identidade e acessos, numeração de documentos, auditoria, distro Comunidade, matriz de SGBD no CI, kit de dados fictícios.
2. **Primeiro módulo vertical:** vendas e facturação mínimas, para validar a arquitectura de ponta a ponta.
3. **Interface:** especificação e primeira aplicação cliente.
4. **Módulos seguintes**, pela ordem do `ROADMAP.md`.

## 16. Modelo comercial (D1)

Objectivo: o código é aberto, e quem comercializar o siGestão celebra um acordo de partilha de receitas com a Simansoft.

- **AGPL-3.0** para todos: uso, modificação e distribuição livres, com a obrigação de publicar o código de qualquer versão distribuída ou servida em rede.
- **Licença comercial** (acordo de parceiro com partilha de receitas) para quem quer comercializar sem publicar o seu código.
- **Marca:** só parceiros podem comercializar com o nome e o logótipo siGestão.
- **Limite aceite:** quem cumprir a AGPL por inteiro e não usar a marca pode comercializar sem acordo.

`LICENCIAMENTO.md` explica este modelo em linguagem simples, a política de marca e o contacto para acordos; o `README` e o `CONTRIBUTING` remetem para ele. O texto do acordo de parceiro, do CLA e o registo da marca são tratados fora do repositório, com apoio jurídico.
