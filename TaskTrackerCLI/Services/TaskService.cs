using System.Text.Json;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Services
{
    public class TaskService
    {
        private readonly string _filePath;
        public TaskService()
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), "tasks.json");
        }

        public List<TaskModel> GetTasks()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
                return new List<TaskModel>();
            }

            var json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
                return new List<TaskModel>();

            return JsonSerializer.Deserialize<List<TaskModel>>(json) ?? new List<TaskModel>();
        }

        public void SaveTasks(List<TaskModel> tasks)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(tasks, options);
            File.WriteAllText(_filePath, json);
        }

        public void AddTask(string description)
        {
            var tasks = GetTasks();

            int nextId = tasks.Count == 0 ? 1 : tasks.Max(t => t.Id) + 1;

            var task = new TaskModel
            {
                Id = nextId,
                Description = description,
                Status = "todo",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            tasks.Add(task);
            SaveTasks(tasks);

            Console.WriteLine($"Task added successfully (ID: {task.Id})");
        }

        public void UpdateTask(int id, string description)
        {
            var tasks = GetTasks();
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                Console.WriteLine($"Task with ID {id} not found.");
                return;
            }

            task.Description = description;
            task.UpdatedAt = DateTime.Now;

            SaveTasks(tasks);
            Console.WriteLine($"Task {id} updated successfully.");
        }

        public void DeleteTask(int id)
        {
            var tasks = GetTasks();
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                Console.WriteLine($"Task with ID {id} not found.");
                return;
            }

            tasks.Remove(task);
            SaveTasks(tasks);

            Console.WriteLine($"Task {id} deleted successfully.");
        }

        private void UpdateStatus(int id, string status, string successMessage)
        {
            var tasks = GetTasks();
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                Console.WriteLine($"Task with ID {id} not found.");
                return;
            }

            task.Status = status;
            task.UpdatedAt = DateTime.Now;

            SaveTasks(tasks);
            Console.WriteLine(successMessage);
        }

        public void MarkDone(int id)
        {
            UpdateStatus(id, "done", $"Task {id} marked as done.");
        }

        public void MarkInProgress(int id)
        {
            UpdateStatus(id, "in-progress", $"Task {id} marked as in progress.");
        }
        public void ListTasks(string? status = null)
        {
            var tasks = GetTasks();

            if (!string.IsNullOrWhiteSpace(status))
                tasks = tasks.Where(t => t.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();

            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            foreach (var task in tasks)
            {
                Console.WriteLine($"[{task.Id}] {task.Description} | Status: {task.Status} | Created: {task.CreatedAt:dd/MM/yyyy HH:mm} | Updated: {task.UpdatedAt:dd/MM/yyyy HH:mm}");
            }
        }

    }
}
