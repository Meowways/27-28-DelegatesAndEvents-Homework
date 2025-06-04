using UnityEngine;

namespace Task3_2728
{
    public class RandomMovementController : Controller
    {
        private IDirectionalMover _character;

        private Vector3 _currentDirection;

        private float _time;
        private float _timeToChangeDirection;

        public RandomMovementController(IDirectionalMover character, float timeToChangeDirection)
        {
            _character = character;

            _timeToChangeDirection = _time = timeToChangeDirection;
        }

        protected override void UpgradeLogic(float deltaTime)
        {
            _time += deltaTime;

            if (_time > _timeToChangeDirection)
            {
                _currentDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
                _time = 0;
            }

            _character.SetMoveDirection(_currentDirection);
        }
    }
}