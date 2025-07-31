using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("AnimationPopap")]
    [SerializeField]
    AnimationPopap _poapMission;
    [SerializeField]
    AnimationPopap _popapChainProgress;

    [SerializeField]
    GameObject _prefabUI;
    [SerializeField]
    Transform _missionCon;

    [SerializeField]
    List<MissionConfig> missionConfigs = new List<MissionConfig>();


    public async void Start()
    {
        await UniTask.Delay(1000);
        _poapMission.AnimationScaleShowAndHidePopap(10f, 735, 3, 1065);
        _popapChainProgress.AnimationScaleShowAndHidePopap(10f, 735, 3, 1065);
        SpawnItemUI();
    }

    public void SpawnItemUI()
    {
        foreach (MissionConfig missionConfig in missionConfigs)
        {
            GameObject clone = Instantiate(_prefabUI, _missionCon);
            clone.GetComponent<MissionItemUI>().UpdateUI(missionConfig.Name, missionConfig.Status, missionConfig.Timer);
        }
    }
}
