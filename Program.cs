namespace Task_division_On_Team
{
    internal class Program
    {
        private static List<string> Tasks;
        private static List<string> User;
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
        static void Task_division()
        {
            while (User.Count!=0||Tasks.Count!=0)
            {
                string UserName = User[new Random().Next(User.Count==1?0:1, User.Count)];
                string TaskName = Tasks[new Random().Next(Tasks.Count == 1 ? 0 : 1, Tasks.Count)];
                User.Remove(UserName);
                Tasks.Remove(TaskName);
                Console.WriteLine($"Task : {TaskName} \t Name : {UserName}");
                Console.WriteLine("Enter For Next");
                Console.ReadLine();
            }
        }
    }
}



