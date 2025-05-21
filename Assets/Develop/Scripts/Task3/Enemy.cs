using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float MinDistanceToTarget = 0.05f;

    private CharacterController _character;

    private Vector3 _targetPoint;

    private Vector3 _directionToMove;

    private float _currentSpeed = 1;

    public Func<Enemy, bool> DestroyCondition;

    private bool _isDead;

    private float _lifeTime;

    private bool _isRandomPointSet;

    public bool IsDead => _isDead;

    public float LifeTime => _lifeTime;

    private void Awake()
    {
        _character = GetComponent<CharacterController>();

        GetDirectionToMove();
    }

    private void Update()
    {
        _lifeTime += Time.deltaTime;

        _character.Move(_directionToMove.normalized * _currentSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _targetPoint) <= MinDistanceToTarget)
            GetDirectionToMove();

        Debug.Log(Vector3.Distance(transform.position, _targetPoint) <= MinDistanceToTarget);
    }

    public void SetDeathMark() => _isDead = true;

    public void Suicide()
    {
        Destroy(gameObject);
    }

    private void GetDirectionToMove()
    {
        Vector3 randomDirection = new Vector3(UnityEngine.Random.Range(-1, 2), 0, UnityEngine.Random.Range(-1, 2));
        _targetPoint = _character.transform.position + randomDirection.normalized * UnityEngine.Random.Range(1, 4);

        _directionToMove = _targetPoint - transform.position;
    }
}
