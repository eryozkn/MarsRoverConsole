using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MarsRoverConsole
{
    class Program
    {
        public static void Main()
        {
            var inputMaxPoints = Console.ReadLine().Trim().Split(' ');
            var inputInstructions = Console.ReadLine().Trim().Split(' ');
            NavigateRover(inputMaxPoints, inputInstructions);
            Console.ReadLine();
        }

        private static void NavigateRover(string[] inputMaxPoints, string[] inputInstructions)
        {
            var maxPointsOfPlateau = new Coordinate()
            {
                XAxis = Convert.ToInt16(inputMaxPoints.First()),
                YAxis = Convert.ToInt16(inputMaxPoints.Last())
            };

            var rover = new Position()
            {
                XAxis = Convert.ToInt16(inputInstructions[0]),
                YAxis = Convert.ToInt16(inputInstructions[1]),
                FacingDirection = (Direction)Enum.Parse(typeof(Direction), inputInstructions[2])
            };

            var thirdLine = Console.ReadLine().ToUpper();
            var instruction = new Instruction()
            {
                InitialPosition = rover,
                Moves = thirdLine
            };

            try
            {
                ServiceProvider serviceProvider = new ServiceCollection()
                    .AddTransient<INavigator, Navigator>()
                    .BuildServiceProvider();

                var navigator = serviceProvider.GetService<INavigator>();
                var nextPosition = navigator.Move(instruction, maxPointsOfPlateau);
                Console.WriteLine($"{nextPosition.XAxis} {nextPosition.YAxis} {nextPosition.FacingDirection}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
