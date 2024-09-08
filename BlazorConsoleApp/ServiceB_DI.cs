namespace BlazorConsoleApp
{
    public class ServiceB_DI : IServiceB_DI
    {
        public ServiceB_DI(IServiceC_DI serviceC)
        {
            ServiceC = serviceC;
        }

        private IServiceC_DI ServiceC { get; }
    }

    public interface IServiceB_DI
    {
    }
}
