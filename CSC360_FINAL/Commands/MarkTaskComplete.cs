using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Commands
{
    public class MarkTaskCompleteCommand : ICommand
    {
        private readonly List<TaskItem> _tasks;
        private readonly int _index;
        private readonly string _fileName;

        public MarkTaskCompleteCommand(List<TaskItem> tasks, int index, string fileName)
        {
            _tasks = tasks;
            _index = index;
            _fileName = fileName;
        }

        public void Execute()
        {
            if (_index >= 0 && _index < _tasks.Count)
            {
                _tasks[_index].IsComplete = true;
                TaskFileManager.SaveTasks(_tasks, _fileName);
                Console.WriteLine("Task marked as complete.");
            }
            else Console.WriteLine("Invalid index.");
        }
    }
}