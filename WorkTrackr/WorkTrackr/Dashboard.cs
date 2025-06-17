using System;
using System.Linq;
using System.Collections.Generic;

namespace WorkTrackr
{
    public class Dashboard
    {
        private readonly List<Task> _tasks;
        private readonly List<User> _users;

        public Dashboard(List<Task> tasks, List<User> users)
        {
            _tasks = tasks;
            _users = users;
        }

        public void Show()
        {
            Console.WriteLine("=== Dashboard ===");

            if (_tasks.Count == 0)
            {
                Console.WriteLine("No tasks to show.");
                return;
            }

            // Total Tasks
            Console.WriteLine($"\nTotal Tasks: {_tasks.Count}");

            // Tasks by Status
            var statusGroups = _tasks.GroupBy(t => t.Status);
            Console.WriteLine("\nTasks by Status:");
            foreach (var group in statusGroups)
            {
                Console.WriteLine($"{group.Key}: {group.Count()}");
            }

            // Tasks by Priority
            var priorityGroups = _tasks.GroupBy(t => t.Priority);
            Console.WriteLine("\nTasks by Priority:");
            foreach (var group in priorityGroups)
            {
                Console.WriteLine($"{group.Key}: {group.Count()}");
            }

            // Overdue Tasks
            var overdue = _tasks.Where(t => t.DueDate < DateTime.Today && t.Status != "Completed").ToList();
            Console.WriteLine($"\nOverdue Tasks: {overdue.Count}");
            foreach (var task in overdue)
            {
                Console.WriteLine($"- {task.Title} (Due: {task.DueDate.ToShortDateString()})");
            }

            // Upcoming Tasks (Next 7 Days)
            var upcoming = _tasks
                .Where(t => t.DueDate >= DateTime.Today && t.DueDate <= DateTime.Today.AddDays(7))
                .ToList();
            Console.WriteLine($"\nUpcoming Tasks (Next 7 Days): {upcoming.Count}");
            foreach (var task in upcoming)
            {
                Console.WriteLine($"- {task.Title} (Due: {task.DueDate.ToShortDateString()})");
            }

            // Tasks by User
            var taskUserGroups = _tasks.GroupBy(t =>
                _users.FirstOrDefault(u => u.UserId == t.AssignedUserId)?.Name ?? "Unassigned");
            Console.WriteLine("\nTasks by User:");
            foreach (var group in taskUserGroups)
            {
                Console.WriteLine($"{group.Key}: {group.Count()}");
            }
        }
    }
}
