using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkTrackr
{
    public class TaskManager
    {
        private List<Task> Tasks = new List<Task>();
        private List<User> Users = new List<User>();  // You’ll define User class separately
        private int nextTaskId = 1;
        private int nextUserId = 1;

        // View all tasks in a formatted list
        public void ViewAllTasks()
        {
            Console.WriteLine("=== All Tasks ===");
            if (Tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            foreach (var task in Tasks)
            {
                Console.WriteLine(task);
            }
        }

        // Create a new task interactively
        public void CreateTask()
        {
            Console.WriteLine("=== Create New Task ===");

            Console.Write("Enter task title: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Enter task description: ");
            string description = Console.ReadLine() ?? "";

            Console.Write("Enter priority (Low, Medium, High): ");
            string priority = Console.ReadLine() ?? "Medium";

            DateTime dueDate;
            Console.Write("Enter due date (yyyy-MM-dd) or leave blank for 1 week from now: ");
            string dueDateInput = Console.ReadLine();
            if (!DateTime.TryParse(dueDateInput, out dueDate))
            {
                dueDate = DateTime.Now.AddDays(7);
            }

            Task newTask = new Task(nextTaskId++, title, description)
            {
                Priority = priority,
                DueDate = dueDate
            };

            Tasks.Add(newTask);
            Console.WriteLine($"Task '{title}' created successfully.");
        }

        // Add a new user
        public void AddUser()
        {
            Console.WriteLine("=== Add New User ===");

            Console.Write("Enter user name: ");
            string userName = Console.ReadLine() ?? "";

            Console.Write("Enter user email: ");
            string email = Console.ReadLine() ?? "";

            User newUser = new User(nextUserId++, userName, email);
            Users.Add(newUser);

            Console.WriteLine($"User '{userName}' added successfully.");
        }


        // Assign task to a user
        public void AssignTask()
        {
            Console.WriteLine("=== Assign Task to User ===");

            if (Tasks.Count == 0)
            {
                Console.WriteLine("No tasks available to assign.");
                return;
            }
            if (Users.Count == 0)
            {
                Console.WriteLine("No users available. Please add users first.");
                return;
            }

            Console.WriteLine("Tasks:");
            foreach (var task in Tasks)
            {
                Console.WriteLine(task);
            }
            Console.Write("Enter Task ID to assign: ");
            if (!int.TryParse(Console.ReadLine(), out int taskId))
            {
                Console.WriteLine("Invalid Task ID.");
                return;
            }

            var taskToAssign = Tasks.FirstOrDefault(t => t.TaskId == taskId);
            if (taskToAssign == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            Console.WriteLine("Users:");
            foreach (var user in Users)
            {
                Console.WriteLine(user);
            }
            Console.Write("Enter User ID to assign the task to: ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("Invalid User ID.");
                return;
            }

            var userToAssign = Users.FirstOrDefault(u => u.UserId == userId);
            if (userToAssign == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            taskToAssign.AssignedUserId = userId;
            Console.WriteLine($"Task '{taskToAssign.Title}' assigned to user '{userToAssign.Name}'.");
        }

        // Update task status
        public void UpdateTaskStatus()
        {
            Console.WriteLine("=== Update Task Status ===");

            if (Tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            foreach (var task in Tasks)
            {
                Console.WriteLine(task);
            }

            Console.Write("Enter Task ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int taskId))
            {
                Console.WriteLine("Invalid Task ID.");
                return;
            }

            var taskToUpdate = Tasks.FirstOrDefault(t => t.TaskId == taskId);
            if (taskToUpdate == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            Console.WriteLine("Possible statuses: Backlog, In Progress, In Review, Completed");
            Console.Write("Enter new status: ");
            string status = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(status) ||
                !new[] { "Backlog", "In Progress", "In Review", "Completed" }
                .Contains(status, StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine("Invalid status.");
                return;
            }

            taskToUpdate.Status = status;
            Console.WriteLine($"Task '{taskToUpdate.Title}' status updated to '{status}'.");
        }

        // View Dashboard (summary with LINQ filters)
        public void ViewDashboard()
        {
            Console.WriteLine("=== Dashboard ===");
            if (Tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            int totalTasks = Tasks.Count;
            int completedTasks = Tasks.Count(t => t.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase));
            int inProgressTasks = Tasks.Count(t => t.Status.Equals("In Progress", StringComparison.OrdinalIgnoreCase));
            int backlogTasks = Tasks.Count(t => t.Status.Equals("Backlog", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"Total tasks: {totalTasks}");
            Console.WriteLine($"Completed tasks: {completedTasks}");
            Console.WriteLine($"In Progress tasks: {inProgressTasks}");
            Console.WriteLine($"Backlog tasks: {backlogTasks}");

            Console.WriteLine("\nTasks by Priority:");
            var byPriority = Tasks.GroupBy(t => t.Priority);
            foreach (var group in byPriority)
            {
                Console.WriteLine($"{group.Key}: {group.Count()} tasks");
            }
        }
    }
}
