namespace CSharp.Practice.Factory_Robot;

class RobotSafetyException : Exception
{
    public RobotSafetyException(string message)
        : base(message) { }
}

class RobotHazardAuditor
{
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
        if (armPrecision < 0.0 || armPrecision > 1.0)
            throw new RobotSafetyException("Error:  Arm precision must be 0.0-1.0");

        if (workerDensity < 1 || workerDensity > 20)
            throw new RobotSafetyException("Error: Worker density must be 1-20");

        double factor = machineryState switch
        {
            "Worn" => 1.3,
            "Faulty" => 2.0,
            "Critical" => 3.0,
            _ => throw new RobotSafetyException("Error: Unsupported machinery state"),
        };

        return ((1.0 - armPrecision) * 15.0) + (workerDensity * factor);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
            double precision = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Worker Density (1 - 20):");
            int workerDensity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical):");
            string state = Console.ReadLine();

            RobotHazardAuditor r = new RobotHazardAuditor();
            double risk = r.CalculateHazardRisk(precision, workerDensity, state);

            Console.WriteLine($"Robot Hazard Risk Score: {risk}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}