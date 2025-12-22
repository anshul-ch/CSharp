using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CSharp.Day3_OOPS
{
    public class ConstructorLLogsCreation
    {
        public string name { get;set;}
        public int id { get;set;}
        public string description { get;set;}
        public string LogHistory;

        public ConstructorLLogsCreation()
        {
            LogHistory += $"Object Created at {DateTime.Now.ToString()}  {Environment.NewLine}";
        }

        public ConstructorLLogsCreation(string name) : this()
        {
            this.name = name ;
            LogHistory += $"Name assigned at {DateTime.Now.ToString()}  {Environment.NewLine}";
        }

        public ConstructorLLogsCreation(string name, int id) : this(name)
        {
            this.id = id;
            LogHistory += $"ID assigned at {DateTime.Now.ToString()}  {Environment.NewLine}";
        }
        public ConstructorLLogsCreation(string name, int id, string description) : this(name, id)
        {
            this.description = description ;
            LogHistory += $"Description assigned at {DateTime.Now.ToString()}  {Environment.NewLine}";
        }
    }

    public class ConstructorLogs
    {
        public static void Main(String[] args)
        {
            ConstructorLLogsCreation logcreation = new ConstructorLLogsCreation("Anshul", 120,"Works IN IT");

        }
    }
}
