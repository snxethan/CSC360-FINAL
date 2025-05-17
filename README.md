# CSC360 Final Project

This is a C# Windows desktop application developed as part of the **CSC360** course at **Neumont College of Computer Science**.  
The application is designed to manage tasks, allowing users to create, edit, and delete tasks and save and load them from disk.

---

## Design Pattern Used: Facade

This project uses the **Facade pattern** to simplify how tasks are saved and loaded from disk.

- All file operations are handled by `TaskFileManager`, which exposes a simple interface (`SaveTasks` and `LoadTasks`) and hides the complexity of file paths, JSON serialization, and error handling.
- This keeps the main program logic clean and focused only on task management, not low-level storage details.

---

## Project Structure (Planned)
/TaskManager/

├── Models/

│ └── TaskItem.cs # Represents a single task with title & status

├── Services/

│ └── TaskFileManager.cs # Facade for file I/O logic (save/load)

├── Program.cs # Entry point of the application (CLI)

├── README.md # Project overview and documentation

├── TaskManager.csproj # Project definition

## Features (Planned/Implemented)

- [x] Add new tasks via command line
- [x] Mark tasks as complete
- [x] Save tasks to a JSON file
- [x] Load tasks from a saved file
- [ ] Delete or update tasks
- [ ] Support for multiple task lists or projects
- [ ] Import/export support

---

## Dependencies

- .NET 6 or later (Console App)
- No external packages required

