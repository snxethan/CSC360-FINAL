using TaskManager.Models;
using TaskManager.Services;

List<TaskItem> tasks = TaskFileManager.LoadTasks();

Console.WriteLine("Current Tasks:");
foreach (var t in tasks)
    Console.WriteLine($"- [{(t.IsComplete ? "X" : " ")}] {t.Title}");

Console.WriteLine("\nAdd a task:");
var title = Console.ReadLine();
if (!string.IsNullOrWhiteSpace(title))
{
    tasks.Add(new TaskItem(title));
    TaskFileManager.SaveTasks(tasks);
    Console.WriteLine("Task saved!");
}