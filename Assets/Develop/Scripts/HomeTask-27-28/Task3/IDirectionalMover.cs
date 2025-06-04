using UnityEngine;

namespace Task3_2728
{
    public interface IDirectionalMover
    {
        Vector3 Position { get; }

        void SetMoveDirection(Vector3 direction);
    }
}
