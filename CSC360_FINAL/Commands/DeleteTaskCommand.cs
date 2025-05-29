using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Commands
{
    public class DeleteTaskCommand : ICommand
    {
        private readonly List<TaskItem> _tasks;
        private readonly int _index;
        private readonly string _fileName;

        public DeleteTaskCommand(List<TaskItem> tasks, int index, string fileName)
        {
            _tasks = tasks;
            _index = index;
            _fileName = fileName;
        }

        public void Execute()
        {
            if (_index >= 0 && _index < _tasks.Count)
            {
                _tasks.RemoveAt(_index);
                TaskFileManager.SaveTasks(_tasks, _fileName);
                Console.WriteLine("Task deleted.");
            }
            else Console.WriteLine("Invalid index.");
        }
    }
}