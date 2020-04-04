using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int _speed = 6;
    private Vector2 _direction;
    private Rigidbody2D _rigidbody2D;
    

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        Move();
    }

    private void Move()
    {
        _rigidbody2D.position = _rigidbody2D.position + _direction * _speed * Time.deltaTime;
    }

}
