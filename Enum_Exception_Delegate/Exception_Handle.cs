using System;


namespace CSharp.Enum_Exception_Delegate
{
    public class AppCustomException : Exception
    {
        public override string Message => "Internal Exception";

    }

    public class Exception_Handle
    {
        public static void Main()
        {
            try
            {
                int result = Divide(10, 0);

                Console.WriteLine("Result: " + result);
            }
            catch (AppCustomException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private static int Divide(int v1, int v2)
        {
            try
            {
                return v1 / v2;
            }
            catch
            {
                throw new AppCustomException();
            }
        }
    }
}
