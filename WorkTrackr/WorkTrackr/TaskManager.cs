using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkTrackr
{
    public class TaskManager
    {
        public List<Task> Tasks { get; private set; }
        public List<User> Users { get; private set; }

        public TaskManager()
        {
            Tasks = new List<Task>();
            Users = new List<User>();
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
            Console.WriteLine("Task added successfully.");
        }

        public void AddUser(User user)
        {
            Users.Add(user);
            Console.WriteLine("User added successfully.");
        }

        public void AssignTask(int taskId, int userId)
        {
            var task = Tasks.FirstOrDefault(t => t.TaskId == taskId);
            var user = Users.FirstOrDefault(u => u.UserId == userId);

            if (task != null && user != null)
            {
                task.AssignedUserId = userId;
                Console.WriteLine($"Task '{task.Title}' assigned to user '{user.Name}'.");
            }
            else
            {
                Console.WriteLine("Invalid Task ID or User ID.");
            }
        }

        public void UpdateTaskStatus(int taskId, string newStatus)
        {
            var task = Tasks.FirstOrDefault(t => t.TaskId == taskId);
            if (task != null)
            {
                task.Status = newStatus;
                Console.WriteLine("Task status updated successfully.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        public void ViewAllTasks()
        {
            if (Tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            Console.WriteLine("All Tasks:");
            foreach (var task in Tasks)
            {
                var user = Users.FirstOrDefault(u => u.UserId == task.AssignedUserId)?.Name ?? "Unassigned";
                Console.WriteLine($"ID: {task.TaskId}, Title: {task.Title}, Status: {task.Status}, Priority: {task.Priority}, Due: {task.DueDate.ToShortDateString()}, Assigned To: {user}");
            }
        }

        public void ViewDashboard()
        {
            var dashboard = new Dashboard(Tasks, Users);
            dashboard.Show();
        }

        public void ViewTasksByUser(int userId)
        {
            var user = Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            var userTasks = Tasks.Where(t => t.AssignedUserId == userId).ToList();

            if (userTasks.Count == 0)
            {
                Console.WriteLine($"No tasks assigned to {user.Name}.");
                return;
            }

            Console.WriteLine($"Tasks assigned to {user.Name}:");
            foreach (var task in userTasks)
            {
                Console.WriteLine($"ID: {task.TaskId}, Title: {task.Title}, Status: {task.Status}, Priority: {task.Priority}, Due: {task.DueDate.ToShortDateString()}");
            }
        }

        public void ViewOverdueTasks()
        {
            var overdueTasks = Tasks
                .Where(t => t.DueDate < DateTime.Today && t.Status != "Completed")
                .ToList();

            if (overdueTasks.Count == 0)
            {
                Console.WriteLine("No overdue tasks.");
                return;
            }

            Console.WriteLine("Overdue Tasks:");
            foreach (var task in overdueTasks)
            {
                var user = Users.FirstOrDefault(u => u.UserId == task.AssignedUserId)?.Name ?? "Unassigned";
                Console.WriteLine($"ID: {task.TaskId}, Title: {task.Title}, Due: {task.DueDate.ToShortDateString()}, Assigned To: {user}");
            }
        }

        public void ViewUpcomingTasks()
        {
            var upcomingTasks = Tasks
                .Where(t => t.DueDate >= DateTime.Today && t.DueDate <= DateTime.Today.AddDays(7))
                .ToList();

            if (upcomingTasks.Count == 0)
            {
                Console.WriteLine("No upcoming tasks in the next 7 days.");
                return;
            }

            Console.WriteLine("Upcoming Tasks (Next 7 Days):");
            foreach (var task in upcomingTasks)
            {
                var user = Users.FirstOrDefault(u => u.UserId == task.AssignedUserId)?.Name ?? "Unassigned";
                Console.WriteLine($"ID: {task.TaskId}, Title: {task.Title}, Due: {task.DueDate.ToShortDateString()}, Assigned To: {user}");
            }
        }
    }
}
