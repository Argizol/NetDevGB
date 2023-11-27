namespace UDPClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("От кого?");
            string from = Console.ReadLine();
            Console.WriteLine("Какой ip?");
            string ip = Console.ReadLine();


            UDPClient.SendMessage(from, ip);
        }
    }
}