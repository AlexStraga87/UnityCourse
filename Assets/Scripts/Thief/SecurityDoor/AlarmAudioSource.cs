using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AlarmDoor))]
public class AlarmAudioSource : MonoBehaviour
{
    [SerializeField] private AlarmDoor _alarmDoor;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        _alarmDoor.OnAlarm += PlayAlarm;
        _alarmDoor.OnStopAlarm += StopAlarm;
    }

    private void OnDisable()
    {
        _alarmDoor.OnAlarm -= PlayAlarm;
        _alarmDoor.OnStopAlarm -= StopAlarm;
    }

    private void PlayAlarm()
    {
        StartCoroutine(PlayAlarmCoroutine());
    }

    private void StopAlarm()
    {
        StartCoroutine(StopAlarmCoroutine());
    }

    private IEnumerator PlayAlarmCoroutine()
    {
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
        _audioSource.Play();

        for (int i = 0; i < 100; i++)
        {
            _audioSource.volume = 0.01f * i;
            yield return waitForFixedUpdate;
        }       
    }

    private IEnumerator StopAlarmCoroutine()
    {
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
        for (int i = 0; i < 100; i++)
        {
            _audioSource.volume = 1 - 0.01f * i;
            yield return waitForFixedUpdate;
        }
        _audioSource.Stop();
    }

}
