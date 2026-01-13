using UnityEngine;

namespace SecondTask
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private int _totalDuration;

        [SerializeField] private TimerHearthView _timerHearth;
        [SerializeField] private TimerSliderView _timerView;
        [SerializeField] private TimerInputHandler _timerInputHandler;

        private void Awake()
        {
            Timer timer = new(this, _totalDuration);

            _timerInputHandler.Initialize(timer);
            _timerHearth.Initialize(timer);
            _timerView.Initialize(timer);
        }
    }
}
