using System;

namespace WorkTrackr
{
    class Program
    {
        static void Main(string[] args)
        {
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
                        // TODO: View All Tasks
                        break;
                    case "2":
                        // TODO: Create New Task
                        break;
                    case "3":
                        // TODO: Add New User
                        break;
                    case "4":
                        // TODO: Assign Task to User
                        break;
                    case "5":
                        // TODO: Update Task Status
                        break;
                    case "6":
                        // TODO: View Dashboard
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
