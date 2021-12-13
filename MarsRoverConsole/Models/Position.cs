using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverConsole
{
    public class Position: Coordinate
    {
        public Direction FacingDirection {get;set; }

        public Position() 
        {
            XAxis = 0; 
            YAxis = 0;
            FacingDirection = Direction.N;
        }
    }
    public enum Direction
    {
        N, //North
        S, //South
        E, //East
        W //West
    }
}
