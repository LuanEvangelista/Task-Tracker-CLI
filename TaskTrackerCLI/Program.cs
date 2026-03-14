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
        Console.WriteLine("Listing tasks...");
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

    var descricao = args[1];
    Console.WriteLine("Task added successfully");
}

void UpdateTask(string[] args)
{
    if (args.Length < 3)
    {
        Console.WriteLine("Please provide a task ID and description.");
        return;
    }

    var taskId = args[1];
    var novaDescricao = args[2];

    Console.WriteLine($"Task {taskId} updated successfully");
}

void DeleteTask(string[] args)
{
    if (args.Length < 2)
    {
        Console.WriteLine("Please provide a task ID.");
        return;
    }

    var taskId = args[1];
    Console.WriteLine($"Task {taskId} deleted successfully");
}

void MarkDone(string[] args)
{
    if (args.Length < 2)
    {
        Console.WriteLine("Please provide a task ID.");
        return;
    }

    var taskId = args[1];
    Console.WriteLine($"Task {taskId} marked as done.");
}

void MarkInProgress(string[] args)
{
    if (args.Length < 2)
    {
        Console.WriteLine("Please provide a task ID.");
        return;
    }

    var taskId = args[1];
    Console.WriteLine($"Task {taskId} marked as in progress.");
}