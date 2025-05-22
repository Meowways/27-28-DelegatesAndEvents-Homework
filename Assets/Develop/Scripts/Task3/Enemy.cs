using UnityEngine;

public class Enemy : MonoBehaviour, IDirectionalMover
{
    private DirectionalMover _directionalMover;

    private Controller _controller;

    private float _movingSpeed;

    private bool _isDead;

    private float _lifeTime;

    public bool IsDead => _isDead;

    public float LifeTime => _lifeTime;

    public Vector3 Position => transform.position;

    public void Initialize(Controller controller, float movingSpeed)
    {
        _controller = controller;
        _movingSpeed = movingSpeed;

        _directionalMover = new DirectionalMover(GetComponent<CharacterController>(), _movingSpeed);
    }

    private void Update()
    {
        _lifeTime += Time.deltaTime;

        _controller.Update(Time.deltaTime);
        _directionalMover.Update();
    }
    public void SetMoveDirection(Vector3 direction) => _directionalMover.SetMoveDirection(direction);

    public void SetDeathMark() => _isDead = true;

    public void Suicide() => Destroy(gameObject);
}
