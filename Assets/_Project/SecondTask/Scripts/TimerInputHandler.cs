using UnityEngine;

public class TimerInputHandler : MonoBehaviour
{
    private Timer _timer;

    public void Initialize(Timer timer) => _timer = timer;

    public void StartTimer() => _timer.Start();

    public void PauseTimer() => _timer.Pause();

    public void ContinueTimer() => _timer.Continue();

    public void ResetTimer() => _timer.Reset();
}
