using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AlarmDoor))]
public class AlarmAudioSource : MonoBehaviour
{
    [SerializeField] private AlarmDoor _alarmDoor;
    [SerializeField] private AudioSource _audioSource;
    private Coroutine _activeCoroutine;

    private void OnEnable()
    {
        _alarmDoor.Alarm += PlayAlarm;
        _alarmDoor.StopAlarm += StopAlarm;
    }

    private void OnDisable()
    {
        _alarmDoor.Alarm -= PlayAlarm;
        _alarmDoor.StopAlarm -= StopAlarm;
    }

    private void PlayAlarm()
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }
        _activeCoroutine = StartCoroutine(PlayAlarmCoroutine());
    }

    private void StopAlarm()
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }
        _activeCoroutine = StartCoroutine(StopAlarmCoroutine());
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

        int _currentVolume =  100 - (int)(_audioSource.volume * 100);
        for (int i = _currentVolume; i < 100; i++)
        {
            _audioSource.volume = 1 - 0.01f * i;
            yield return waitForFixedUpdate;
        }
        _audioSource.Stop();
    }

}
