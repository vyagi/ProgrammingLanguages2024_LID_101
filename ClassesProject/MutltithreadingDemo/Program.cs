namespace MutltithreadingDemo
{
    internal class Program
    {
        private static int _counter;

        private static object _dummy = new object();

        static void Main(string[] args)
        {
            var t1 = new Thread(Increment);
            var t2 = new Thread(Increment);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine($"The value is {_counter}");
        }
        public static void Increment()
        {
            for (int i = 0; i < 1_000_000_000; i++)
            {
                if (i > 0 && i % 100_000_000 == 0)
                    Console.WriteLine($"{i} was reached");

                //Interlocked.Increment(ref _counter);

                lock (_dummy)
                {
                    _counter++;
                }

            }
            Console.WriteLine("The job is completed");
        }
    }

    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var t1 = new Thread(SomeJobToBeDone);
    //        var t2 = new Thread(SomeJobToBeDone);

    //        t1.IsBackground = true;
    //        t2.IsBackground = true;

    //        t1.Start();
    //        t2.Start();

    //        var list = new List<int>();

    //        for (int i = 0; i < 1_000_000_000; i++)
    //        {
    //            if (i > 0 && i % 100_000_000 == 0)
    //                Console.WriteLine($"{i} was reached in the main thread");

    //            list.Add(i);
    //        }
    //        Console.WriteLine("The job is completed in the main thread");

    //        t1.Join();
    //        t2.Join();
    //    }
    //    public static void SomeJobToBeDone()
    //    {
    //        var list = new List<int>();

    //        for (int i = 0; i < 500_000_000; i++)
    //        {
    //            if (i > 0 && i % 100_000_000 == 0)
    //                Console.WriteLine($"{i} was reached");

    //            list.Add(i);
    //        }
    //        Console.WriteLine("The job is completed");
    //    }
    //}


    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var t = new Thread(SomeJobToBeDone);
    //        Console.WriteLine(t.IsBackground);

    //        t.IsBackground = true;

    //        t.Start();

    //        Console.ReadLine();//not good approach, but for now let's use it
    //    }
    //    public static void SomeJobToBeDone()
    //    {
    //        var list = new List<int>();

    //        for (int i = 0; i < 1_000_000_000; i++)
    //        {
    //            if (i > 0 && i % 100_000_000 == 0)
    //                Console.WriteLine($"{i} was reached");

    //            list.Add(i);
    //        }
    //        Console.WriteLine("The job is completed");
    //    }
    //}
}