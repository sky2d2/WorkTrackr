﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace WorkTrackr
{
    public class TaskManager
    {
        private List<Task> Tasks = new List<Task>();
        private List<User> Users = new List<User>();
        private int nextTaskId = 1;
        private int nextUserId = 1;
        private const string usersFile = "users.json";

        public void SaveUsers()
        {
            var json = JsonSerializer.Serialize(Users);
            System.IO.File.WriteAllText(usersFile, json);
        }

        public void LoadUsers()
        {
            if (System.IO.File.Exists(usersFile))
            {
                var json = System.IO.File.ReadAllText(usersFile);
                Users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
                nextUserId = Users.Any() ? Users.Max(u => u.UserId) + 1 : 1;
            }
        }

        // Create a new task
        public void CreateTask()
        {
            Console.WriteLine("=== Create New Task ===");

            Console.Write("Enter task title: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Enter task description: ");
            string description = Console.ReadLine() ?? "";

            string priority = "";
            while (true)
            {
                Console.Write("Enter Priority (1 = Low, 2 = Medium, 3 = High): ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        priority = "Low";
                        break;
                    case "2":
                        priority = "Medium";
                        break;
                    case "3":
                        priority = "High";
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
                        continue;
                }
                break;
            }

            DateTime dueDate;
            while (true)
            {
                Console.WriteLine("Select Due Date option:");
                Console.WriteLine("1 = 1 week from today");
                Console.WriteLine("2 = 2 weeks from today");
                Console.WriteLine("3 = Custom date (yyyy-MM-dd)");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    dueDate = DateTime.Today.AddDays(7);
                    break;
                }
                else if (choice == "2")
                {
                    dueDate = DateTime.Today.AddDays(14);
                    break;
                }
                else if (choice == "3")
                {
                    Console.Write("Enter due date (yyyy-MM-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out dueDate))
                    {
                        if (dueDate < DateTime.Today)
                        {
                            Console.WriteLine("Due date cannot be in the past.");
                            continue;
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid format. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }

            Task newTask = new Task(nextTaskId++, title, description)
            {
                Priority = priority,
                DueDate = dueDate,
                Status = "Backlog"
            };

            Tasks.Add(newTask);
            Console.WriteLine($"Task '{title}' created successfully!");
        }

        // View all tasks with colors based on status
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
                switch (task.Status)
                {
                    case "Backlog": Console.ForegroundColor = ConsoleColor.Gray; break;
                    case "In Progress": Console.ForegroundColor = ConsoleColor.Yellow; break;
                    case "In Review": Console.ForegroundColor = ConsoleColor.Blue; break;
                    case "Completed": Console.ForegroundColor = ConsoleColor.Green; break;
                    default: Console.ResetColor(); break;
                }

                Console.WriteLine(task.GetSummary());
                Console.ResetColor();
            }
        }

        // Edit existing task
        public void EditTask()
        {
            Console.WriteLine("=== Edit Task ===");
            if (Tasks.Count == 0)
            {
                Console.WriteLine("No tasks to edit.");
                return;
            }

            foreach (var task in Tasks)
            {
                Console.WriteLine(task);
            }

            Console.Write("Enter Task ID to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int taskId))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var taskToEdit = Tasks.FirstOrDefault(t => t.TaskId == taskId);
            if (taskToEdit == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            Console.Write($"Title ({taskToEdit.Title}): ");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTitle)) taskToEdit.Title = newTitle;

            Console.Write($"Description ({taskToEdit.Description}): ");
            string newDesc = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newDesc)) taskToEdit.Description = newDesc;

            Console.Write($"Priority ({taskToEdit.Priority}) [1=Low, 2=Medium, 3=High]: ");
            string priorityInput = Console.ReadLine();
            switch (priorityInput)
            {
                case "1": taskToEdit.Priority = "Low"; break;
                case "2": taskToEdit.Priority = "Medium"; break;
                case "3": taskToEdit.Priority = "High"; break;
            }

            Console.WriteLine("Task updated!");
        }

        // Delete a task
        public void DeleteTask()
        {
            Console.WriteLine("=== Delete Task ===");

            if (Tasks.Count == 0)
            {
                Console.WriteLine("No tasks to delete.");
                return;
            }

            foreach (var task in Tasks)
            {
                Console.WriteLine(task);
            }

            Console.Write("Enter Task ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int taskId))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var taskToDelete = Tasks.FirstOrDefault(t => t.TaskId == taskId);
            if (taskToDelete == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            Console.Write($"Are you sure you want to delete task '{taskToDelete.Title}'? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                Tasks.Remove(taskToDelete);
                Console.WriteLine("Task deleted.");
            }
            else
            {
                Console.WriteLine("Cancelled.");
            }
        }

        // Add new user
        public void AddUser()
        {
            Console.WriteLine("=== Add New User ===");

            Console.Write("Enter user name: ");
            string userName = Console.ReadLine() ?? "";

            Console.Write("Enter user email: ");
            string email = Console.ReadLine() ?? "";

            User newUser = new User(nextUserId++, userName, email);
            Users.Add(newUser);

                SaveUsers();

                Console.WriteLine($"User '{newUser.Name}' added successfully with ID: {newUser.UserId}");

            }

        public void ViewUsers()
        {
            Console.WriteLine("=== Users ===");

            if (Users.Count == 0)
            {
                Console.WriteLine("No users available.");
                return;
            }

            foreach (var user in Users)
            {
                Console.WriteLine($"ID: {user.UserId} | Name: {user.Name} | Email: {user.Email}");
            }
        }

        public void DeleteUser()
            {
                Console.WriteLine("=== Delete User ===");

                if (Users.Count == 0)
                {
                    Console.WriteLine("No users to delete.");
                    return;
                }

                // Show list of users
                foreach (var user in Users)
                {
                    Console.WriteLine($"ID: {user.UserId} | Name: {user.Name} | Email: {user.Email}");
                }

                Console.Write("Enter User ID to delete: ");
                if (!int.TryParse(Console.ReadLine(), out int userId))
                {
                    Console.WriteLine("Invalid User ID.");
                    return;
                }

                var userToDelete = Users.FirstOrDefault(u => u.UserId == userId);
                if (userToDelete == null)
                {
                    Console.WriteLine("User not found.");
                    return;
                }

                // Check if this user is assigned to any task
                var assignedTasks = Tasks.Where(t => t.AssignedUserId == userId).ToList();
                if (assignedTasks.Any())
                {
                    Console.WriteLine("This user is assigned to one or more tasks. Reassign or delete those tasks first.");
                    return;
                }

                Console.Write($"Are you sure you want to delete user '{userToDelete.Name}'? (y/n): ");
                if (Console.ReadLine()?.ToLower() == "y")
                {
                    Users.Remove(userToDelete);
                    SaveUsers();
                    Console.WriteLine("User deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Cancelled.");
                }
            }


        public void AssignTask()
            {
                Console.WriteLine("=== Assign Task to User ===");

            if (Tasks.Count == 0 || Users.Count == 0)
            {
                Console.WriteLine("Tasks or users are missing.");
                return;
            }

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

            foreach (var user in Users)
            {
                Console.WriteLine(user);
            }

            Console.Write("Enter User ID to assign: ");
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
            Console.WriteLine($"Task '{taskToAssign.Title}' assigned to {userToAssign.Name}.");
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

            Console.WriteLine("Choose new status:");
            Console.WriteLine("1 = Backlog, 2 = In Progress, 3 = In Review, 4 = Completed");
            Console.Write("Your choice: ");
            string input = Console.ReadLine();

            string newStatus = input switch
            {
                "1" => "Backlog",
                "2" => "In Progress",
                "3" => "In Review",
                "4" => "Completed",
                _ => ""
            };

            if (string.IsNullOrEmpty(newStatus))
            {
                Console.WriteLine("Invalid status selection.");
                return;
            }

            taskToUpdate.Status = newStatus;
            Console.WriteLine($"Status updated to {newStatus}.");
        }

        // Add sample users and tasks
        public void AddSampleData()
        {
            // Add sample users
            Users.Add(new User(nextUserId++, "Alice", "alice@example.com"));
            Users.Add(new User(nextUserId++, "Bob", "bob@example.com"));
            Users.Add(new User(nextUserId++, "Charlie", "charlie@example.com"));

            // Add sample tasks
            Tasks.Add(new Task(nextTaskId++, "Design login screen", "Create a user-friendly login UI")
            {
                Priority = "High",
                DueDate = DateTime.Today.AddDays(5),
                Status = "In Progress",
                AssignedUserId = 1
            });

            Tasks.Add(new Task(nextTaskId++, "Fix registration bug", "Resolve issue with registration validation")
            {
                Priority = "Medium",
                DueDate = DateTime.Today.AddDays(7),
                Status = "Backlog",
                AssignedUserId = 2
            });

            Tasks.Add(new Task(nextTaskId++, "Write documentation", "Add usage guide for the WorkTrackr app")
            {
                Priority = "Low",
                DueDate = DateTime.Today.AddDays(10),
                Status = "In Review",
                AssignedUserId = 3
            });

            Console.WriteLine("Sample users and tasks added successfully.");
        }

        // Show dashboard using the Dashboard class
        public void ViewDashboard()
        {
            Dashboard dashboard = new Dashboard(Tasks, Users);

            Console.WriteLine(new string('*', 40));
            Console.WriteLine(new string('*', 40));
            dashboard.Show();
            Console.WriteLine(new string('*', 40));
        }

        
    }
}
