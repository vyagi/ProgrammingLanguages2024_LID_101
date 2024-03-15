using FluentAssertions;

namespace Geometry.Tests
{
    public class PointTests
    {
        [Fact]
        public void Default_constructor_creates_point_0_0()
        {
            var point = new Point();

            point.X.Should().Be(0);
            point.Y.Should().Be(0);
        }

        [Fact]
        public void One_parameter_constructor_creates_valid_point()
        {
            var point = new Point(5.5);

            point.X.Should().Be(5.5);
            point.Y.Should().Be(5.5);
        }

        [Fact]
        public void Two_parameter_constructor_creates_valid_point()
        {
            var point = new Point(5.5, -3.5);

            point.X.Should().Be(5.5);
            point.Y.Should().Be(-3.5);
        }

        [Fact]
        public void Move_shits_point_by_provided_coordinates()
        {
            //ARANGE
            var point = new Point(-1, 4);

            //ACT
            point.Move(3, -5);

            //ASSERT
            point.X.Should().Be(2);
            point.Y.Should().Be(-1);
        }

        [Fact]
        public void Distance_returns_proper_distance_from_origin()
        {
            var point = new Point(-3, -4);

            var distance = point.Distance();

            distance.Should().Be(5);
        }

        [Fact]
        public void ToString_returns_proper_point_representation()
        {
            var point = new Point(-3, -4);

            var representation = point.ToString();

            representation.Should().Be("(-3,-4)");
        }
    }
}