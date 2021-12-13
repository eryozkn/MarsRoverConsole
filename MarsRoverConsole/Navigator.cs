using System;

namespace MarsRoverConsole
{
    public class Navigator : INavigator
    {
        private Position MoveForward(Position position)
        {
            switch (position.FacingDirection)
            {
                case Direction.N:
                    position.YAxis += 1;
                    break;
                case Direction.S:
                    position.YAxis -= 1;
                    break;
                case Direction.E:
                    position.XAxis += 1;
                    break;
                case Direction.W:
                    position.XAxis -= 1;
                    break;
                default:
                    break;
            }
            return position;
        }

        private Position SpinLeft(Position position)
        {
            switch (position.FacingDirection)
            {
                case Direction.N:
                    position.FacingDirection = Direction.W;
                    break;
                case Direction.S:
                    position.FacingDirection = Direction.E;
                    break;
                case Direction.E:
                    position.FacingDirection = Direction.N;
                    break;
                case Direction.W:
                    position.FacingDirection = Direction.S;
                    break;
                default:
                    break;
            }
            return position;
        }

        private Position SpinRight(Position position)
        {
            switch (position.FacingDirection)
            {
                case Direction.N:
                    position.FacingDirection = Direction.E;
                    break;
                case Direction.S:
                    position.FacingDirection = Direction.W;
                    break;
                case Direction.E:
                    position.FacingDirection = Direction.S;
                    break;
                case Direction.W:
                    position.FacingDirection = Direction.N;
                    break;
                default:
                    break;
            }
            return position;
        }

        public Position Move(Instruction instruction, Coordinate upperRight)
        {
            ValidateInstruction(instruction, upperRight);
            var nextPosition = instruction.InitialPosition;

            foreach(var move in instruction.Moves.ToCharArray())
            {
                nextPosition = move switch
                {
                    'M' => MoveForward(nextPosition),
                    'L' => SpinLeft(nextPosition),
                    'R' => SpinRight(nextPosition),
                    _ => throw new Exception($"Oops, error! Instruction set contains invalid character")
                };
            }
            return nextPosition;
        }

        private void ValidateInstruction(Instruction instruction, Coordinate upperRight)
        {
            if (instruction == null)
            {
                throw new Exception($"Oops, error! Instruction cannot be null");
            }

            if (instruction.InitialPosition.XAxis < 0 ||
                instruction.InitialPosition.XAxis > upperRight.XAxis ||
                instruction.InitialPosition.YAxis < 0 ||
                instruction.InitialPosition.YAxis > upperRight.YAxis)
            {
                throw new Exception($"Oops, error! Initial position of the rover must be within the boundaries");
            }
            if (instruction.Moves.Length <= 0)
            {
                throw new Exception($"Oops, error! There is no input to move");
            }
        }
    }
}
