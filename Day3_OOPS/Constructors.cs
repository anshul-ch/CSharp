using System;
using System.Collections.Generic;
using System.Text;

namespace CapgeminiTraining.ConstructorsEX
{
    /// <summary>
    /// this program implemetns the constructor template to be used for input in another file.
    /// </summary>
    public class Constructors
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        private Constructors()
        {

        }
        public Constructors(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }
        public Constructors(string name, string description) 
        {
            this.name = name;
            this.description = description;
        }
    }
}
