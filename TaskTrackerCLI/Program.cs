using TaskTrackerCLI.Services;
var taskService = new TaskService();

if (args.Length == 0)
{
    Console.WriteLine("No command provided.");
    return;
}

var command = args[0].ToLower();

switch (command)
{
    case "add":
        AddTask(args);
        break;

    case "update":
        UpdateTask(args);
        break;

    case "delete":
        DeleteTask(args);
        break;

    case "list":
        ListTasks(args);
        break;

    case "mark-done":
        MarkDone(args);
        break;

    case "mark-in-progress":
        MarkInProgress(args);
        break;

    default:
        Console.WriteLine($"Command '{command}' not recognized.");
        break;
}

void AddTask(string[] args)
{
    if (args.Length < 2)
    {
        Console.WriteLine("Please provide a task description.");
        return;
    }

    var description = args[1];
    taskService.AddTask(description);
}

void UpdateTask(string[] args)
{
    if (args.Length < 3)
    {
        Console.WriteLine("Please provide a task ID and description.");
        return;
    }

    if (!TryGetTaskId(args, out var taskId))
        return;

    var description = args[2];

    taskService.UpdateTask(taskId, description);
}

void DeleteTask(string[] args)
{
    if (args.Length < 2)
    {
        Console.WriteLine("Please provide a task ID.");
        return;
    }

    if (!TryGetTaskId(args, out var taskId))
        return;

    taskService.DeleteTask(taskId);
}

void MarkDone(string[] args)
{
    if (args.Length < 2)
    {
        Console.WriteLine("Please provide a task ID.");
        return;
    }

    if (!TryGetTaskId(args, out var taskId))
        return;
    taskService.MarkDone(taskId);
}

void MarkInProgress(string[] args)
{
    if (args.Length < 2)
    {
        Console.WriteLine("Please provide a task ID.");
        return;
    }

    if (!TryGetTaskId(args, out var taskId))
        return;
    taskService.MarkInProgress(taskId);
}

void ListTasks(string[] args)
{
    if (args.Length == 1)
    {
        taskService.ListTasks();
        return;
    }

    var status = args[1].ToLower();

    switch (status)
    {
        case "done":
        case "todo":
        case "in-progress":
            taskService.ListTasks(status);
            break;

        default:
            Console.WriteLine("Invalid status. Use: done, todo, or in-progress.");
            break;
    }
}


bool TryGetTaskId(string[] args, out int taskId)
{
    taskId = 0;

    if (args.Length < 2)
    {
        Console.WriteLine("Please provide a task ID.");
        return false;
    }

    if (!int.TryParse(args[1], out taskId))
    {
        Console.WriteLine("Invalid task ID. It must be a number.");
        return false;
    }

    return true;
}