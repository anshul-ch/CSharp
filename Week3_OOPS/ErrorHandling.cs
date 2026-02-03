namespace CSharp.Week3_OOPS
{
    /// <summary>
    /// This program use Error handling in Constructor Validation and Encapsulation
    /// </summary>
    
    public class Asociate
    {
        private int id;
        private string Name;
        private int Rank;
        public string errorMessage;

        /// <summary>
        /// Below are used to set the user values into the private fields
        /// </summary>
        public int Id1
        {
            set
            {
                if(value <= 0)
                {
                    errorMessage += "Id cannot be negative or null \n";
                }
                else
                {
                    id = value;
                }
            }
        }
        public string Name1
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    errorMessage += "Name cannot be empty\n";
                }
                else
                {
                   Name = value;
                }
            }
        }

        public int Rank1
        {
            set
            {
                if (value > 0)
                {
                    Rank = value;
                }
                else
                {
                    errorMessage += "Rank must be postive\n";
                }
            }
        }
    }

    public class ErrorHandling
    {

        /// <summary>
        /// Main function
        /// </summary>
        /// <param name="args"></param>
        public static void Main(String[] args)
        {
            Asociate asociate = new Asociate();
                asociate.Rank1 = 0;
                asociate.Name1 = "Amit";
                asociate.Id1 = -1;
                Console.WriteLine(asociate.errorMessage);
            
        }
    }
}
