namespace TaskManager.Models
{
    public class TaskItem
    {
        public string Title { get; set; }
        public bool IsComplete { get; set; }

        public TaskItem(string title)
        {
            Title = title;
            IsComplete = false;
        }
    }
}