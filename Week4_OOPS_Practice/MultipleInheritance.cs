namespace CSharp.Week4_OOPS_Practice
{
    /// <summary>
    /// Uses interface to implement multiple inheritance with methods having same property.
    /// </summary>

    public interface Vegday
    {
        void RequiredItemsVeg();
        public void Taste();
    }

    public interface NonVegday
    {
        void RequiredItemsNonVeg();
        void Taste();
    }

    public class Eating : Vegday, NonVegday
    {
        public void RequiredItemsVeg() 
        {
            Console.WriteLine("It is a veg day");
        }
         
        
        public void RequiredItemsNonVeg() 
        {
            Console.WriteLine("It is a non veg day");
        }

        void Vegday.Taste()
        {
            Console.WriteLine("Veg");
        }
        void NonVegday.Taste()
        {
            Console.WriteLine("Nonveg");
        }
    }
    public class MultipleInheritance
    {
        public static void Main(string[] args)
        {
            Eating eating = new Eating();
            ((Vegday) eating).Taste();
            ((NonVegday)eating).Taste();
            
        }
    }
}
