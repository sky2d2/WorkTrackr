using System;

namespace WorkTrackr
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            taskManager.LoadUsers();  // Load saved users and tasks
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
                Console.WriteLine("6. Edit Task");              // ⬅ NEW
                Console.WriteLine("7. Delete Task");            // ⬅ NEW
                Console.WriteLine("8. View Dashboard");
                Console.WriteLine("9. View Users");
                Console.WriteLine("10. Delete User");
                Console.WriteLine("11. Exit");
                Console.Write("Select an option (1-11): ");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": taskManager.ViewAllTasks(); break;
                    case "2": taskManager.CreateTask(); break;
                    case "3": taskManager.AddUser(); break;
                    case "4": taskManager.AssignTask(); break;
                    case "5": taskManager.UpdateTaskStatus(); break;
                    case "6": taskManager.EditTask(); break;       // ⬅ NEW
                    case "7": taskManager.DeleteTask(); break;     // ⬅ NEW
                    case "8": taskManager.ViewDashboard(); break;
                    case "9": taskManager.ViewUsers(); break;
                    case "10": taskManager.DeleteUser(); break;
                    case "11": exit = true; break;

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
