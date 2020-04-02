using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 6;
    private Transform _target;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        MoveToTarget();
        if (CheckDestinationTarget())
        {
            Destroy(gameObject);
        }
    }

    private void MoveToTarget()
    {
        if (_target)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
    }

    private bool CheckDestinationTarget()
    {
        return Vector2.Distance(transform.position, _target.position) < 0.1f;      
    }

}
