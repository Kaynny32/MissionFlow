using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    [Header("UI Elements")]
    [SerializeField] AnimationPopap _missionPopap;
    [SerializeField] AnimationPopap _progressPopap;
    [SerializeField] GameObject _missionPrefab;

    [Header("Containers")]
    [SerializeField] Transform _missionsContainer;
    [SerializeField] Transform _progressContainer;

    [Header("Mission Configs")]
    [SerializeField] List<MissionConfig> _missionConfigs;

    private Dictionary<MissionConfig, MissionItemUI> _missionUIs = new();

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private async void Start()
    {
        await UniTask.Delay(1000);
        _missionPopap.AnimationScaleShowAndHidePopap(10f, 735, 3, 1065);
        _progressPopap.AnimationScaleShowAndHidePopap(10f, 735, 3, 1065);
        InitializeMissions();
    }

    private void InitializeMissions()
    {
        foreach (var config in _missionConfigs)
        {
            var missionUI = Instantiate(_missionPrefab, _missionsContainer)
                .GetComponent<MissionItemUI>();

            missionUI.Initialize(config);
            _missionUIs[config] = missionUI;
        }
    }

    public void MoveToActive(MissionConfig config)
    {
        if (_missionUIs.TryGetValue(config, out var missionUI))
        {
            missionUI.transform.SetParent(_progressContainer);
            missionUI.SetAsActive();
        }
    }
}