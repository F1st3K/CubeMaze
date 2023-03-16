using CubeTools;
using UnityEngine;

namespace CubeMaze.Scripts
{
    public class CubeMazeBuilder : MonoBehaviour
    {
        [SerializeField] private GameObject prefabWall;

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

            for (int n = 0; n < maze.Z; n++)
            {
                for (int i = 0; i < maze.Y; i++)
                {
                    for (int j = 0; j < maze.X; j++)
                    {
                        if (maze[n][i][j].Value.State == MazeElementState.Air)
                            return;
                        var cubePosition = new Vector3(n, i, j);
                        dynamicPosition = transform.position + new Vector3(cubePosition.x * Scale.x,
                            cubePosition.y * Scale.y, cubePosition.z * Scale.z);
                        Instantiate(prefabWall, dynamicPosition, dynamicRotation);
                    }
                }
            }
        }
    }
}