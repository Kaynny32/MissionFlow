using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemsMission : MissionBehaviour
{
    public override event Action OnStarted;
    public override event Action OnMissionPointReached;
    public override event Action OnFinished;

    [SerializeField] private float _duration = 3f;

    public override void Start()
    {
       

    }

    public void StartMission()
    {
        OnStarted?.Invoke();
        StartCoroutine(MissionRoutine());
    }
    private IEnumerator MissionRoutine()
    {
        Debug.Log("OnStarted");
        float elapsed = 0f;

        while (elapsed < _duration)
        {
            elapsed += Time.deltaTime;

            if (elapsed >= _duration / 2f)
            {
                OnMissionPointReached?.Invoke();
                Debug.Log("OnMissionPointReached");
            }

            yield return null;
        }

        OnFinished?.Invoke();
        Debug.Log("OnFinished");
    }
}
