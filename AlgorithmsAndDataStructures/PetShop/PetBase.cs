namespace AlgorithmsAndDataStructures.PetShop
{
    internal abstract class PetBase
    {
        public string Name { get; private set; }

        public PetBase(string name)
        {
            Name = name;
        }

        public abstract void DoVoice();
    }
}