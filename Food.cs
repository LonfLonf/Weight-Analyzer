using System;
using CsvHelper.Configuration;

namespace FoodBase
{
    class Food
    {
        public int Id { get; set; }
        public string NameOfFood { get; set; }
        public float Humidity { get; set; }
        public int Energy { get; set; }
        public float Protein { get; set; }
        public float Lipids { get; set; }
        public int Cholesterol { get; set; }
        public int Calcium { get; set; }
        public float Iron { get; set; }
        public int Sodium { get; set; }
        public int Potassium { get; set; }
    }

    class FoodMap : ClassMap<Food>
    {
        public FoodMap()
        {   
            Map(m => m.Id).Name("Id");
            Map(m => m.NameOfFood).Name("Alimento");
            Map(m => m.Humidity).Name("Umidade");
            Map(m => m.Energy).Name("Energia"); 
            Map(m => m.Protein).Name("Proteína");
            Map(m => m.Lipids).Name("Lipídeos");
            Map(m => m.Cholesterol).Name("Colesterol");
            Map(m => m.Calcium).Name("Cálcio");
            Map(m => m.Iron).Name("Ferro");
            Map(m => m.Sodium).Name("Sódio");
            Map(m => m.Potassium).Name("Potássio");
        }
    }

    // Testando a classe Food
}