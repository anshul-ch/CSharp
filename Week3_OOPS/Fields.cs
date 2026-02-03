namespace CSharp.Week3_OOPS
{
    /// <summary>
    /// This program implements the concept of Fields and how to assign values to them
    /// </summary>
    public class FieldsInputs
    {
        private int id;

        //public int Id1 { get => id; set => id = value; }    // property to use field, value is the user input
                                                              // to validate the input value of fields

        public int Id1
        {
            set
            {
                if(value > 0)
                {
                    id = value;
                }
                else { id = -1 ;}
            }
        }
        public string Display()
        {
            return $"Employee id is : {id}";
        }
    }

    public class Fields
    {
        public static void Main(String[] args)
        {
            FieldsInputs inputs = new FieldsInputs();
            inputs.Id1 = 1;     // to pass the value to the private id
            Console.WriteLine(inputs.Display());


        }
    }
}
