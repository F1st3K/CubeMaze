namespace CubeMaze.Scripts
{
    public class MazeElement
    {
        public MazeElement()
        {
            State = MazeElementState.Wall;
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