using TaskManager.Models;
using System.Text.Json;

namespace TaskManager.Services
{
    // Facade Pattern Implementation
    // Provides a simplified interface to complex file operations (SaveTasks, LoadTasks, DeleteTask, MarkTaskComplete).
    // Hides the details of JSON serialization, file I/O, and task list manipulation.

    // Subsystems hidden: JSON serialization, file I/O, and file existence checks.

    public static class TaskFileManager
    {
        private const string FileName = "tasks.json";


        public static void SaveTasks(List<TaskItem> tasks, string fileName)
        {
            var json = JsonSerializer.Serialize(tasks);
            File.WriteAllText($"{fileName}.json", json);
        }

        public static List<TaskItem> LoadTasks(string fileName)
        {
            var path = $"{fileName}.json";
            if (!File.Exists(path))
                return new List<TaskItem>();

            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }

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

        public static void DeleteTask(List<TaskItem> tasks, int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
                SaveTasks(tasks);
            }
        }

        public static void MarkTaskComplete(List<TaskItem> tasks, int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                tasks[index].IsComplete = true;
                SaveTasks(tasks);
            }
        }

    }
}