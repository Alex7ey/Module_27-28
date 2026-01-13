using UnityEngine;
using UnityEngine.UI;

public class TimerSliderView : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Timer _timer;

    public void Initialize(Timer timer)
    {
        _timer = timer;

        _timer.ChangedTime += UpdateSliderDisplay;
        UpdateSliderDisplay(_timer.CurrentTimerValue);
    }

    private void UpdateSliderDisplay(float currentValue) => _slider.value = Mathf.InverseLerp(0, _timer.TotalDuration, currentValue);

    private void OnDestroy() => _timer.ChangedTime -= UpdateSliderDisplay;
}
