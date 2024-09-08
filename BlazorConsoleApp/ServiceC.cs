namespace BlazorConsoleApp
{
    public class ServiceC
    {
        public ServiceC(ServiceD serviceD)
        {
            ServiceD = serviceD;
        }

        private ServiceD ServiceD { get; }
    }
}
