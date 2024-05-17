namespace DelegatesAndEventsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var integrator = new Integrator();

            //Old school
            //IntegrableFunction functionDelegate = Squarer;

            //Console.WriteLine(integrator.Integrate(functionDelegate));

            //functionDelegate = Cubicer;
            //Console.WriteLine(integrator.Integrate(functionDelegate));

            //A bit newer way
            Console.WriteLine(integrator.Integrate(Sinuser));
            Console.WriteLine(integrator.Integrate(x => Math.Sqrt(x)));
            Console.WriteLine(integrator.Integrate(Math.Sqrt));
        }

        public static double Squarer(double x) => x * x;
        public static double Cubicer(double x) => x * x * x;
        public static double Sinuser(double x) => Math.Sin(x);
    }

    //Old school - keep it in the passive C# knowledge
    //public delegate double IntegrableFunction(double x);

    //Home work - improve this class to be possible to set (change) the starting point, ending point
    //And the number of midpoints
    public class Integrator
    {
        public double StartingPoint { get; } = 0;
        public double EndingPoint { get; } = 10;
        public int Midpoints { get; set; } = 10;
        //Old school
        //public double Integrate(IntegrableFunction function)
        
        //New school
        public double Integrate(Func<double, double> function)
        {
            var arguments = new double[Midpoints + 1];
            var values = new double[Midpoints + 1];

            var argumentStep = (EndingPoint - StartingPoint) / Midpoints;

            for (int i = 0; i <= Midpoints; i++)
            {
                arguments[i] = StartingPoint + i * argumentStep;
                values[i] = function(arguments[i]);
            }

            var sum = 0.0;

            for (int i = 0; i < Midpoints; i++)
                sum += argumentStep * (values[i] + values[i + 1]) / 2;

            return sum;
        }
    }
}