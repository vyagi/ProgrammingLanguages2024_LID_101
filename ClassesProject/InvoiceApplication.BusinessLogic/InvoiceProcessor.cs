using System.Linq.Expressions;

namespace InvoiceApplication.BusinessLogic
{
    public class Invoice
    {
        public static Invoice FromLine(string line)
        {
            var split = line.Split(';');
            return new Invoice(split[0].Trim(), decimal.Parse(split[1]), split[2].Trim());
        }

        public Invoice(string name, decimal amount, string category)
        {
            Name = name;
            Amount = amount;
            Category = category;
        }

        public string Name { get; }
        public decimal Amount { get; }
        public string Category { get; }
    }

    public class InvoiceProcessor
    {
        public List<(string Category, decimal Amount)> GroupByCategories(string[] lines) => lines
                .Skip(1)
                .Select(Invoice.FromLine)
                .GroupBy(x => x.Category)
                .Select(x => (x.Key, x.Sum(y => y.Amount)))
                .ToList();
    }
}