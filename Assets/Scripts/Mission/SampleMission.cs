using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class SampleMission : MonoBehaviour, IMission
{
    public event Action OnStarted;
    public event Action OnMissionPointReached;
    public event Action OnFinished;

    [SerializeField] private float duration = 5f;

    public void Start()
    {
        OnStarted?.Invoke();
        StartMission().Forget();
    }

    private async UniTaskVoid StartMission()
    {
        await UniTask.Delay((int)(duration * 1000 * 0.5f));
        OnMissionPointReached?.Invoke();

        await UniTask.Delay((int)(duration * 1000 * 0.5f));
        OnFinished?.Invoke();
    }

    public void Reset()
    {
        // —брос состо€ни€ миссии
    }
}