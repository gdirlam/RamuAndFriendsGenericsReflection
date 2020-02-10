using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RamuAndFriendsGenericsReflection
{
    class Program
    {

        List<IAnimal> animals = new List<IAnimal>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Ramu and Friends!");

            var runner = new Program();

            runner.makeAnimals();
           // runner.makeNoise();
          //  runner.makeNoise2();
            runner.makeNoise3();
        }

        public void makeAnimals()
        {
            animals.Add(new cat());
            animals.Add(new dog());
        }

        private void makeNoise()
        {
            foreach (var animal in animals)
            {
                //Get Type get the system type from an object instance 
                var T = animal.GetType();

                MethodInfo[] myArrayMethodInfo = T.GetMethods(BindingFlags.Public | BindingFlags.Instance);
                foreach (var method in myArrayMethodInfo)
                {
                    //typeof gets the system type from an assembly
                    if (method.GetCustomAttributes(typeof(noiseAttribute), true).Any())
                    {
                        Console.WriteLine(method.Invoke(animal, null));
                    }
                }
            }
        }

        //

        private void makeNoise2() { 
            //Here we need to know the Type in advance, and pass to our function
            var noise = animals.Where(x => x.GetType() == typeof(cat)).FirstOrDefault().MakeNoice<cat>();

            Console.WriteLine(noise);
        }
        private void makeNoise3()
        {
            //Here we get the type on the fly
            var noise = animals.Where(x => x.GetType() == typeof(cat)).FirstOrDefault().MakeNoice();

            Console.WriteLine(noise);
            noise = animals.Where(x => x.GetType() == typeof(dog)).FirstOrDefault().MakeNoice();

            Console.WriteLine(noise);

        }

    }
}
