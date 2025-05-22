using UnityEngine;

public interface IDirectionalMover 
{
    Vector3 Position { get; }

    void SetMoveDirection(Vector3 direction);
}
