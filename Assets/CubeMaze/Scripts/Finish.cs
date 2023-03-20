using UnityEngine;

namespace CubeMaze.Scripts
{
    public class Finish : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            new Navigation().Reload();
        }
    }
}