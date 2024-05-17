//namespace DelegatesAndEventsDemo
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            OurFirstDelegate del1 = DoSomething;
            
//            del1();

//            del1 += DoSomethingElse;

//            del1();

//            del1 -= DoSomething;

//            del1();

//            del1 -= DoSomethingElse;

//            del1?.Invoke();//new school

//            //OurSecondDelegate del2 = DoSomething;  // you cannot do it
//        }

//        public static void DoSomething() => Console.WriteLine("Doing something");
//        public static void DoSomethingElse() => Console.WriteLine("Doing something else");
//    }

//    public delegate void OurFirstDelegate();
    
//    public delegate int OurSecondDelegate(string x);

//    public delegate string OurThirdDelegate(int a, DateTime b);

//}