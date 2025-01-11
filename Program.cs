using CharacterLogic;
using Activities;
using People;
using DietBase;
using FoodBase;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Prototipo dessa bomba de APP");

            Console.Write("Digite seu nome: ");
            string name = Console.ReadLine();

            Console.Write("Digite seu sexo (M/F): ");
            string sex = Console.ReadLine();

            Console.Write("Digite sua idade: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Digite seu peso: ");
            float weight = float.Parse(Console.ReadLine());

            Console.Write("Digite sua altura: ");
            float height = float.Parse(Console.ReadLine());

            Person person = new Person(name, sex, age, weight, height);
            Character character = new Character(person);

            person.showStatus();
            character.drawDummy();

            PhysicalActivity activity = new PhysicalActivity();
            activity.showMetTable();
            Console.WriteLine("Choice an activity: ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the duration in minutes: ");
            int minutes = int.Parse(Console.ReadLine());

            float kcal = activity.calculteMET(choice, weight, minutes);
            Console.WriteLine("You burned " + kcal + " kcal");

            Diet dt = new Diet();
            string filePath = "C:\\Users\\firey\\Downloads\\Planilha sem título - Página1.csv";
            List<Food> foods = dt.LoadFoodsFromCsv(filePath);

            List<Food> Breakfast = new List<Food>();
            List<Food> Lunch = new List<Food>();
            List<Food> Snack = new List<Food>();
            List<Food> Dinner = new List<Food>();

            while (true)
            {
                Console.WriteLine("1. Choice a Meal");
                Console.WriteLine("2. Show Meals");
                Console.WriteLine("3. Remove Food by ID");
                Console.WriteLine("4. Exit");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        dt.AddFoodToMeal(Breakfast, foods, 1, 2);
                        dt.AddFoodToMeal(Lunch, foods, 2, 2);
                        dt.AddFoodToMeal(Snack, foods, 3, 2);
                        dt.AddFoodToMeal(Dinner, foods, 4, 2);
                        break;
                    case 2:
                        dt.generateMealReport(Breakfast);
                        break;
                    case 3:
                        dt.removeFoodFromMeal(1, Breakfast, foods);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Deu Ruim ai pai");
                        break;
                }
            }
        }
    }
}
