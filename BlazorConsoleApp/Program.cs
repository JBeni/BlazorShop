namespace BlazorConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceA = new ServiceA(new ServiceB(new ServiceC(new ServiceD())));
            serviceA.PrintLn("Message from ServiceA\n");

            IServiceC_DI serviceC = new ServiceC_DI();
            IServiceB_DI serviceB = new ServiceB_DI(serviceC);
            IServiceA_DI serviceA_DI = new ServiceA_DI(serviceB);
            serviceA_DI.PrintLn("Message from serviceA_DI");


            Console.WriteLine("\n\n");
            Console.WriteLine("Hello, World!");
        }
    }
}
