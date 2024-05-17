using FluentAssertions;
using System.Diagnostics;
using System.Xml.Linq;

namespace InvoiceApplication.BusinessLogic.Tests
{
    public class InvoiceProcessorTests
    {
        [Fact]
        public void GroupByCategories_produces_correct_summary()
        {
            var processor = new InvoiceProcessor();
            var lines = new string[] {
                "Name; Price; Category",
                "Bread; 1000; Food",
                "Sushi; 2000; Food",
                "Lego; 2500; Toys",
                "Pizza; 100; Food",
                "New laptop; 50000; Equipment"
            };

            var result = processor.GroupByCategories(lines);

            result.Should().HaveCount(3);
            
            result.First().Category.Should().Be("Food");
            result.First().Amount.Should().Be(3100);

            result.Second().Category.Should().Be("Toys");
            result.Second().Amount.Should().Be(2500);

            result.Third().Category.Should().Be("Equipment");
            result.Third().Amount.Should().Be(50000);
        }
    }
}