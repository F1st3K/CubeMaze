using CubeTools;
using UnityEngine;


namespace CubeMaze.Scripts
{
    public class CubeMazeGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject prefabWall;
        
        private void Start()
        {
            var cube = new CubeSurface<GameObject>(9, 9, 9);
            for (int n = 0; n < cube.CountSurfaces; n++)
            {
                for (int i = 0; i < cube[n].X; i++)
                {
                    for (int j = 0; j < cube[n].Y; j++)
                    {
                        if (cube[n][i, j] == null)
                            cube[n][i, j] = prefabWall;
                    }
                }
            }
            foreach (Surface<GameObject> elements in cube)
            {
                foreach (GameObject element in elements)
                {
                    if (element == null)
                    {
                        
                    }
                }
            }
        }
    }
}
