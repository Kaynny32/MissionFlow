using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("AnimationPopap")]
    [SerializeField]
    AnimationPopap _poapMission;
    [SerializeField]
    AnimationPopap _popapChainProgress;


    public async void Start()
    {
        await UniTask.Delay(1000);
        _poapMission.AnimationScaleShowAndHidePopap(10f,735,3,1065);
        _popapChainProgress.AnimationScaleShowAndHidePopap(10f, 735, 3, 1065);
    }
}
