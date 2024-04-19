namespace ExceptionsDemo
{
    public class Calculator
    {
        private readonly Parser _parser;

        public Calculator(Parser parser) => _parser = parser;

        public int Calculate()
        {
            return 3000 / _parser.Parse();
        }
    }
}