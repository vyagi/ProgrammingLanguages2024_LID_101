namespace ExceptionsDemo
{
    public class Parser
    {
        private readonly ValueReader _reader;

        public Parser(ValueReader reader) => _reader = reader;

        public int Parse()
        {
            try
            {
                return int.Parse(_reader.Read());
            }
            catch (Exception ex)
            {
                //log
                Console.WriteLine("In the parser method, we have a problem");
                //throw ex;//DON'T do it
                throw;
            }
        }
    }
}