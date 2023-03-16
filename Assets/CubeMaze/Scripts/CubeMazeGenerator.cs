using CubeTools;


namespace CubeMaze.Scripts
{
    public static class CubeMazeGenerator
    {
        public static Cube<MazeElement> Generate(Cube<MazeElement> maze)
        {
            for (int n = 0; n < maze.Z; n++)
            {
                for (int i = 0; i < maze.Y; i++)
                {
                    for (int j = 0; j < maze.X; j++)
                    {
                        maze[n][i][j].Value = new MazeElement();
                        maze[n][i][j].Value.StateChangeToWall();
                    }
                }
            }

            return maze;
        }
    }
}
