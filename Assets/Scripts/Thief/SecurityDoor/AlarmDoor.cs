using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class AlarmDoor : MonoBehaviour
{
    [SerializeField] private SecurityZone _securityZone;
    [SerializeField] private Sprite _openedDoorSprite;
    [SerializeField] private Sprite _closedDoorSprite;
    private SpriteRenderer _spriteRenderer;
    public UnityAction OnAlarm;
    public UnityAction OnStopAlarm;

    private bool _isAlarm;
    private bool _isThiefInZone;

    private void OnEnable()
    {
        _securityZone.OnThiefEnter += OnThiefEnter;
        _securityZone.OnThiefExit += OnThiefExit;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDisable()
    {
        _securityZone.OnThiefEnter -= OnThiefEnter;
        _securityZone.OnThiefExit -= OnThiefExit;
    }

    private void OnThiefEnter()
    {
        _isThiefInZone = true;
    }

    private void OnThiefExit()
    {
        _isThiefInZone = false;
        if (_isAlarm)
        {
            OnStopAlarm?.Invoke();
        }
        _isAlarm = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        _spriteRenderer.sprite = _openedDoorSprite;
        if (_isAlarm == false)
        {
            OnAlarm?.Invoke();
            _isAlarm = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _spriteRenderer.sprite = _closedDoorSprite;
    }
}
