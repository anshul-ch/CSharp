namespace CSharp.Practice.StreamBuzz;

public class CreatorStats
{
    public string CreatorName { get; set; }
    public double[] WeeklyLikes { get; set; }
}

public class Program
{
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

    public void RegisterCreator(CreatorStats record)
    {
        EngagementBoard.Add(record);
    }

    public Dictionary<string, int> GetTopPostCounts(
        List<CreatorStats> records,
        double likeThreshold
    )
    {
        var result = new Dictionary<string, int>();

        foreach (var r in records)
        {
            int count = r.WeeklyLikes.Count(l => l >= likeThreshold);
            if (count > 0)
                result[r.CreatorName] = count;
        }

        return result;
    }

    public double CalculateAverageLikes()
    {
        return EngagementBoard.SelectMany(c => c.WeeklyLikes).Average();
    }

    static void Main()
    {
        Program program = new Program();

        while (true)
        {
            Console.WriteLine("1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Enter Creator Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                double[] likes = new double[4];
                for (int i = 0; i < 4; i++)
                    likes[i] = Convert.ToDouble(Console.ReadLine());

                program.RegisterCreator(
                    new CreatorStats { CreatorName = name, WeeklyLikes = likes }
                );
                Console.WriteLine("Creator registered successfully");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter like threshold:");
                double threshold = Convert.ToDouble(Console.ReadLine());

                var result = program.GetTopPostCounts(EngagementBoard, threshold);

                if (result.Count == 0)
                    Console.WriteLine("No top-performing posts this week");
                else
                {
                    foreach (var r in result)
                        Console.WriteLine($"{r.Key} - {r.Value}");
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine(
                    $"Overall average weekly likes: {program.CalculateAverageLikes()}"
                );
            }
            else if (choice == 4)
            {
                Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                break;
            }
        }
    }
}