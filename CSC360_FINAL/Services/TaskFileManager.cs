using TaskManager.Models;
using System.Text.Json;

namespace TaskManager.Services
{
    public static class TaskFileManager
    {
        private const string FileName = "tasks.json";

        public static void SaveTasks(List<TaskItem> tasks)
        {
            var json = JsonSerializer.Serialize(tasks);
            File.WriteAllText(FileName, json);
        }

        public static List<TaskItem> LoadTasks()
        {
            if (!File.Exists(FileName))
                return new List<TaskItem>();

            var json = File.ReadAllText(FileName);
            return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }
    }
}