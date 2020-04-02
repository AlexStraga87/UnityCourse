using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyPatrolMovement))]
public class EnemyAnimate : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private EnemyPatrolMovement _enemyMovement;

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _enemyMovement = GetComponent<EnemyPatrolMovement>();
    }

    private void FixedUpdate()
    {
        if (_enemyMovement.IsWaiting)
        {
            _animator.SetFloat("Speed", 0);
            return;
        }

        _animator.SetFloat("Speed", 1);

        if (_enemyMovement.Direction > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else 
        {
            _spriteRenderer.flipX = true;
        }
    }
}
