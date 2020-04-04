using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyPatrolMovement : MonoBehaviour
{
    [SerializeField] private float _patrolDistance = 1;
    [SerializeField] private float _speed = 2;

    public bool IsWaiting => _isWaiting;
    public int Direction => _direction;

    private int _direction = 1;
    private bool _isWaiting;
    private Rigidbody2D _rigidBody2d;
    private float _xMinPatrol;
    private float _xMaxPatrol;

    private void Start()
    {
        _rigidBody2d = GetComponent<Rigidbody2D>();
        _xMinPatrol = transform.position.x - _patrolDistance;
        _xMaxPatrol = transform.position.x + _patrolDistance;
    }

    private void FixedUpdate()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (_isWaiting) return;

        if (_direction > 0)
        {
            MoveToEdge(transform.position.x < _xMaxPatrol);
        }
        else
        {
            MoveToEdge(transform.position.x > _xMinPatrol);
        }
    }

    private void MoveToEdge(bool condition)
    {
        if (condition)
        { 
           _rigidBody2d.position = _rigidBody2d.position + Vector2.right * _direction * _speed * Time.fixedDeltaTime;
        }
        else
        {
            Waiting();
            _direction *= -1;
        }
    }

    private void Waiting()
    {
        _isWaiting = true;
        StartCoroutine(WaitOnEdge());
    }

    private IEnumerator WaitOnEdge()
    {
        yield return new WaitForSeconds(1.5f);
        _isWaiting = false;
    }

}