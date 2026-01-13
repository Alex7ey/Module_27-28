using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHearthView : MonoBehaviour
{
    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private HorizontalLayoutGroup _horizontalLayoutGroup;

    private Timer _timer;
    private List<GameObject> _hearts = new();

    public void Initialize(Timer timer)
    {
        _timer = timer;
        _timer.ChangedTime += UpdateHeartsNumber;

        CreateHeartsView((int)_timer.TotalDuration);
    }

    private void CreateHeartsView(int time)
    {
        for (int i = 0; i < time; i++)
            _hearts.Add(Instantiate(_heartPrefab, _horizontalLayoutGroup.transform));
    }

    private void UpdateHeartsNumber(float value)
    {
        value = Mathf.CeilToInt(value);

        for (int i = 0; i < _hearts.Count; i++)
            _hearts[i].gameObject.SetActive(i < value);
    }

    private void OnDestroy()
    {
        _timer.ChangedTime -= UpdateHeartsNumber;
    }
}
