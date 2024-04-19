namespace DisposableDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                //if you can use the new approach
                using var s = new Student();
                Console.WriteLine("I am inside the using... Can work with the student");

                //GC.Collect(); -- try not to use it (better have a really good reason)

                //this is the old approach to work with using 
                //using (var s = new Student())
                //{
                //    Console.WriteLine("I am inside the using... Can work with the student");
                //}

                //instead of using we can do it like this (but never do it on your own)
                //Student s2 = null;
                //try 
                //{ 
                //    s2 = new Student();
                //    Console.WriteLine("I am inside the using... Can work with the student s2");
                //}
                //finally 
                //{ 
                //    s2.Dispose();
                //}


                //s.Dispose();  //Don't do it like this

            }

            Console.ReadLine();
        }
    }


    public class Student : IDisposable
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public void Dispose()
        {
            Console.WriteLine("Dispose in progress...");
            //here we can (and should) tidy up - for example close db connection
            //or close file
            //or release any resources which should be released
        }

        ~Student()
        {
            //this is finalizer - it will be called by the garbage collector eventually
            //so this is the last chance to clean up / release the resources
            //because you cannot rely on developers calling Dispose
        }
    }


}
