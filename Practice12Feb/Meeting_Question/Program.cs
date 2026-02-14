public class InvalidCreditDataException : Exception
{
    public InvalidCreditDataException(string message) 
        : base(message)
    {
    }
}
public class Customer
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string EmploymentType { get; set; }
    public double MonthlyIncome { get; set; }
    public double ExistingDues { get; set; }
    public int CreditScore { get; set; }
    public int LoanDefaults { get; set; }
}
public class CreditRiskProcessor
{
    public void ValidateCustomerDetails(Customer customer)
    {
        if(customer.Age <21 || customer.Age > 65)
            throw new InvalidCreditDataException("Invalid Age");
        if (customer.MonthlyIncome < 20000)
            throw new InvalidCreditDataException("Invalid Monthly Income");
        if (customer.EmploymentType != "Salaried" && customer.EmploymentType != "Self-Employed")
            throw new InvalidCreditDataException("Invalid employment type");
         if (customer.ExistingDues < 0)
            throw new InvalidCreditDataException("Invalid credit dues");

        if (customer.CreditScore < 300 || customer.CreditScore > 900)
            throw new InvalidCreditDataException("Invalid credit score");

        if (customer.LoanDefaults < 0)
            throw new InvalidCreditDataException("Invalid default count");
    }
    public int CalculateCreditLimit(Customer customer)
    {
        double debtRatio = customer.ExistingDues / (customer.MonthlyIncome * 12);
        // High-Risk
        if(customer.CreditScore <600 || customer.LoanDefaults >=3 || debtRatio > 0.4)
        {
            return 50000;
        }
        // low risk
        if (customer.CreditScore >= 750 && customer.LoanDefaults == 0 && debtRatio < 0.25)
        {
            return 300000;
        }
        // Medium Risk
        return 150000;
    }
}


class Program
{
    public static void Main(String[] args)
    {
        try{
        Customer customer = new Customer();

        Console.Write("Enter customer name: ");
        customer.Name = Console.ReadLine();
        Console.Write("Enter age: ");
        customer.Age = int.Parse(Console.ReadLine());
        Console.Write("Enter employment type: ");
        customer.EmploymentType = Console.ReadLine();
        Console.Write("Enter monthly income: ");
        customer.MonthlyIncome = double.Parse(Console.ReadLine());
        Console.Write("Enter existing credit dues: ");
        customer.ExistingDues = double.Parse(Console.ReadLine());
        Console.Write("Enter credit score: ");
        customer.CreditScore = int.Parse(Console.ReadLine());
        Console.Write("Enter no of loan defaults:");
        customer.LoanDefaults = int.Parse(Console.ReadLine());

        CreditRiskProcessor creditRiskProcessor = new CreditRiskProcessor();
        creditRiskProcessor.ValidateCustomerDetails(customer);

        int finalCredit = creditRiskProcessor.CalculateCreditLimit(customer);
        Console.WriteLine($"Name: {customer.Name}");
        Console.WriteLine($"Approved credit Limit:{finalCredit}");
        }
        catch(InvalidCastException e)
        {
            Console.WriteLine(e.Message);
        }
    }

}