# Task Tracker CLI

CLI simples e eficiente para criar, atualizar e acompanhar tarefas diretamente pelo terminal.

## Sobre o projeto

O **Task Tracker CLI** foi desenvolvido em **C# (.NET 8)** para praticar conceitos de:

- Manipulacao de arquivos JSON
- Arquitetura basica por camadas (Model, Service, Program)
- Entrada de argumentos via linha de comando
- Regras de validacao e mensagens de erro

As tarefas sao persistidas em um arquivo `tasks.json` local.

## Funcionalidades

- Adicionar uma nova tarefa
- Atualizar descricao de tarefa existente
- Excluir tarefa por ID
- Marcar tarefa como `done`
- Marcar tarefa como `in-progress`
- Listar todas as tarefas
- Filtrar tarefas por status (`todo`, `in-progress`, `done`)

## Tecnologias

- .NET 8
- C#
- `System.Text.Json`

## Estrutura do projeto

```text
Task-Tracker-CLI/
	README.md
	TaskTrackerCLI/
		Program.cs
		Models/
			TaskModel.cs
		Services/
			TaskService.cs
		tasks.json
```

## Como executar

### 1. Pre-requisitos

- SDK do .NET 8 instalado

### 2. Clonar o repositorio

```bash
git clone https://github.com/SEU-USUARIO/Task-Tracker-CLI.git
cd Task-Tracker-CLI/TaskTrackerCLI
```

### 3. Rodar comandos

Use o formato:

```bash
dotnet run -- <comando> [argumentos]
```

Exemplo rapido:

```bash
dotnet run -- add "Estudar C#"
```

## Comandos disponiveis

| Comando            | Exemplo                                             | Descricao                                                 |
| ------------------ | --------------------------------------------------- | --------------------------------------------------------- |
| `add`              | `dotnet run -- add "Ler documentacao"`              | Cria uma tarefa com status `todo`.                        |
| `update`           | `dotnet run -- update 1 "Ler documentacao oficial"` | Atualiza a descricao da tarefa pelo ID.                   |
| `delete`           | `dotnet run -- delete 1`                            | Remove uma tarefa pelo ID.                                |
| `mark-done`        | `dotnet run -- mark-done 2`                         | Marca a tarefa como concluida.                            |
| `mark-in-progress` | `dotnet run -- mark-in-progress 2`                  | Marca a tarefa como em andamento.                         |
| `list`             | `dotnet run -- list`                                | Lista todas as tarefas.                                   |
| `list <status>`    | `dotnet run -- list done`                           | Lista tarefas por status (`todo`, `in-progress`, `done`). |

## Formato de dados (`tasks.json`)

Cada tarefa salva no arquivo possui a seguinte estrutura:

```json
{
  "id": 1,
  "description": "Estudar C#",
  "status": "todo",
  "createdAt": "2026-03-14T10:00:00",
  "updatedAt": "2026-03-14T10:00:00"
}
```

## Validacoes e mensagens

- Se nenhum comando for informado: `No command provided.`
- Se o comando for invalido: `Command '<nome>' not recognized.`
- Se o ID nao for numero: `Invalid task ID. It must be a number.`
- Se o ID nao existir: `Task with ID <id> not found.`

## Licenca

Este projeto pode ser utilizado para fins de estudo e portfolio.
