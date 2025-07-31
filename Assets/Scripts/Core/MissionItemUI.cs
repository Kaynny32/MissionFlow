using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionItemUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _missionNameText;
    [SerializeField]
    TextMeshProUGUI _statusText;
    [SerializeField]
    TextMeshProUGUI _timerText;
    [SerializeField]
    Slider _progressBar;
    [SerializeField]
    Image _icon;


    private void Start()
    {
        ShowCompletedEffect("Notstarted");
    }

    public void UpdateUI(string name, string status, string timer ,float progress = 0)
    {
        _missionNameText.text = $"Mission name: {name}";
        _statusText.text = $"Status: {status}";
        _progressBar.value = progress;
        if (timer == "0")
            _timerText.text = "Timer: null";
        else
            _timerText.text =$"Timer: {timer}";
    }

    public void ShowCompletedEffect(string status)
    {
        _icon.DOKill();
        switch (status)
        {
            case "Notstarted":
                _icon.DOFade(0.5f, 1f);
                _icon.DOColor(Color.red, 0.5f);
                break;
            case "InProgress":
                _icon.DOFade(0.5f, 1f);
                _icon.DOColor(Color.yellow, 0.5f);
                break;
            case "Completed":
                _icon.DOFade(0.5f, 1f);
                _icon.DOColor(Color.green, 0.5f);
                break;
        }
    }
}
