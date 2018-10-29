namespace DependencyInjection.InversionOfControl
{
    public class WithIoC
    {
        static void Main()
        {
            InitializeFactory();
            var productionAmount = StartProduction();
            var totalBoxes = Boxing();
            Stop(totalBoxes);
        }
        static void InitializeFactory()
        {
        }
        static int StartProduction()
        {
            return 100;

        }
        static int Boxing()
        {
            return 1000;
        }
        static void Stop(int totalBoxes)
        {

        }
    }
}
