using FoodBase;
using CsvHelper;
using System.Globalization;

namespace DietBase
{
    class Diet
    {
        List<Food> foods { get; set; } = new List<Food>();

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
    }
}