using System;

namespace WorkTrackr
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();
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
                    case "1":
                        manager.ViewAllTasks();
                        break;
                    case "2":
                        manager.CreateTask();
                        break;
                    case "3":
                        // manager.AddUser(); → implement later
                        break;
                    case "4":
                        // manager.AssignTask(); → implement later
                        break;
                    case "5":
                        // manager.UpdateTaskStatus(); → implement later
                        break;
                    case "6":
                        // manager.ViewDashboard(); → implement later
                        break;
                    case "7":
                        exit = true;
                        Console.WriteLine("Exiting WorkTrackr...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
            }
        }
    }
}
