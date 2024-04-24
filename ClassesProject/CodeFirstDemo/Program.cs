using var dbContext = new LibraryDbContext();

//var firstBook = new Book
//{
//    Title = "Pan Tadeusz",
//    Author = new Author
//    {
//        Name = "Adam Mickiewicz"
//    }
//};

//dbContext.Books.Add(firstBook);

//var nextAuthor = new Author
//{
//    Name = "Julisz Słowacki"
//};

//dbContext.Authors.Add(nextAuthor);

//var slowacki = dbContext.Authors.First(x => x.Name == "Julisz Słowacki");

//var newBook = new Book
//{
//    Title = "Balladyna",
//    Author = slowacki
//};

//dbContext.Books.Add(newBook);

//var testBook = new Book
//{
//    Author = dbContext.Authors.First(),
//    Title = "Test book"
//};

//dbContext.Books.Add(testBook);

//var bookToBeUpdated = dbContext.Books.First(x => x.Title == "Test book");

//bookToBeUpdated.Title = "Test book (modified)";

//var bookToBeRemoved = dbContext.Books.First(x => x.Id == 3);

//dbContext.Books.Remove(bookToBeRemoved);
//dbContext.SaveChanges();

foreach (var book in dbContext.Books)
{
    Console.WriteLine(book.Title);
}