List<int> numbers1 = [ 2, 5, 10, 12, 5, 1, 12, 2, 10, 11, 4 ];
int[] numbers2 = [ 10, 1, 56, 7, 12, 1, 8, 5, 1, 2, 2];
string[] names = [ "James", "Jason", "Jay", "Jojo"];

var persons = new Person[] {
    new (1, "James", "Bond", 58, ["Spying", "Women", "Cars"]),
    new (2, "Kirk", "Hammett", 55, ["Guitar", "Comic books", "Horrors"]),
    new (3, "Ozzy", "Ozbourne", 70, ["Guitar", "Singing", "Women", "Alcohol", "Drugs"]),
    new (4, "John", "Lennon", 74, ["Guitar", "Singing", "Poetry"]),
    new (5, "Donald", "Trump", 80, ["Money", "Women", "Power"]),
    new (6, "Donald", "Duck", 71, ["Seed", "Quacking"]),
    new (7, "John", "Travolta", 33, ["Singing", "Acting"]),
};
var addresses = new Address[] {
    new (1, 1, "London", "Baker street", TypeOfAddress.Home),
    new (2, 1, "Birmingham", "Aldrige St.", TypeOfAddress.Mail),
    new (3, 2, "San Francisco", "10 Avenue", TypeOfAddress.Home),
    new (4, 2, "San Francisco", "Roman Blvd", TypeOfAddress.Mail),
    new (5, 2, "Los Angeles", "Mulholland Drive", TypeOfAddress.Temporary),
    new (6, 2, "Los Angeles", "Beverly Hills 90210", TypeOfAddress.Temporary),
    new (100, -1, "Moon", "Dark side", TypeOfAddress.Home),
    new (100, -1, "Sun", "Gas", TypeOfAddress.Temporary),
};


#region oldstuff

//Console.WriteLine(numbers1.Count());
//Console.WriteLine(numbers1.Sum());
//Console.WriteLine(numbers1.Min());
//Console.WriteLine(numbers1.Max());
//Console.WriteLine(numbers1.Average());

//var zip1 = numbers1.Zip(numbers2);
//Display("Zip1", zip1);

//var zip2 = numbers1.Zip(names);
//Display("Zip2", zip2);

//var union = numbers1.Union(numbers2);
//Display("union", union);

//var concat = numbers1.Concat(numbers2);
//Display("concat", concat);

//var except = numbers1.Except(numbers2);
//Display("except", except);

//var intersect = numbers1.Intersect(numbers2);
//Display("intersect", intersect);

//var solution1 = numbers1.Union(numbers2).Except(numbers1.Intersect(numbers2));
//Display("solution1", solution1);

//var solution2 = numbers1.Except(numbers2).Union(numbers2.Except(numbers1));
//Display("solution2", solution2);

//var take = numbers1.Take(4);
//Display("take", take);

//var skip = numbers1.Skip(4);
//Display("skip", skip);

//var takeWhile = numbers1.TakeWhile(x=>x != 12);
//Display("takeWhile", takeWhile);

//var skipWhile = numbers1.SkipWhile(x => x != 12);
//Display("skipWhile", skipWhile);

//var takeLast = numbers1.TakeLast(4);
//Display("takeLast", takeLast);

//var skipLast = numbers1.SkipLast(4);
//Display("skipLast", skipLast);

//LINQ NEVER changes the original collection - it will produce a new one !!!!!!

//var reversed = numbers1.Reverse();
//Display("reversed", reversed);

//Console.WriteLine(numbers1.All(x=>x > 0));
//Console.WriteLine(numbers1.All(x=>x > 1));

//Console.WriteLine(numbers1.Any(x => x > 0));
//Console.WriteLine(numbers1.Any(x => x > 100));

//var chunks = numbers1.Chunk(3);


//foreach (var chunk in chunks)
//{
//    foreach (var element in chunk)
//    {
//        Console.Write(element + " ");
//    }

//    Console.WriteLine();
//}

//Console.WriteLine(numbers1.SequenceEqual(numbers2));
//Console.WriteLine(numbers1.SequenceEqual(numbers1));

//var bigNumbers = numbers1.Where(x => x > 5);
////EVEN MORE IMPORTANT CHARACTERISTICS OF LINQ - it is Lazily evaluated !!!!!!!!!!!!!!
//numbers1.Add(100);
//Display("bigNumbers", bigNumbers);

//Console.WriteLine(numbers1.ElementAt(4));
//Console.WriteLine(numbers1.Contains(10));
//Console.WriteLine(numbers1.Contains(100));
//Console.WriteLine(numbers1.FirstOrDefault(x=> x % 2 == 0));
//Console.WriteLine(numbers1.LastOrDefault(x=> x % 2 == 0));
//Console.WriteLine(numbers1.SingleOrDefault(x=> x % 2 == 0));

//Console.WriteLine(numbers1.First(x => x < 0));
//Console.WriteLine(numbers1.Last(x => x % 2 == 0));
//Console.WriteLine(numbers1.Single(x => x % 2 == 0));

#endregion oldstuff

//Where, Select, OrderBy (OrderByDescending) - filtering, projection, sorting 

var q1 = persons
    .Where(x => x.FirstName != "Donald")
    .OrderByDescending(x => x.Hobbies.Length)
    .Select(x => $"{x.FirstName} {x.LastName}");

Display("q1",q1);

var q2 = from x in persons
            where x.FirstName != "Donald"
            orderby x.Hobbies.Length descending 
            select $"{x.FirstName} {x.LastName}";

Display("q2", q2);

//Very useful method
var hobbies = persons.SelectMany(x => x.Hobbies).Distinct(); //Remember this useful method
Display("hobbies", hobbies);

var groupedByAge = persons.GroupBy(x => x.Age / 10);

var personsWithAddressesDoNotDoItLikeThis = 
    from p in persons
    from a in addresses
    where p.Id == a.PersonId
    select a; //not a proper way to do join

var personsWithAddresses =
    from p in persons
    join a in addresses on p.Id equals a.PersonId
    select (a, p);

var groupJoin =
    from p in persons
    join a in addresses on p.Id equals a.PersonId into personAddresses
    select (p, personAddresses);

var leftJoin =
    from p in persons
    join a in addresses on p.Id equals a.PersonId into personAddresses
    from pa in personAddresses.DefaultIfEmpty()
    select (p, pa);


var personWithMostHobbies = persons.OrderByDescending(x => x.Hobbies.Length).First();


void Display<T>(string name, IEnumerable<T> collection)
{
    Console.WriteLine($"****{name}****");
    foreach (var element in collection)
    {
        Console.WriteLine(element);   
    }
}

public enum TypeOfAddress { Home, Mail, Temporary }
public record Person(int Id, string FirstName, string LastName, int Age, string[] Hobbies);
public record Address(int Id, int PersonId, string City, string Street, TypeOfAddress AddressType);