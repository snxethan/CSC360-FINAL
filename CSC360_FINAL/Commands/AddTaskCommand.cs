using TaskManager.Models;
using TaskManager.Services;
using TaskManager.Factories;
using TaskFactory = TaskManager.Factories.TaskFactory;

namespace TaskManager.Commands
{
    public class AddTaskCommand : ICommand
    {
        private readonly List<TaskItem> _tasks;
        private readonly string _title;
        private readonly TaskFactory _factory;
        private readonly string _fileName;

        public AddTaskCommand(List<TaskItem> tasks, string title, TaskFactory factory, string fileName)
        {
            _tasks = tasks;
            _title = title;
            _factory = factory;
            _fileName = fileName;
        }

        public void Execute()
        {
            var task = _factory.CreateTask(_title);
            _tasks.Add(task);
            TaskFileManager.SaveTasks(_tasks, _fileName);
            Console.WriteLine("Task added.");
        }
    }
}