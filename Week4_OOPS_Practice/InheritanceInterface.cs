namespace CSharp.Week4_OOPS_Practice
{
    /// <summary>
    /// This program implements the usage of interface to implemetn multiple inheritance.
    /// </summary>
    interface SingingBird
    {
        void BirdSings();
        void BirdDance();
    }
    interface FlyingBird
    {
        void BirdFlys();
        void BirdWalk();
    }

    class Bird : SingingBird, FlyingBird
    {
        public void BirdSings()
        {
            Console.WriteLine("This bird Sings");
        }
        public void BirdDance()
        {
            Console.WriteLine("Bird Dance");
        }
        public void BirdWalk()
        {
            Console.WriteLine("Bird Walks");
        }
        public void BirdFlys()
        {
            Console.WriteLine("This bird flys");
        }
    }
        public class InheritanceInterface
        {
            public static void Main(String[] args)
            {
                Bird bird = new Bird();
                ((FlyingBird)bird).BirdFlys();
                ((FlyingBird)bird).BirdWalk();
                ((SingingBird)bird).BirdDance();
                ((SingingBird)bird).BirdSings();
            }
        }
}
