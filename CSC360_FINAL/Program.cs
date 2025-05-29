using TaskManager.Models;
using TaskManager.Services;
using TaskManager.Factories;
using TaskManager.Commands;


// DESIGN PATTERNS:
// 1. FACADE 
// 2. FACTORY 
// 3. COMMAND 



Console.Write("Enter task list name to load or create (e.g., work, home, school): ");
var fileName = Console.ReadLine()?.Trim().ToLower();
if (string.IsNullOrWhiteSpace(fileName)) fileName = "tasks";

List<TaskItem> tasks = TaskFileManager.LoadTasks(fileName);
var factory = new DefaultTaskFactory();

while (true)
{
    Console.Clear();
    Console.WriteLine($"==== Task Manager [{fileName}.json] ====");
    for (int i = 0; i < tasks.Count; i++)
        Console.WriteLine($"{i + 1}. [{(tasks[i].IsComplete ? "X" : " ")}] {tasks[i].Title}");

    Console.WriteLine("\nOptions:");
    Console.WriteLine("0 - Swap current Task list");
    Console.WriteLine("1 - Delete Task List");
    Console.WriteLine("2 - Add Task to list");
    Console.WriteLine("3 - Mark Task Complete");
    Console.WriteLine("4 - Delete Task in list");
    Console.WriteLine("5 - Exit");
    Console.Write("Select an option: ");

    var input = Console.ReadLine();

    switch (input)
    {
        case "0":
            Console.Write("Enter new task list name: ");
            var newFileName = Console.ReadLine()?.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(newFileName))
            {
                fileName = newFileName;
                tasks = TaskFileManager.LoadTasks(fileName);
                Console.WriteLine($"Switched to task list '{fileName}.json'. Press Enter to continue...");
            }
            else
            {
                Console.WriteLine("Invalid file name.");
            }
            break;

        case "1":
            Console.Write("Enter the task list name to delete: ");
            var deleteFile = Console.ReadLine()?.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(deleteFile))
            {
                ICommand deleteListCmd = new DeleteTaskListCommand(deleteFile, () =>
                {
                    if (deleteFile == fileName)
                    {
                        fileName = "tasks";
                        tasks = TaskFileManager.LoadTasks(fileName);
                        Console.WriteLine($"Switched back to default task list '{fileName}.json'.");
                    }
                });
                deleteListCmd.Execute();
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            break;

        case "2":
            Console.Write("Enter task title: ");
            var title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title))
            {
                ICommand addCmd = new AddTaskCommand(tasks, title, factory, fileName);
                addCmd.Execute();
            }
            break;

        case "3":
            Console.Write("Enter task number to mark complete: ");
            if (int.TryParse(Console.ReadLine(), out int markIndex))
            {
                ICommand markCmd = new MarkTaskCompleteCommand(tasks, markIndex - 1, fileName);
                markCmd.Execute();
            }
            break;

        case "4":
            Console.Write("Enter task number to delete: ");
            if (int.TryParse(Console.ReadLine(), out int delIndex))
            {
                ICommand delCmd = new DeleteTaskCommand(tasks, delIndex - 1, fileName);
                delCmd.Execute();
            }
            break;

        case "5":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }

    Console.WriteLine("Press Enter to continue...");
    Console.ReadLine();
}
