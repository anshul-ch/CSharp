namespace CSharp.Week3_OOPS
{
    /// <summary>
    /// THis program validates if the parameters in the constructor are valid or not.
    /// </summary>
    public class ConstructorValidate
    {
        /// <summary>
        /// This class contains the properties as well as the exception handling for invalid argumnet.
        /// </summary>
        public int id { get; set; }
        public string name { get; set; }

        public ConstructorValidate(int id, string name)
        {
            this.id = id;
            if (name.ToLower().Contains("apple"))
            {
                throw new ArgumentException("Don't give Apple as a name");
            }
            this.name = name;
        }
        public void Display()
        {
            Console.WriteLine(name, id);
        }
        
    }

    /// <summary>
    /// Main Class 
    /// </summary>
    public class ConstructorValidation
    {
        public static void Main(String[] args)
        {
            try
            {
                ConstructorValidate validation = new ConstructorValidate(101, "Apple");
                ConstructorValidate validation2 = new ConstructorValidate(102,"Mango");
                validation.Display();
                validation2.Display();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
