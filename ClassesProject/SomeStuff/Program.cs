using Geometry;

var pc = new PolygonalChain(new Point(1,2), new Point(2,3));
pc.AddMidpoint(new Point(3,4));
pc.AddMidpoint(new Point(5,6));
pc.AddMidpoint(new Point(7,8));
pc.AddMidpoint(new Point(9,10));

foreach (var p in pc)
{
    Console.WriteLine(p);
}

var point = new Point(1, 2);

foreach (var number in point)
{
    Console.WriteLine(number);
}




//var student1 = new Student { Id = 1, Name = "James Bond" };
//var student2 = new Student { Id = 1, Name = "James Bond" };
//var student3 = new Student { Id = 2, Name = "James Bond" };

////var student1 = new Student(1, "James Bond");
////var student2 = new Student(1, "James Bond");

//Console.WriteLine(student1.Equals(student2));
//Console.WriteLine(student1);

////public record Student(int Id, string Name);


////var c = MutableClassWithPrivateConstructor.Create();
////Console.WriteLine(c.Age);
////c.MakeOlder();
////Console.WriteLine(c.Age);

//public record Student
//{
//    public required int Id { get; init; }
//    public string Name { get; set; }
//}

////public class MutableClassWithPrivateConstructor
////{
////    public int Age { get; private init; } = 10;

////    public static MutableClassWithPrivateConstructor Create()
////    { 
////        return new MutableClassWithPrivateConstructor(); 
////    }

////    private MutableClassWithPrivateConstructor()
////    {

////    }

////    public void MakeOlder() => Age++;
////}