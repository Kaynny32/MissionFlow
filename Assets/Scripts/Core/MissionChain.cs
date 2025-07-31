using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class MissionChain : MonoBehaviour
{
    [SerializeField] private List<MissionData> startingMissions = new List<MissionData>();
    private List<Timer> activeTimers = new List<Timer>();

    private void Start()
    {
        StartMissionChains();
    }

    public void StartMissionChains()
    {
        foreach (var missionData in startingMissions)
        {
            StartMissionChain(missionData).Forget();
        }
    }

    private async UniTaskVoid StartMissionChain(MissionData missionData)
    {
        if (missionData == null) return;

        var timer = new Timer();
        activeTimers.Add(timer);

        await timer.StartAsync((int)(missionData.startDelay * 1000));
        StartMission(missionData);
    }

    private void StartMission(MissionData missionData)
    {
        if (missionData.missionImplementation == null)
        {
            Debug.LogError($"Mission implementation is null for {missionData.missionName}");
            return;
        }

        missionData.missionImplementation.OnStarted += () =>
        {
            Debug.Log($"Mission started: {missionData.missionName}");
        };

        missionData.missionImplementation.OnFinished += () =>
        {
            Debug.Log($"Mission finished: {missionData.missionName}");
            foreach (var nextMission in missionData.nextMissions)
            {
                StartMissionChain(nextMission).Forget();
            }
        };

        missionData.missionImplementation.Start();
    }

    private void OnDestroy()
    {
        foreach (var timer in activeTimers)
        {
            timer.Cancel();
        }
        activeTimers.Clear();
    }
}