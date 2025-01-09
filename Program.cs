using DietBase;
using FoodBase;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            Diet dt = new Diet();
            string filePath = "C:\\Users\\firey\\Downloads\\Planilha sem título - Página1.csv";
            List<Food> foods = dt.LoadFoodsFromCsv(filePath);
        }
    }
}
