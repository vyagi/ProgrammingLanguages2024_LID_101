namespace DeconstructionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? maybe = 12;

            if (maybe is int)
            {
                int value = maybe.Value;
                Console.WriteLine($"The nullable int 'maybe' has the value {value}");
            }
            else
            {
                Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
            }

            object someObject = new DateTime();
            if (someObject is string value1)
            {
                Console.WriteLine(value1);
            }
            else
            {
                Console.WriteLine("This is not a string");
            }


            var s = new Student("James", "Bond", 50);
            
            var s1 = s with { Age = 51 };

            //oldschool
            //var name = s.Name;
            //var lastName = s.LastName;
            //var age = s.Age;

            //this is better but not the best
            //(string name, string lastName, int age) = s;

            //this is even better but not the best
            //(var name, var lastName, var age) = s;

            var (name, lastName, age) = s;
            Console.WriteLine($"{name} {lastName} is {age} years old");

            //now let's bring again this "out"
            string numberString = "11";
            int result;
            bool success = int.TryParse(numberString, out result);
            
            if (success)
            {
                Console.WriteLine($"It was successfull and the value is {result}");
            }
            else
            {
                Console.WriteLine($"It was not successfull");
            }

            var succesOfDivision = TryDivide(10, 0, out var resultOfDivision);
            Console.WriteLine(succesOfDivision ? resultOfDivision :"Not possible");

            var (success1, result1) = Divide(10, 10);
            Console.WriteLine(success1 ? result1 : "Not possible");

        }

        public static (bool Success, int Result) Divide(int a, int b) =>
            b == 0 ? (false, 0) : (true, a / b);

        //Old school, don't create new code with "out" variables (apart from Deconstructor)
        public static bool TryDivide(int a, int b, out int result) 
        {
            if (b == 0)
            {
                result = 0;
                return false;
            }

            result = a / b;
            return true;
        }
    }
}
