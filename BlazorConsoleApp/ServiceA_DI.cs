namespace BlazorConsoleApp
{
    public class ServiceA_DI : IServiceA_DI
    {
        public ServiceA_DI(IServiceB_DI serviceB)
        {
            ServiceB = serviceB;
        }

        private IServiceB_DI ServiceB { get; }

        public void PrintLn(string message)
        {
            Console.WriteLine(message);
        }
    }

    public interface IServiceA_DI
    {
        void PrintLn(string message);
    }
}
