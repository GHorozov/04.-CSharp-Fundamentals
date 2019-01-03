namespace _10.MordorsCruelPlan
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var inputFoods = Console.ReadLine().Split();
            var happinessPoints = 0;
            foreach (var food in inputFoods)
            {
                var foodFactory = new FoodFactory(food);
                happinessPoints += foodFactory.GetFoodPoints();
            }

            var moodFactory = new MoodFactory(happinessPoints);
            Console.WriteLine(happinessPoints);
            Console.WriteLine(moodFactory.GetMood());
        }
    }
}
