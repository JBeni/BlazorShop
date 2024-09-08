namespace BlazorConsoleApp
{
    public class ServiceB
    {
        public ServiceB(ServiceC serviceC)
        {
            ServiceC = serviceC;
        }

        private ServiceC ServiceC { get; }
    }
}
