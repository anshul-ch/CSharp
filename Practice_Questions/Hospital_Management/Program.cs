using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagementSystem
{
    class DoctorNotAvailableException : Exception
    {
        public DoctorNotAvailableException(string message) : base(message) { }
    }

    class InvalidAppointmentException : Exception
    {
        public InvalidAppointmentException(string message) : base(message) { }
    }

    class PatientNotFoundException : Exception
    {
        public PatientNotFoundException(string message) : base(message) { }
    }

    class DuplicateMedicalRecordException : Exception
    {
        public DuplicateMedicalRecordException(string message) : base(message) { }
    }

    abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        protected Person(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }

    interface IBillable
    {
        double CalculateBill();
    }

    class Doctor : Person, IBillable
    {
        public string Specialization { get; set; }
        public double ConsultationFee { get; set; }
        public double TotalEarnings { get; private set; }

        public Doctor(int id, string name, int age,
                      string specialization, double fee)
            : base(id, name, age)
        {
            Specialization = specialization;
            ConsultationFee = fee;
        }

        public double CalculateBill() => ConsultationFee;

        public void AddEarnings(double amount)
        {
            TotalEarnings += amount;
        }
    }

    class Patient : Person
    {
        public string Disease { get; set; }

        public Patient(int id, string name, int age, string disease)
            : base(id, name, age)
        {
            Disease = disease;
        }
    }

    class Appointment : IBillable
    {
        public int AppointmentId { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }

        public Appointment(int id, Doctor doctor, Patient patient,
                           DateTime startTime, TimeSpan duration)
        {
            AppointmentId = id;
            Doctor = doctor;
            Patient = patient;
            StartTime = startTime;
            Duration = duration;
        }

        public DateTime EndTime() => StartTime.Add(Duration);

        public double CalculateBill()
        {
            return Doctor.CalculateBill();
        }
    }

    class MedicalRecord
    {
        public int RecordId { get; private set; }
        public int PatientId { get; private set; }

        private string Diagnosis;
        private string Treatment;
        private DateTime RecordDate;

        public MedicalRecord(int recordId, int patientId,
                             string diagnosis, string treatment)
        {
            RecordId = recordId;
            PatientId = patientId;
            Diagnosis = diagnosis;
            Treatment = treatment;
            RecordDate = DateTime.Now;
        }

        public string GetDiagnosis() => Diagnosis;
        public string GetTreatment() => Treatment;
        public DateTime GetRecordDate() => RecordDate;
    }

    class Program
    {
        static List<Doctor> doctors = new();
        static List<Patient> patients = new();
        static List<Appointment> appointments = new();
        static Dictionary<int, MedicalRecord> medicalRecords = new();

        static void Main()
        {
            SeedData();
            ScheduleAppointment(1, 1, DateTime.Now.AddHours(1), 30);
            RunLinqQueries();
            ExportAppointmentReport();
        }

        static void ScheduleAppointment(int doctorId, int patientId,
                                        DateTime startTime, int durationMinutes)
        {
            Doctor doctor = doctors.FirstOrDefault(d => d.Id == doctorId)
                ?? throw new DoctorNotAvailableException("Doctor not found.");

            Patient patient = patients.FirstOrDefault(p => p.Id == patientId)
                ?? throw new PatientNotFoundException("Patient not found.");

            TimeSpan duration = TimeSpan.FromMinutes(durationMinutes);

            bool overlapping = appointments.Any(a =>
                a.Doctor.Id == doctorId &&
                startTime < a.EndTime() &&
                startTime.Add(duration) > a.StartTime);

            if (overlapping)
                throw new DoctorNotAvailableException("Doctor has overlapping appointment.");

            Appointment appointment = new(
                appointments.Count + 1,
                doctor,
                patient,
                startTime,
                duration);

            appointments.Add(appointment);

            double billAmount = appointment.CalculateBill();
            doctor.AddEarnings(billAmount);
        }

        static void RunLinqQueries()
        {
            Console.WriteLine("\nDoctors with >10 appointments:");
            var busyDoctors = appointments
                .GroupBy(a => a.Doctor)
                .Where(group => group.Count() > 10)
                .Select(group => group.Key.Name);
            foreach (var name in busyDoctors)
                Console.WriteLine(name);

            Console.WriteLine("\nPatients treated in last 30 days:");
            var recentPatients = appointments
                .Where(a => a.StartTime >= DateTime.Now.AddDays(-30))
                .Select(a => a.Patient.Name)
                .Distinct();
            foreach (var name in recentPatients)
                Console.WriteLine(name);

            Console.WriteLine("\nAppointments grouped by Doctor:");
            var groupedAppointments = appointments
                .GroupBy(a => a.Doctor.Name);
            foreach (var group in groupedAppointments)
                Console.WriteLine($"{group.Key}: {group.Count()}");

            Console.WriteLine("\nTop 3 Highest Earning Doctors:");
            var topDoctors = doctors
                .OrderByDescending(d => d.TotalEarnings)
                .Take(3);
            foreach (var doctor in topDoctors)
                Console.WriteLine($"{doctor.Name} - {doctor.TotalEarnings}");

            Console.WriteLine("\nPatients by Disease:");
            var diseaseGroups = patients.GroupBy(p => p.Disease);
            foreach (var group in diseaseGroups)
                Console.WriteLine($"{group.Key}: {group.Count()}");

            Console.WriteLine("\nTotal Revenue:");
            Console.WriteLine(doctors.Sum(d => d.TotalEarnings));
        }

        static void ExportAppointmentReport()
        {
            Console.WriteLine("\n--- Appointment Report ---");

            var report = appointments.Select(a => new
            {
                a.AppointmentId,
                DoctorName = a.Doctor.Name,
                PatientName = a.Patient.Name,
                a.StartTime
            });

            foreach (var entry in report)
                Console.WriteLine($"{entry.AppointmentId} | {entry.DoctorName} | {entry.PatientName} | {entry.StartTime}");
        }

        static void SeedData()
        {
            doctors.AddRange(new[]
            {
                new Doctor(1, "Dr. Rahul", 45, "Cardiology", 1000),
                new Doctor(2, "Dr. Riya", 40, "Neurology", 1200),
                new Doctor(3, "Dr. Amit", 50, "Orthopedics", 900)
            });

            patients.AddRange(new[]
            {
                new Patient(1, "Rohan", 30, "Heart Disease"),
                new Patient(2, "Meera", 25, "Migraine"),
                new Patient(3, "Ankit", 35, "Fracture")
            });
        }
    }
}
