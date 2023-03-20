using System;
using UnityEngine;

namespace CubeMaze.Scripts
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float speed;
        
        public void Move(Vector3 direction, float mullSpeed)
        {
            if (mullSpeed < 0)
                throw new Exception("mullSpeed should be greater than zero");
            float currentSpeed = speed * mullSpeed;
            Vector3 position = transform.position;
            position = Vector3.MoveTowards(position,
                position+direction,
                currentSpeed*Time.deltaTime);
            transform.position = position;
        }
    }
}