using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class SecurityZone : MonoBehaviour
{
    public UnityAction OnThiefEnter;
    public UnityAction OnThiefExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnThiefEnter?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnThiefExit?.Invoke();
    }

}
