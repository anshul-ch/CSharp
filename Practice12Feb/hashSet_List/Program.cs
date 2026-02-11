class Program
{
    public static void Main(String[] args)
    {
        List<int> data  = new List<int>(){1,2,3,4,5,2,3,4,1,5,6};
        HashSet<int> filtered = new HashSet<int>(data);
        foreach(var item in filtered)
        {
            Console.WriteLine(item);
        }
    }
}
