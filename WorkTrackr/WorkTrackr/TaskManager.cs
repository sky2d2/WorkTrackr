using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkTrackr
{
    public class TaskManager
    {
        public List<Task> Tasks { get; set; } = new List<Task>();
        public List<User> Users { get; set; } = new List<User>();

        public void CreateTask()
        {
            Console.Write("Enter Task Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Task Description: ");
            string description = Console.ReadLine();

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
                Console.Write("Enter Due Date (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out dueDate))
                {
                    if (dueDate < DateTime.Today)
                    {
                        Console.WriteLine("Invalid entry. Due Date cannot be in the past.");
                        continue;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid format. Try again.");
                }
            }

            Task newTask = new Task
            {
                Title = title,
                Description = description,
                Priority = priority,
                DueDate = dueDate,
                Status = "Backlog"
            };

            Tasks.Add(newTask);
            Console.WriteLine("Task created successfully!");
        }


        public void ViewAllTasks()
        {
            if (Tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.\n");
                return;
            }

            Console.WriteLine("All Tasks:\n");
            foreach (var task in Tasks)
            {
                Console.WriteLine($"Title: {task.Title}");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine($"Priority: {task.Priority}");
                Console.WriteLine($"Due Date: {task.DueDate:yyyy-MM-dd}");
                Console.WriteLine($"Status: {task.Status}");
                Console.WriteLine("-------------------------------------------");
            }
        }

        // TODO: Add methods here later:
        // AddUser()
        // AssignTask()
        // UpdateTaskStatus()
        // ViewDashboard()
    }
}
