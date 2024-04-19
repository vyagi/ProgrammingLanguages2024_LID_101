namespace ExceptionsDemo
{
    public class ValueReader
    {
        private readonly string _path = "asdainput.txt";

        public string Read()
        {
            try
            {
                return File.ReadAllText(_path);
            }
            catch (FileNotFoundException ex)
            {
                //it is always a good idea to log when exception happens
                //we don't have any logger so this semester we'll just console.writeline
                Console.WriteLine("An error occured");

                //throw ex;//not a good idea - never do it
                throw new ThereIsNoFileException($"The file {_path} does not exist");
            }
            catch
            {
                Console.WriteLine("An unexpected error occured");
                throw;
            }
        }
    }

    public class ThereIsNoFileException : Exception
    {
        public ThereIsNoFileException(string message) : base(message)
        {

        }
    }

    //public class ThereIsNoFileException : Exception
    //{
    //    public ThereIsNoFileException(string message, Exception innerException) : base(message, innerException)
    //    {
            
    //    }
    //}
}