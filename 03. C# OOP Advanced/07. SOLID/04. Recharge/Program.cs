namespace _04.Recharge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IRechargeable robot = new RobotAdapter("id", 23);

        }
    }
}
