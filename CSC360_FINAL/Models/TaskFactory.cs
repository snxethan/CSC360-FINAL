using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

// Factory Design Implementation 
// Centralizes and abstracts the creation logic of TaskItem objects.
// It could include logic to customize or configure tasks at creation time without requiring the client to know how the task is built.

namespace TaskManager.Factories
{
    public abstract class TaskFactory
    {
        public abstract TaskItem CreateTask(string title);
    }

    public class DefaultTaskFactory : TaskFactory
    {
        public override TaskItem CreateTask(string title)
        {
            return new TaskItem(title);
        }
    }
}