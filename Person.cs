using System;

namespace People
{
    public class Person
    {
        public string Name { get; private set; }
        public string Sex { get; private set; }
        public int Age { get; private set; }
        public float Weight { get; private set; }
        public float Height { get; private set; }
        private float measureStomach { get; set; }
        private float measureArm { get; set; }
        private float measureLeg { get; set; }
        private float TMB { get; set; }

        public Person(string name, string sex, int age, float weight, float height)
        {
            Name = name;
            Sex = sex;
            Age = age;
            Weight = weight;
            Height = height;
        }

        float calculateTMB(string sex, int age, float weight, float height)
        {
            float TMB = 0.0f;
            if (sex == "M")
            {
                TMB = 88.362f + (13.397f * weight) + (4.799f * height) - (5.677f * age);
            }
            else 
            {
                TMB = 447.593f + (9.247f * weight) + (3.098f * height) - (4.330f * age);
            }
            return TMB;
        }

        static void howManyKcal()
        {
            Console.WriteLine("To eliminate 1KG fat you need eliminate 7.000Kcal.");
        }

        void showStatus()
        {
            Console.WriteLine("Weight: " + Person.Weight);
        }
    }
}