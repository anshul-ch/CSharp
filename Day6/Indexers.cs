using System;
namespace CSharp.Day6
{
	public class MyData
	{
		private string[] data = new string[3];
		public string this[int index]
		{
			get { return data[index]; }
			set { data[index] = value; }
        }
    }
	public class Indexers
	{
		public static void Main(String[] args)
		{
			MyData myData = new MyData();
			myData[0] = "First";
			myData[1] = "Second";
			myData[2] = "Third";
			Console.WriteLine(myData[0]);
			Console.WriteLine(myData[1]);
			Console.WriteLine(myData[2]);
		}
    }
}