using UnityEngine;

namespace Task3_2728
{
    public class DirectionalMover
    {
        private CharacterController _controller;

        private Vector3 _directionToMove;

        private float _movingSpeed;

        public DirectionalMover(CharacterController controller, float movingSpeed)
        {
            _controller = controller;
            _movingSpeed = movingSpeed;
        }

        public void Update()
        {
            _controller.Move(_directionToMove * _movingSpeed * Time.deltaTime);
        }

        public void SetMoveDirection(Vector3 direction) => _directionToMove = direction;
    }
}