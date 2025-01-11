using FoodBase;
using CsvHelper;
using System.Globalization;

namespace DietBase
{
    class Diet
    {
        List<Food> foods { get; set; } = new List<Food>();
        List<Food> Breakfast { get; set; } = new List<Food>();
        List<Food> Lunch { get; set; } = new List<Food>();
        List<Food> Snack { get; set; } = new List<Food>();
        List<Food> Dinner { get; set; } = new List<Food>();
        float WaterGoal { get; set; } = 0.0f;
        float WaterMissing { get; set; } = 0.0f;

        public void SetWaterGoal(float weight)
        {
            WaterGoal = weight * 35.0f;
        }

        public void SetWaterMissing(float waterDrunk)
        {
            WaterMissing = WaterGoal - waterDrunk;
        }

        public List<Food> LoadFoodsFromCsv(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File Not Found");
                return new List<Food>();
            }

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Context.RegisterClassMap<FoodMap>();

            var foods = csv.GetRecords<Food>().ToList();

            foreach (var food in foods)
            {
                Console.WriteLine($"Id: {food.Id} - Alimento: {food.NameOfFood} - Energia: {food.Energy} kcal");
            }

            return foods;
        }

        public Food findFoodById(int id, List<Food> foods)
        {
            var food = foods.Find(food => food.Id == id);
            if (food == null)
            {
                throw new KeyNotFoundException($"Food with ID {id} not found " + id);
            }
            return food;
        }

        public void AddFoodToMeal(List<Food> meal, List<Food> foods, int id, int quantity)
        {
            if (quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than zero.");
                return;
            }

            var food = findFoodById(id, foods);
            if (food == null)
            {
                Console.WriteLine("Food not found.");
                return;
            }

            var foodCopy = new Food
            {
                Id = food.Id,
                NameOfFood = food.NameOfFood,
                Energy = food.Energy,
                Protein = food.Protein,
                Lipids = food.Lipids,
                Cholesterol = food.Cholesterol,
                Quantity = quantity
            };
            meal.Add(foodCopy);
        }


        public void removeFoodFromMeal(int id, List<Food> meal, List<Food> foods)
        {
            var food = findFoodById(id, foods);
            meal.Remove(food);
        }

        public void SumAllMeals(
            List<Food> breakfast, List<Food> lunch, List<Food> snack, List<Food> dinner,
            out float totalCalories, out float totalProtein, out float totalLipids, out float totalCholesterol)
        {
            totalCalories = (breakfast?.Sum(f => f.Energy * f.Quantity) ?? 0.0f) +
                            (lunch?.Sum(f => f.Energy * f.Quantity) ?? 0.0f) +
                            (snack?.Sum(f => f.Energy * f.Quantity) ?? 0.0f) +
                            (dinner?.Sum(f => f.Energy * f.Quantity) ?? 0.0f);

            totalProtein = (breakfast?.Sum(f => f.Protein * f.Quantity) ?? 0.0f) +
                           (lunch?.Sum(f => f.Protein * f.Quantity) ?? 0.0f) +
                           (snack?.Sum(f => f.Protein * f.Quantity) ?? 0.0f) +
                           (dinner?.Sum(f => f.Protein * f.Quantity) ?? 0.0f);

            totalLipids = (breakfast?.Sum(f => f.Lipids * f.Quantity) ?? 0.0f) +
                          (lunch?.Sum(f => f.Lipids * f.Quantity) ?? 0.0f) +
                          (snack?.Sum(f => f.Lipids * f.Quantity) ?? 0.0f) +
                          (dinner?.Sum(f => f.Lipids * f.Quantity) ?? 0.0f);

            totalCholesterol = (breakfast?.Sum(f => f.Cholesterol * f.Quantity) ?? 0.0f) +
                               (lunch?.Sum(f => f.Cholesterol * f.Quantity) ?? 0.0f) +
                               (snack?.Sum(f => f.Cholesterol * f.Quantity) ?? 0.0f) +
                               (dinner?.Sum(f => f.Cholesterol * f.Quantity) ?? 0.0f);
        }

        public void generateMealReport(List<Food> meal)
        {
            float totalEnergy = 0.0f;
            float totalProtein = 0.0f;
            float totalLipids = 0.0f;
            float totalCholesterol = 0.0f;

            foreach (var food in meal)
            {
                totalEnergy += food.Energy * food.Quantity;
                totalProtein += food.Protein * food.Quantity;
                totalLipids += food.Lipids * food.Quantity;
                totalCholesterol += food.Cholesterol * food.Quantity;
            }

            Console.WriteLine($"Total Energy: {totalEnergy} kcal");
            Console.WriteLine($"Total Protein: {totalProtein} g");
            Console.WriteLine($"Total Lipids: {totalLipids} g");
            Console.WriteLine($"Total Cholesterol: {totalCholesterol} mg");
        }
    }
}