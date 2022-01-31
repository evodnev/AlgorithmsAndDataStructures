using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.PetShop
{
    internal class Cat: PetBase, IPet
    {
        public Cat(string name) : base(name) { }

        public override void DoVoice()
        {
            Console.WriteLine($"{Name} - мяу");
        }
    }
}
