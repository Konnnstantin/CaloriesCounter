using CaloriesCount.BL.Controller;
using CaloriesCount.BL.Model;
using System.Globalization;
{
  
    {
       /* var culture = CultureInfo.GetCultureInfo("ru-ru");
       var resourceManger = new ResourceManager("CodeBlogFitness.CMD.Languages.Messages", typeof(Program).Assembly);

        Console.WriteLine(resourceManger.GetString("Hello", culture));*/
       ///TODO: Реализовать локализацию

        Console.WriteLine("Введите свое имя");
        var name = Console.ReadLine();

        var userController = new UserController(name);
        var eatingcontroller = new EatingController(userController.CurrentUser);
        var exerciseController = new ExerciesController(userController.CurrentUser);

        if (userController.IsNewUser)
        {
            Console.WriteLine("Введите пол");
            var gender = Console.ReadLine();
            var birthDate = ParseDatetime("Дата рождения");
            var weight = ParseDouble("Вес");
            var height = ParseDouble("Рост");
            userController.SetNewUserData(gender, birthDate, weight, height);
        }

        Console.WriteLine(userController.CurrentUser);
        while (true)
        {
            Console.WriteLine("Нажмите Е,чтобы ввести прием пищи");
            Console.WriteLine("Нажмите А, чтобы ввести упражнение");
            Console.WriteLine("Нажмите Q, чтобы выйти");
            var key = Console.ReadKey();
            Console.WriteLine();
            switch (key.Key)
            {
                case ConsoleKey.E:
                    var foods = EnterEating();
                    eatingcontroller.Add(foods.Food, foods.Weight);
                    foreach (var item in eatingcontroller.Eating.Foods)
                    {
                        Console.WriteLine($"{item.Key} , {item.Value}");
                    }
                    break;
                case ConsoleKey.A:
                    var exe = EnterExercise();
                    exerciseController.Add(exe.Activity, exe.begin, exe.end);
                    foreach (var item in exerciseController.Exercises)
                    {
                        Console.WriteLine($"{item.Activity} с {item.Start.ToShortTimeString()} до {item.End.ToShortTimeString()}");
                    }
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
            }
        }
    }

     static (DateTime begin, DateTime end, Activity Activity) EnterExercise()
    {
        Console.WriteLine("Введите название упражнения");
        var name = Console.ReadLine();
        var start = ParseDatetime("Начало упражнения");
        var end = ParseDatetime("Конец упражнения");
        var caloriesPerMinute = ParseDouble("Калории в минуту");
        var activity = new Activity(name, caloriesPerMinute);

        return (start, end, activity);
    }

     static (Food Food, double Weight) EnterEating()
    {
        Console.WriteLine("Введите имя продукта");
        var food = Console.ReadLine();

        var weight = ParseDouble("Вес порции");
        var prots = ParseDouble("Белки");
        var fats = ParseDouble("Жиры");
        var carbs = ParseDouble("Углеводы");
        var calories = ParseDouble("Калории");
        var product = new Food(food, carbs, prots, fats, calories);



        return (product, weight);
    }

     static DateTime ParseDatetime(string value)
    {
        DateTime date;
        while (true)
        {
            Console.WriteLine($"Введите {value} 00.00.0000");

            if (DateTime.TryParse(Console.ReadLine(), out date))
            {
                break;
            }
            else
            {
                Console.WriteLine($"Не верный формат{value}");
            }
        }
        return date;
    }
     static double ParseDouble(string name)
    {
        while (true)
        {
            Console.WriteLine($"Введите {name}");
            if (Double.TryParse(Console.ReadLine(), out double value))
            {
                return value;
            }
            else
            {
                Console.WriteLine("Не верный формат");
            }
        }
    }
}