using FluentAssertions;

namespace Geometry.Tests
{
    public class PolygonalChainTests
    {
        [Fact]
        public void Midpoints_are_added_and_retrieved_properly()
        {
            var polygonalChain = new PolygonalChain(new Point(1,1), new Point(2,3));

            polygonalChain.AddMidpoint(new Point(1,2));
            polygonalChain.AddMidpoint(new Point(2,2));

            polygonalChain.Midpoints.Should().HaveCount(2);
            polygonalChain.Midpoints.First().X.Should().Be(1);
            polygonalChain.Midpoints.First().Y.Should().Be(2);
            polygonalChain.Midpoints.Skip(1).First().X.Should().Be(2);
            polygonalChain.Midpoints.Skip(1).First().Y.Should().Be(2);
        }

        [Fact]
        public void Adding_the_same_midpoint_again_throws_exception()
        {
            var polygonalChain = new PolygonalChain(new Point(1, 1), new Point(2, 3));
            polygonalChain.AddMidpoint(new Point(1, 2));
                        
            Action addingMidpointAgain = () => polygonalChain.AddMidpoint(new Point(1, 2));

            polygonalChain.Midpoints.Should().HaveCount(1);
            addingMidpointAgain.Should().Throw<ArgumentException>();
        }
    }
}
