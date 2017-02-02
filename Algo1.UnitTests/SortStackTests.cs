using Algo1.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.UnitTests
{
    [TestClass]
    public class SortStackTests
    {
        [TestMethod]
        public void SortStackTest()
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(4);
            stack.Push(2);
            stack.Push(3);
            stack.Push(5);
            stack.Push(1);

            StackSorter.SortStack(stack);

            Assert.IsTrue(stack.Pop() == 1);
            Assert.IsTrue(stack.Pop() == 2);
            Assert.IsTrue(stack.Pop() == 3);
            Assert.IsTrue(stack.Pop() == 4);
            Assert.IsTrue(stack.Pop() == 5);
        }

        [TestMethod]
        public void AnimalShelterTests()

        {
            AnimalShelter shelter = new AnimalShelter();

            shelter.Enqueue(new Dog { Name = "Spike" });
            shelter.Enqueue(new Cat { Name = "Sonusha" });
            shelter.Enqueue(new Cat { Name = "Whiskas" });
            shelter.Enqueue(new Dog { Name = "Pesko" });

            var cat = shelter.DequeueCat();

            Assert.IsTrue(cat.Name == "Sonusha");
            var animal2 = shelter.DequeueAny();
            Assert.IsTrue(animal2.Name == "Spike");
            var an3 = shelter.DequeueDog();
            Assert.IsTrue(an3.Name == "Pesko");
            var an34= shelter.DequeueAny();
            Assert.IsTrue(an34.Name == "Whiskas");

        }
    }
}
