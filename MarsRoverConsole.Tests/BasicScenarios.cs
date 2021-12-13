using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MarsRoverConsole.Tests
{
    public class BasicScenarios
    {
        [Fact]
        public void ShouldReturnExpectedOutput()
        {
            var maxPoints = new Coordinate() { XAxis = 5, YAxis = 5 };
            var startPosition = new Position { XAxis = 1, YAxis = 2, FacingDirection = Direction.N };
            var moves = "LMLMLMLMM";
            var instruction = new Instruction { InitialPosition = startPosition, Moves = moves };

            ServiceProvider serviceProvider = new ServiceCollection()
                                           .AddTransient<INavigator, Navigator>()
                                           .BuildServiceProvider();

            var navigator = serviceProvider.GetService<INavigator>();
            var nextPosition = navigator.Move(instruction, maxPoints);
            var actualOutput = $"{nextPosition.XAxis} {nextPosition.YAxis} {nextPosition.FacingDirection}";
            var expectedOutput = "1 3 N";
            Assert.Equal(expectedOutput, actualOutput);

            moves = "MRRMMRMRRM";
            instruction.Moves = moves;
            nextPosition = navigator.Move(instruction, maxPoints);
            actualOutput = $"{nextPosition.XAxis} {nextPosition.YAxis} {nextPosition.FacingDirection}";
            expectedOutput = "1 2 E";
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
