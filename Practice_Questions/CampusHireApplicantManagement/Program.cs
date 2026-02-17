using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CampusHireApplicantManagement
{
    public enum CurrentLocation
    {
        Mumbai,
        Pune,
        Chennai
    }
    public enum PreferredLocation
    {
        Mumbai,
        Pune,
        Chennai,
        Delhi,
        Kolkata,
        Bangalore
    }
    public enum CoreCompetency
    {
        DOTNET,
        JAVA,
        ORACLE,
        Testing
    }
    [Serializable]
    public class Applicant
    {
        public string ApplicantId { get; set; }
        public string Name { get; set; }
        public CurrentLocation CurrentLocation { get; set; }
        public PreferredLocation PreferredLocation { get; set; }
        public CoreCompetency CoreCompetency { get; set; }
        public int PassingYear { get; set; }
    }

    class Program
    {
        static string filePath = "applicants.json";
        static List<Applicant> applicants = new List<Applicant>();

        public static void Main(string[] args)
        {
            LoadData();

            while (true)
            {
                Console.WriteLine("\n=== CampusHire Applicant Management ===");
                Console.WriteLine("1. Add Applicant");
                Console.WriteLine("2. Display All Applicants");
                Console.WriteLine("3. Search Applicant by ID");
                Console.WriteLine("4. Update Applicant");
                Console.WriteLine("5. Delete Applicant");
                Console.WriteLine("6. Exit");
                Console.Write("Select Option: ");

                switch (Console.ReadLine())
                {
                    case "1": AddApplicant(); break;
                    case "2": DisplayAll(); break;
                    case "3": SearchApplicant(); break;
                    case "4": UpdateApplicant(); break;
                    case "5": DeleteApplicant(); break;
                    case "6": SaveData(); return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        static void AddApplicant()
        {
            try
            {
                Console.Write("Applicant ID: ");
                string id = Console.ReadLine();
                ValidateApplicantId(id);

                if (applicants.Any(a => a.ApplicantId == id))
                    throw new Exception("Applicant ID already exists.");

                Console.Write("Name: ");
                string name = Console.ReadLine();
                ValidateName(name);

                Console.WriteLine("Select Current Location: 0-Mumbai 1-Pune 2-Chennai");
                CurrentLocation current = (CurrentLocation)int.Parse(Console.ReadLine());

                Console.WriteLine("Select Preferred Location: 0-Mumbai 1-Pune 2-Chennai 3-Delhi 4-Kolkata 5-Bangalore");
                PreferredLocation preferred = (PreferredLocation)int.Parse(Console.ReadLine());

                Console.WriteLine("Select Core Competency: 0-DOTNET 1-JAVA 2-ORACLE 3-Testing");
                CoreCompetency competency = (CoreCompetency)int.Parse(Console.ReadLine());

                Console.Write("Passing Year: ");
                int year = int.Parse(Console.ReadLine());
                ValidatePassingYear(year);

                applicants.Add(new Applicant
                {
                    ApplicantId = id,
                    Name = name,
                    CurrentLocation = current,
                    PreferredLocation = preferred,
                    CoreCompetency = competency,
                    PassingYear = year
                });

                SaveData();
                Console.WriteLine("Applicant added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void DisplayAll()
        {
            if (!applicants.Any())
            {
                Console.WriteLine("No records found.");
                return;
            }

            foreach (var a in applicants)
            {
                Console.WriteLine($"\nID: {a.ApplicantId}");
                Console.WriteLine($"Name: {a.Name}");
                Console.WriteLine($"Current Location: {a.CurrentLocation}");
                Console.WriteLine($"Preferred Location: {a.PreferredLocation}");
                Console.WriteLine($"Core Competency: {a.CoreCompetency}");
                Console.WriteLine($"Passing Year: {a.PassingYear}");
            }
        }

        static void SearchApplicant()
        {
            Console.Write("Enter Applicant ID: ");
            string id = Console.ReadLine();

            var applicant = applicants.FirstOrDefault(a => a.ApplicantId == id);
            if (applicant == null)
                Console.WriteLine("Applicant not found.");
            else
                Console.WriteLine($"Found: {applicant.Name}, {applicant.CoreCompetency}");
        }

        static void UpdateApplicant()
        {
            Console.Write("Enter Applicant ID to update: ");
            string id = Console.ReadLine();

            var applicant = applicants.FirstOrDefault(a => a.ApplicantId == id);
            if (applicant == null)
            {
                Console.WriteLine("Applicant not found.");
                return;
            }

            Console.Write("New Name: ");
            string name = Console.ReadLine();
            ValidateName(name);

            applicant.Name = name;

            SaveData();
            Console.WriteLine("Updated successfully.");
        }

        static void DeleteApplicant()
        {
            Console.Write("Enter Applicant ID to delete: ");
            string id = Console.ReadLine();

            var applicant = applicants.FirstOrDefault(a => a.ApplicantId == id);
            if (applicant == null)
            {
                Console.WriteLine("Applicant not found.");
                return;
            }

            applicants.Remove(applicant);
            SaveData();
            Console.WriteLine("Deleted successfully.");
        }

        static void ValidateApplicantId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new Exception("Applicant ID is mandatory.");

            if (id.Length != 8 || !id.StartsWith("CH"))
                throw new Exception("Applicant ID must be 8 characters and start with 'CH'.");
        }

        static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name is mandatory.");

            if (name.Length < 4 || name.Length > 15)
                throw new Exception("Name must be between 4 and 15 characters.");
        }

        static void ValidatePassingYear(int year)
        {
            if (year > DateTime.Now.Year)
                throw new Exception("Passing year cannot be greater than current year.");
        }

        static void SaveData()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(filePath, JsonSerializer.Serialize(applicants, options));
        }

        static void LoadData()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                applicants = JsonSerializer.Deserialize<List<Applicant>>(json) ?? new List<Applicant>();
            }
        }
    }
}
