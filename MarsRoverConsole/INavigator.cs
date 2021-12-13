namespace MarsRoverConsole
{
    public interface INavigator
    {
        Position Move(Instruction instruction, Coordinate upperRight);
    }
}