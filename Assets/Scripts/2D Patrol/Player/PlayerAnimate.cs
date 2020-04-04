using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimate : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private PlayerMover _playerMover;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void FixedUpdate()
    {
        Animate(_playerMover.DirectionX);
    }

    private void Animate(float XDirection)
    {
        float xAxis = _playerMover.DirectionX;

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
