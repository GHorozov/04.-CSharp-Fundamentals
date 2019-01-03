namespace _11.Animals
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();
            string input;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    var animalType = input;
                    var info = Console.ReadLine().Split();
                    var name = info[0];
                    var age = int.Parse(info[1]);
                    string gender = null;
                    if(info.Length == 3)
                    {
                        gender = info[2];
                        //throw new ArgumentException("Invalid input!");
                    }

                    if(animalType == "Cat")
                    {
                        var cat = new Cat(name, age, gender);
                        animals.Add(cat);
                    }
                    else if (animalType == "Dog")
                    {
                        var dog = new Dog(name, age, gender);
                        animals.Add(dog);
                    }
                    else if(animalType == "Frog")
                    {
                        var frog = new Frog(name,age,gender);
                        animals.Add(frog);
                    }
                    else if (animalType == "Kitten")
                    {
                        var kitten = new Kitten(name,age);
                        animals.Add(kitten);

                    }
                    else if(animalType == "Tomcat")
                    {
                        var tomcat = new Tomcat(name,age);
                        animals.Add(tomcat);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
