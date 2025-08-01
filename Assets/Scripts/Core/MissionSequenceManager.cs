using System;
using System.Collections;
using UnityEngine;

public class MissionSequenceManager : MonoBehaviour
{
    public static MissionSequenceManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartMissionSequence(MissionConfig startMission)
    {
        StartCoroutine(ExecuteMissionSequence(startMission));
    }

    private IEnumerator ExecuteMissionSequence(MissionConfig mission)
    {
        while (mission != null)
        {
            mission.MissionImplementation.Start();

            yield return WaitForMissionCompletion(mission.MissionImplementation);

            MissionConfig nextMission = null;
            float delay = 0f;

            if (mission.NextMissions.Count > 0)
            {
                nextMission = mission.NextMissions[0].nextMission;
                delay = mission.NextMissions[0].delayBeforeStart;
            }

            if (delay > 0)
            {
                yield return new WaitForSeconds(delay);
            }

            mission = nextMission;
        }
    }

    private IEnumerator WaitForMissionCompletion(IMission mission)
    {
        bool isCompleted = false;
        Action onCompleted = () => isCompleted = true;

        mission.OnFinished += onCompleted;
        yield return new WaitWhile(() => !isCompleted);
        mission.OnFinished -= onCompleted;
    }
}