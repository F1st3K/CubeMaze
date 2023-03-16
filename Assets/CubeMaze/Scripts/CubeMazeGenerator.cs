using CubeTools;
using UnityEngine;


namespace CubeMaze.Scripts
{
    public class CubeMazeGenerator : MonoBehaviour
    {
        private void Start()
        {
            var cube = new CubeSurface<int>(9, 9, 9);
            cube[0][0, 0] = 1;
            string str = "";
            foreach (Surface<int> elements in cube)
            {
                foreach (int element in elements)
                {
                    str += element;
                }
                str += "\n";
            }
            Debug.Log(str);
        }
    }
}
