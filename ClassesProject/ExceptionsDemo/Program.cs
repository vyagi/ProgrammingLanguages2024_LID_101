namespace ExceptionsDemo
{
    internal class Program
    {
        //global exception handler
        static void Main(string[] args)
        {
            try
            {
                var calculator = new Calculator(new Parser(new ValueReader()));

                Console.WriteLine(calculator.Calculate());
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured. Sorry.");
            }
        }
    }
}