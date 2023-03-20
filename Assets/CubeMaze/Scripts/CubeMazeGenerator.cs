using System;
using CubeTools;
using Random = UnityEngine.Random;

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

            int x = maze.X / 2;
            int y = maze.Y - 1;
            int z = maze.Z / 2;
            maze[z][y][x].Value.StateChangeToAir();
            var counterPassDirection = 0;
            var maxCountPassDirection = 6;
            var counterRundomJumps = 0;
            var maxCountRundomJumps = 6;
            while (true)
            {
                if (counterRundomJumps >= maxCountRundomJumps)
                    break;
                
                if (counterPassDirection >= maxCountPassDirection)
                {
                    x = Random.Range(0, maze.X - 1);
                    y = Random.Range(0, maze.Y - 1);
                    z = Random.Range(0, maze.Z - 1);
                    counterRundomJumps++;
                }

                var direction = (Direction3D) Random.Range(0, Enum.GetNames(typeof(Direction3D)).Length);
                var nextY = new int[] {y, y};
                var nextX = new int[] {x, x};
                var nextZ = new int[] {z, z};

                switch (direction)
                {
                    case Direction3D.Up:
                        nextY[0]++;
                        nextY[1] += 2;
                        break;
                    case Direction3D.Down:
                        nextY[0]--;
                        nextY[1] -= 2;
                        break;
                    case Direction3D.Right:
                        nextX[0]++;
                        nextX[1] += 2;
                        break;
                    case Direction3D.Left:
                        nextX[0]--;
                        nextX[1] -= 2;
                        break;
                    case Direction3D.Forward:
                        nextZ[0]++;
                        nextZ[1] += 2;
                        break;
                    case Direction3D.Back:
                        nextZ[0]--;
                        nextZ[1] -= 2;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                if (nextX[0] >= maze.X || nextX[0] < 0 ||
                    nextY[0] >= maze.Y || nextY[0] < 0 ||
                    nextZ[0] >= maze.Z || nextZ[0] < 0 ||
                    maze[nextZ[0]][nextY[0]][nextX[0]].Value.State == MazeElementState.Air)
                {
                    counterPassDirection++;
                    continue;
                }
                maze[nextZ[0]][nextY[0]][nextX[0]].Value.StateChangeToAir();
                x = nextX[0];
                y = nextY[0];
                z = nextZ[0];

                if (nextX[1] >= maze.X || nextX[1] < 0 ||
                    nextY[1] >= maze.Y || nextY[1] < 0 ||
                    nextZ[1] >= maze.Z || nextZ[1] < 0 ||
                    maze[nextZ[1]][nextY[1]][nextX[1]].Value.State == MazeElementState.Air)
                {
                    counterPassDirection++;
                    continue;
                }
                maze[nextZ[1]][nextY[1]][nextX[1]].Value.StateChangeToAir();
                x = nextX[1];
                y = nextY[1];
                z = nextZ[1];
                
                counterPassDirection = 0;
            }

            return maze;
        }
    }
}
