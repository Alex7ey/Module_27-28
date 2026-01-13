using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public event Action<float> ChangedTime;

    private bool _isPaused;
    private float _totalDuration;
    private float _currentTimerValue;

    private Coroutine _coroutine;
    private MonoBehaviour _coroutineRunner;

    public Timer(MonoBehaviour coroutineRunner, int time)
    {
        _totalDuration = Math.Abs(time);
        _currentTimerValue = Math.Abs(time);
        _coroutineRunner = coroutineRunner;
    }

    public float CurrentTimerValue => _currentTimerValue;
    public float TotalDuration => _totalDuration;

    public IEnumerator Process()
    {
        while (_currentTimerValue > 0)
        {
            while (_isPaused)
            {
                yield return null;
            }

            _currentTimerValue -= Time.deltaTime;
            ChangedTime?.Invoke(_currentTimerValue);
            yield return null;
        }

        Reset();
    }

    public void Start()
    {
        Reset();
        _coroutine = _coroutineRunner.StartCoroutine(Process());
    }

    public void Pause() => _isPaused = true;

    public void Continue() => _isPaused = false;

    public void Reset()
    {
        if (_coroutine != null)
        {
            _coroutineRunner.StopCoroutine(_coroutine);
        }

        _isPaused = false;
        _coroutine = null;

        _currentTimerValue = _totalDuration;
        ChangedTime?.Invoke(_currentTimerValue);
    }
}
