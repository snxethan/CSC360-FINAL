# CSC360 Final Project

This is a C# Windows desktop application developed as part of the **CSC360** course at **Neumont College of Computer Science**.  
The application is designed to manage tasks, allowing users to create, edit, and delete tasks, as well as save and load them from disk.

---
## Design Patterns Used: Facade, Factory Method, Command

### Facade Pattern – `TaskFileManager`
This project utilizes the **Facade Pattern** to simplify the storage and retrieval of task data.

- All file operations—such as saving, loading, deleting tasks, and marking them complete—are centralized in the `TaskFileManager` class.
- It provides a clean and simple interface (`SaveTasks`, `LoadTasks`, etc.) while hiding complex logic like file path handling, JSON serialization, and I/O checks.
- This keeps the main CLI program and command classes focused on high-level logic, without needing to manage low-level file system operations.


### Factory Method Pattern – `TaskFactory`
The **Factory Method Pattern** is used to abstract the creation of task objects.

- The `TaskFactory` abstract class defines a method `CreateTask`, and `DefaultTaskFactory` implements it to create standard `TaskItem` objects.
- Instead of directly instantiating `TaskItem` with `new`, the program uses the factory to create tasks. This allows for greater flexibility and scalability.
- In the future, different types of tasks (e.g., timed tasks or priority tasks) can be created by extending the factory without modifying the main program logic.

Example usage:
```csharp
var factory = new DefaultTaskFactory();
var task = factory.CreateTask("Example Task");
```

### Command Pattern – `ICommand` and Command Classes
The **Command Pattern** is used to encapsulate user actions as command objects.

- Each task operation, such as adding, deleting, or marking a task as complete, is implemented as a class that implements the `ICommand` interface with an `Execute()` method.
- This separates the execution logic from the CLI input handling, making the codebase easier to maintain, test, and extend.
- Commands include: `AddTaskCommand`, `DeleteTaskCommand`, `MarkTaskCompleteCommand`, and `DeleteTaskListCommand`.

Example usage:
```csharp
ICommand addCmd = new AddTaskCommand(tasks, "Read design pattern docs", factory, "school");
addCmd.Execute();
```

## Project Structure
```text
/TaskManager/
├── Models/
│   └── TaskItem.cs                 # Represents a single task with title & status
│
├── Services/
│   └── TaskFileManager.cs          # Facade for file I/O logic (save/load/delete/mark)
│
├── Factories/
│   └── TaskFactory.cs              # Factory Method for creating TaskItem instances
│
├── Commands/
│   ├── ICommand.cs                 # Interface for all command classes
│   ├── AddTaskCommand.cs          # Encapsulates logic to add a task
│   ├── DeleteTaskCommand.cs       # Encapsulates logic to delete a task
│   ├── MarkTaskCompleteCommand.cs # Encapsulates logic to mark task complete
│   └── DeleteTaskListCommand.cs   # Encapsulates logic to delete an entire task list
│
├── Program.cs                     # Entry point of the application (CLI logic)
├── TaskManager.csproj             # Project configuration file
├── README.md                      # Project overview and documentation
│
├── \bin\Debug\net8.0\
│   └── Tasks.json                 # The task(s) file you will have created when running this application.
```



## Features (Planned/Implemented)

- [x] Add new tasks via command line
- [x] Mark tasks as complete
- [x] Save tasks to a JSON file
- [x] Load tasks from a saved file
- [x] Delete individual tasks
- [x] Support for multiple task lists or projects (via file name input)
- [x] Delete an entire task list (task file)
- [ ] Edit or update existing tasks
- [ ] Import/export support (e.g., between formats or lists)

---

## Dependencies

- [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) or later (Console App)
- No external NuGet packages required
- Built-in libraries only (System.Text.Json, System.IO, etc.)
- 

## Author(s)

- [**Ethan Townsend (snxethan)**](https://www.ethantownsend.dev)

