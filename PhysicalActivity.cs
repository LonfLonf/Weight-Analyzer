using System;

namespace Activities
{
    class PhysicalActivity
    {
        public string[] Activities { get; set; } = {"Musculação - Intensidade baixa (repetições 8-15)",
        "Musculação - Intensidade alta (levantamento de peso)", "Ciclismo - Lazer, intensidade baixa/moderada",
        "Ciclismo - Competição em montanha", "Corrida - 13 minutos por milha (~7,24 km/h)",
        "Corrida - 12 minutos por milha (~8,05 km/h)", "Corrida - 9 minutos por milha (~10,78 km/h)",
        "Natação - Livre, intensidade leve", "Natação - Livre, intensidade moderada",
        "Natação - Livre, intensidade vigorosa", "Futebol - Jogo/competição", "Basquete - Treino geral",
        "Vôlei -  Areia, esforço moderado", "Hidroginástica - Moderado", "Pilates - Moderado",
        "Yoga - Moderado", "Dança - Ensaio ou aula(Balé/Jazz)", "Alogamento - Baixa Intensidade",
        "Atividades Domésticas - Cozinhar, lavar louças, limpar cozinha"};
        public float[] MET { get; set; } = { 3.5f, 6.0f, 4.0f, 16.0f, 6.0f, 8.3f, 10.5f,
        6.0f, 8.0f, 10.0f, 8.0f, 6.5f, 8.0f, 5.5f, 3.0f, 2.5f, 2.3f, 3.3f };

        float calculateMET(int choice, float kg, int minutes)
        {
            float kcalPerMinute = MET[choice] * kg * 0.0175f;
            return kcalPerMinute * minutes;
        }

        void showMetTable()
        {
            int limit = Math.Min(Activities.Length, MET.Length);
            for (int i = 0; i < limit; i++)
            {
                Console.WriteLine($"{i}. {Activities[i]} - {MET[i]} MET");
            }
        }
    }
}