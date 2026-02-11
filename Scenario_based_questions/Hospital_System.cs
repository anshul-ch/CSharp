using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Scenario_based_questions
{
    public interface IPatient
    {
        int PatientId { get; }
        string Name { get; }
        DateTime DateOfBirth { get; }
        BloodType BloodType { get; }
    }

    public enum BloodType { A, B, AB, O }
    public enum Condition { Stable, Critical, Recovering }

    public class PriorityQueue<T> where T : IPatient
    {
        private SortedDictionary<int, Queue<T>> _queues = new();

        public void Enqueue(T patient, int priority)
        {
            if (priority < 1 || priority > 5)
                throw new ArgumentException("Priority must be 1–5");

            if (!_queues.ContainsKey(priority))
                _queues[priority] = new Queue<T>();

            _queues[priority].Enqueue(patient);
        }

        public T Dequeue()
        {
            foreach (var key in _queues.Keys.OrderBy(x => x))
            {
                if (_queues[key].Count > 0)
                    return _queues[key].Dequeue();
            }
            throw new InvalidOperationException("Queue empty");
        }

        public T Peek()
        {
            foreach (var key in _queues.Keys.OrderBy(x => x))
            {
                if (_queues[key].Count > 0)
                    return _queues[key].Peek();
            }
            throw new InvalidOperationException("Queue empty");
        }

        public int GetCountByPriority(int priority)
        {
            return _queues.ContainsKey(priority)
                ? _queues[priority].Count
                : 0;
        }
    }

    public class MedicalRecord<T> where T : IPatient
    {
        private T _patient;
        private List<string> _diagnoses = new();
        private Dictionary<DateTime, string> _treatments = new();

        public MedicalRecord(T patient)
        {
            _patient = patient;
        }

        public void AddDiagnosis(string diagnosis, DateTime date)
        {
            _diagnoses.Add($"{date.ToShortDateString()} - {diagnosis}");
        }

        public void AddTreatment(string treatment, DateTime date)
        {
            _treatments[date] = treatment;
        }

        public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
        {
            return _treatments.OrderBy(x => x.Key);
        }
    }

    public class PediatricPatient : IPatient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }
        public string GuardianName { get; set; }
        public double Weight { get; set; }
    }

    public class GeriatricPatient : IPatient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }
        public List<string> ChronicConditions { get; } = new();
        public int MobilityScore { get; set; }
    }


    public class MedicationSystem<T> where T : IPatient
    {
        private Dictionary<T, List<string>> _medications = new();

        public void PrescribeMedication(T patient, string medication,
            Func<T, bool> validator)
        {
            if (!validator(patient))
                throw new InvalidOperationException("Invalid dosage");

            if (!_medications.ContainsKey(patient))
                _medications[patient] = new List<string>();

            _medications[patient].Add(medication);
        }

        public bool CheckInteractions(T patient, string newMedication)
        {
            if (!_medications.ContainsKey(patient))
                return false;

            return _medications[patient].Contains(newMedication);
        }
    }

    class Hospital_System
    {
        static void Main()
        {
            var p1 = new PediatricPatient
            {
                PatientId = 1,
                Name = "Child1",
                DateOfBirth = new DateTime(2018, 1, 1),
                BloodType = BloodType.A,
                GuardianName = "Parent",
                Weight = 18
            };

            var g1 = new GeriatricPatient
            {
                PatientId = 2,
                Name = "Senior1",
                DateOfBirth = new DateTime(1950, 1, 1),
                BloodType = BloodType.O,
                MobilityScore = 6
            };

            var queue = new PriorityQueue<IPatient>();
            queue.Enqueue(p1, 2);
            queue.Enqueue(g1, 1);

            Console.WriteLine("Next patient: " + queue.Dequeue().Name);

            var record = new MedicalRecord<IPatient>(p1);
            record.AddDiagnosis("Flu", DateTime.Today);
            record.AddTreatment("Rest", DateTime.Today);

            foreach (var t in record.GetTreatmentHistory())
                Console.WriteLine($"{t.Key} - {t.Value}");

            var meds = new MedicationSystem<IPatient>();
            meds.PrescribeMedication(p1, "Paracetamol",
                patient => patient is PediatricPatient ped && ped.Weight > 10);

            Console.WriteLine("Interaction: " +
                meds.CheckInteractions(p1, "Paracetamol"));
        }
    }
}
