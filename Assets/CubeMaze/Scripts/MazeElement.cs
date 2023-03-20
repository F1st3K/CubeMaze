using System;

namespace CubeMaze.Scripts
{
    public class MazeElement
    {
        private int _countSteps;
        
        public MazeElement()
        {
            State = MazeElementState.Wall;
        }
        
        public MazeElementState State { get; private set; }

        public int CountSteps
        {
            get => _countSteps;
            set
            {
                if (value < 0)
                    throw new ArgumentException("count steps is not low null");
                _countSteps = value;
            }
        }

        public void StateChangeToAir()
        {
            State = MazeElementState.Air;
        }
        
        public void StateChangeToWall()
        {
            State = MazeElementState.Wall;
        }
    }
}