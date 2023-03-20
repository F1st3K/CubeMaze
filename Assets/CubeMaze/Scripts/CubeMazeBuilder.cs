using CubeTools;
using UnityEngine;

namespace CubeMaze.Scripts
{
    public class CubeMazeBuilder : MonoBehaviour
    {
        [SerializeField] private CubeMesh prefabWall;
        [SerializeField] private CubeMesh prefabFinish;

        private Vector3 Scale => prefabWall.transform.lossyScale;

        private void Start()
        {
            var cube = new Cube<MazeElement>(9, 9, 9);
            cube = CubeMazeGenerator.Generate(cube);
            Build(cube);
        }

        private void Build(Cube<MazeElement> maze)
        {
            var dynamicPosition = transform.position;
            var dynamicRotation = transform.rotation;

            var finishPosition = dynamicPosition;
            MazeElement finish = maze[0][0][0].Value;

            for (int n = 0; n < maze.Z; n++)
            {
                for (int i = 0; i < maze.Y; i++)
                {
                    for (int j = 0; j < maze.X; j++)
                    {
                        var cubePosition = new Vector3(j, i, n);
                        dynamicPosition = transform.position + new Vector3(cubePosition.x * Scale.x,
                            cubePosition.y * Scale.y, cubePosition.z * Scale.z);
                        
                        if (finish.CountSteps < maze[n][i][j].Value.CountSteps)
                        {
                            finish = maze[n][i][j].Value;
                            finishPosition = dynamicPosition;
                        }

                        if (maze[n][i][j].Value.State == MazeElementState.Air)
                            continue;
                        
                        if ((j + 1 < maze.X) &&
                            (maze[n][i][j + 1].Value.State == MazeElementState.Wall))
                            prefabWall.quadX.enabled = false;
                        if ((j - 1 >= 0) &&
                            (maze[n][i][j - 1].Value.State == MazeElementState.Wall))
                            prefabWall.quad_X.enabled = false;
                        if ((i + 1 < maze.Y) &&
                            (maze[n][i + 1][j].Value.State == MazeElementState.Wall))
                            prefabWall.quadY.enabled = false;
                        if ((i - 1 >= 0) &&
                            (maze[n][i - 1][j].Value.State == MazeElementState.Wall))
                            prefabWall.quad_Y.enabled = false;
                        if ((n + 1 < maze.Z) &&
                            (maze[n + 1][i][j].Value.State == MazeElementState.Wall))
                            prefabWall.quadZ.enabled = false;
                        if ((n - 1 >= 0) &&
                            (maze[n - 1][i][j].Value.State == MazeElementState.Wall))
                            prefabWall.quad_Z.enabled = false;
                        
                        Instantiate(prefabWall, dynamicPosition, dynamicRotation);
                        EnableAllQuads();
                    }
                }
            }
            Instantiate(prefabFinish, finishPosition, dynamicRotation);
        }

        private void EnableAllQuads()
        {
            prefabWall.quad_X.enabled = true;
            prefabWall.quad_Y.enabled = true;
            prefabWall.quad_Z.enabled = true;
            prefabWall.quadX.enabled = true;
            prefabWall.quadY.enabled = true;
            prefabWall.quadZ.enabled = true;
        }
    }
}