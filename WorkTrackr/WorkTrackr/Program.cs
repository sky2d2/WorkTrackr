using System;

namespace WorkTrackr
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== WorkTrackr Main Menu ===");
                Console.WriteLine("1. View All Tasks");
                Console.WriteLine("2. Create New Task");
                Console.WriteLine("3. Add New User");
                Console.WriteLine("4. Assign Task to User");
                Console.WriteLine("5. Update Task Status");
                Console.WriteLine("6. View Dashboard");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": taskManager.ViewAllTasks(); break;
                    case "2": taskManager.CreateTask(); break;
                    case "3": taskManager.AddUser(); break;
                    case "4": taskManager.AssignTask(); break;
                    case "5": taskManager.UpdateTaskStatus(); break;
                    case "6": taskManager.ViewDashboard(); break;
                    case "7": exit = true; break;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress Enter to return to Main Menu...");
                    Console.ReadLine();
                }
            }
        }
    }
}
