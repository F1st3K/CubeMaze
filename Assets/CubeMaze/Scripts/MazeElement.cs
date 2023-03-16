namespace CubeMaze.Scripts
{
    public class MazeElement
    {
        public MazeElement(MazeElementState state)
        {
            State = state;
        }
        
        public MazeElementState State { get; private set; }

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