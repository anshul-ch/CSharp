namespace CSharp.Week3_OOPS
{
    /// <summary>
    /// This snippet contains the template of classes to be used in another program as input.
    /// </summary>
    public class FamilyDefination
    {
        public string name { get; set; }
        public int age { get; set; }
    }

    public  class Man : FamilyDefination
    {
        public string job { get; set; }
    }

    public class Woman : FamilyDefination
    {
        public string work { get; set; }
    }

    public class Child : FamilyDefination
    {
        public string cartoon { get; set; }
    }
}
