namespace BlazorConsoleApp
{
    public class ServiceA
    {
        public ServiceA(ServiceB serviceB)
        {
            ServiceB = serviceB;
        }

        private ServiceB ServiceB { get; }

        public void PrintLn(string message)
        {
            Console.WriteLine(message);
        }
    }
}
