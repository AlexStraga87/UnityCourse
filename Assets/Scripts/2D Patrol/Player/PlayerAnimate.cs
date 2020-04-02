using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsMovement))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimate : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private PhysicsMovement _physicsMovement;

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _physicsMovement = GetComponent<PhysicsMovement>();
    }

    private void FixedUpdate()
    {
        Animate(_physicsMovement.XDirection);
    }

    private void Animate(float XDirection)
    {
        float xAxis = _physicsMovement.XDirection;

        _animator.SetFloat("Speed", Mathf.Abs(XDirection));

        if (XDirection > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (XDirection < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

}
