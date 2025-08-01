using TMPro;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionItemUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] 
    TextMeshProUGUI _nameText;
    [SerializeField] 
    TextMeshProUGUI _statusText;
    [SerializeField]  
    TextMeshProUGUI _timerText;
    [SerializeField]  
    Slider _progressBar;
    [SerializeField] 
    Image _icon;

    private MissionConfig _config;
    private Coroutine _progressRoutine;

    public void Initialize(MissionConfig config)
    {
        _config = config;
        UpdateUI();
        SetStatus("Notstarted");
    }

    public void SetAsActive()
    {
        SetStatus("InProgress");
        StartProgress();
    }

    private void UpdateUI()
    {
        _nameText.text = $"Mission: {_config.Name}";
        _timerText.text = _config.Timer == "0" ? "Timer: null" : $"Timer: {_config.Timer}";
    }

    private void SetStatus(string status)
    {
        _statusText.text = $"Status: {status}";

        _icon.DOKill();
        var color = status switch
        {
            "Notstarted" => Color.red,
            "InProgress" => Color.yellow,
            "Completed" => Color.green,
            _ => Color.white
        };

        _icon.DOColor(color, 0.5f);
        _icon.DOFade(0.5f, 0.5f);
    }

    private void StartProgress()
    {
        if (_progressRoutine != null)
            StopCoroutine(_progressRoutine);

        _progressRoutine = StartCoroutine(ProgressRoutine());
    }

    private IEnumerator ProgressRoutine()
    {
        if (!float.TryParse(_config.Timer, out var duration))
        {
            Debug.LogError("Invalid timer format");
            yield break;
        }

        float elapsed = 0;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            _progressBar.value = Mathf.Lerp(0, 1, elapsed / duration);
            yield return null;
        }

        _progressBar.value = 1;
        SetStatus("Completed");
    }

    public void OnClick() => UIManager.instance.MoveToActive(_config);
}