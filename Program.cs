using System.Threading.Tasks;
using System;
using System.Diagnostics.Metrics;
using System.Net.Mime;

namespace Task_division_On_Team
{
    internal class Program
    {
        
        private static List<string> Tasks;
        private static List<string> User;
       static  int Counter = 1;
        static void Main(string[] args)
        {
            Load();
            var menu = new Dictionary<string, Action> {
                { "Task_division", Task_division },
                { "ListTask", ListTask },
                { "RemoveTask", RemoveTask },

                { "AddTask", AddTask },
                { "RemoveUser", RemoveUser },
                { "ListUser", ListUser },
                { "AddUser", AddUser },
                { "AboutUs", AboutUs },
                { "Load", Load },
     
            };

            ConsoleDesign.ShowMenu("Main Menu", menu);
        }
        static void Load()
        {
            Tasks = new List<string>(){"Task1","Task2","Task3", "Task4", "Task5", "Task6","Task7" };
            User = new List<string>(){"abolfazl","mehdi","tiam","salamat","faraji","soheil","amirhosein"};
        }
        static void AboutUs()
        {
            Console.WriteLine("Create by abolfazl");
        }

        static void AddUser()
        {
            Console.Write("Please Enter Name :");
            string input = Console.ReadLine() ?? "user";
            User.Add(input);
        }

        static void RemoveUser()
        {
            Console.Write("Please Enter Name :");
            string input = Console.ReadLine() ?? "user";
            if (User.Any(a => a.Equals(input)))
                User.Remove(input);

        }
        static void ListUser()
        {
            foreach (var item in User)
            {
                Console.WriteLine($"Task Name: {item}");
            }
        }
        static void AddTask()
        {
            Console.Write("Please Enter Task Name :");
            string input = Console.ReadLine() ?? "user";
            User.Add(input);
        }

        static void RemoveTask()
        {
            Console.Write("Please Enter Task Name :");
            string input = Console.ReadLine() ?? "user";
            if (Tasks.Any(a => a.Equals(input)))
                Tasks.Remove(input);
        }
        static void ListTask()
        {
            foreach (var item in Tasks)
            {
                Console.WriteLine($"Task Name: {item}");
            }
        }

        static int GetRandomDigit(int length)
        {
            int digit = 0;
            for (int i = 0; i < new Random().Next(7); i++)
            {
                digit = new Random().Next(length);
            }

            return digit;
        }

        static void ExportToFile(string text)
        {
            // مسیر فایل مورد نظر
            string filePath = "../../../log.txt";

            // استفاده از using برای مدیریت منابع
            File.AppendAllText(filePath, text+"\n");
        }
        static void Task_division()
        {
            Console.Clear();
            int i = 1;

            ExportToFile($"{DateTime.Now}------------------------------------");
            ExportToFile($"-------------{Counter}-------------------");
            while (User.Count > 0 || Tasks.Count > 0)
            {
                // Select a random user if the list is not empty
                string userName = User.Count > 0
                    ? User[GetRandomDigit(User.Count)]
                    : "No User Left";

                // Select a random task if the list is not empty
                string taskName = Tasks.Count > 0
                ? Tasks[GetRandomDigit(Tasks.Count)]
                    : "No Task Left";

                // Remove the selected user and task from their respective lists
                if (User.Count > 0) User.Remove(userName);
                if (Tasks.Count > 0) Tasks.Remove(taskName);

                // Display the result
                var Resualt=$"{i}- Task: {taskName} \t Name: {userName}";
                ConsoleDesign.ShowMessage(Resualt);
                ExportToFile(Resualt);
       
                ConsoleDesign.ShowMessage("Press Enter for Next...",ConsoleColor.DarkYellow);
                i++;
            }
            ExportToFile($"{DateTime.Now}------------------------------------");
            Counter++;
            Load();
        }
    }
}



