namespace TaskManager.Commands
{
    public class DeleteTaskListCommand : ICommand
    {
        private readonly string _targetFile;
        private readonly Action onDeleted;

        public DeleteTaskListCommand(string targetFile, Action onDeleted)
        {
            _targetFile = $"{targetFile}.json";
            this.onDeleted = onDeleted;
        }

        public void Execute()
        {
            if (File.Exists(_targetFile))
            {
                File.Delete(_targetFile);
                Console.WriteLine($"Deleted {_targetFile}");
                onDeleted.Invoke(); // Callback to update current list
            }
            else Console.WriteLine("Task list file not found.");
        }
    }
}
