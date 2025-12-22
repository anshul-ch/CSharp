using System;
using System.Collections.Generic;
using System.Text;

namespace CapgeminiTraining
{

    /// <summary>
    /// this program used the template in FamiltDefination file to implemetn inheritance
    /// </summary>
    public class FamilyInput
    {
        public static void Main(String[] args)
        {
            FamilyInput input = new FamilyInput();
            FamilyDefination family1 = new FamilyDefination() { name = "Amit", age = 20 };

            Man man = new Man() { name = "Amit", age = 20, job = "IT" };
            Woman woman = new Woman() { name = "Kumari", age = 35, work = "Cafe" };
            Child child = new Child() { name = "Shrey", age = 10, cartoon = "Ben10" };

            FamilyDefination woman1 = woman;
            Console.WriteLine(input.GetManDetails(man));
            Console.WriteLine(input.GetDetails(woman1));

            Console.WriteLine(input.GetBoth(man));
            

        }



        public string GetDetails(FamilyDefination person)
        {
            return $"Name : {person.name}, age = {person.age}"; // here the property of man
                                                                // classs only will not be there
        }
        public string GetManDetails(Man man)
        {
            return $"Name : {man.name}, age = {man.age}, {man.job}";
        }

        // to get the whole parent-child properties
        public string GetBoth(FamilyDefination person) 
        {
            if (person is Man)
            {
                Man man = (Man)person;
                return $"Name : {man.name}, age = {man.age}, {man.job}";

            }
            if (person is Woman) 
            {
                Woman woman = (Woman)person;
                return $"Name : {woman.name}, age = {woman.age}, {woman.work}";
            }
            Child child = (Child)person;
            return $"Name : {child.name}, age = {child.age}, {child.cartoon}";
        }
    }
}
