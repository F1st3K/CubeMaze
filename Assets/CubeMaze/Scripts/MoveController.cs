using UnityEngine;

namespace CubeMaze.Scripts
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private Hero hero;

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
                hero.Move(Vector3.forward, 1);
            if (Input.GetKey(KeyCode.A))
                hero.Move(Vector3.left, 1);
            if (Input.GetKey(KeyCode.S))
                hero.Move(Vector3.back, 1);
            if (Input.GetKey(KeyCode.D))
                hero.Move(Vector3.right, 1);
            if (Input.GetKey(KeyCode.Space))
                hero.Move(Vector3.up, 1);
            if (Input.GetKey(KeyCode.LeftShift))
                hero.Move(Vector3.down, 1);
        }
    }
}