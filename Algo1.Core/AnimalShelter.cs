using System.Collections.Generic;
using System.Linq;


namespace Algo1.Core
{
    public class AnimalShelter
    {
        private LinkedList<Animal> _animals = new LinkedList<Animal>();
        public void Enqueue(Animal animal)
        {
            _animals.AddLast(animal);
        }

        public Dog DequeueDog()
        {
            var current = _animals.First;

            while (current != null && !(current.Value is Dog))
            {
                current = current.Next;
            }

            if (current.Value is Dog)
            {
                current.List.Remove(current);

                return current.Value as Dog;
            }
            else
            {
                return null;
            }
        } 

        public Cat DequeueCat()
        {
            var current = _animals.First;

            while (current != null && !(current.Value is Cat))
            {
                current = current.Next;
            }
            if (current.Value is Cat)
            {
                current.List.Remove(current);

                return current.Value as Cat;
            }
            else
            {
                return null;
            }
        }

        public Animal DequeueAny()
        {
            var first = _animals.First();

            _animals.RemoveFirst();
            return first;
        }
    }

    public class Animal
    {
        public string Name { get; set; }
    }

    public class Dog : Animal
    {
    }

    public class Cat: Animal
    {

    }

}
