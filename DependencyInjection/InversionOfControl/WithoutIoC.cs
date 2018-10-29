namespace DependencyInjection.InversionOfControl
{
    class WithoutIoC
    {
        static void Main()
        {
            InitializeFactory();
        }
        static void InitializeFactory()
        {
            StartProduction();
        }
        static void StartProduction()
        {
            Boxing();

        }
        static void Boxing()
        {
            Stop(1000);
        }
        static void Stop(int totalBoxes)
        {

        }
    }
}
