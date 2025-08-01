using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMission", menuName = "Missions/Mission Config")]
public class MissionConfig : ScriptableObject
{
    [Header("Basic Info")]
    [SerializeField]
    string status;
    [SerializeField]
    string _name;
    [SerializeField]
    float timer;

    [Header("Mission Flow")]
    [SerializeField]
    MissionBehaviour missionBehaviour;
    [SerializeField]
    List<MissionLink> nextMissions = new List<MissionLink>();

    [Header("Timing")]
    [SerializeField]
    float startDelay;


    public string Status => status;
    public string Name => _name;
    public string Timer =>$"{timer}";
    public IMission MissionImplementation => missionBehaviour as IMission;
    public List<MissionLink> NextMissions => nextMissions;
    public float StartDelay => startDelay;

    public MissionBehaviour MissionBehaviour => missionBehaviour;


    public void SetMissionBehaviour(MissionBehaviour behaviour)
    {
        if (behaviour != null && behaviour is IMission)
        {
            missionBehaviour = behaviour;
        }
        else
        {
            
        }
    }
    public void StartMissionSequence()
    {
        if (MissionSequenceManager.Instance != null)
        {
            MissionSequenceManager.Instance.StartMissionSequence(this);
        }
        else
        {
            
        }
    }
}

public abstract class MissionBehaviour : MonoBehaviour, IMission
{
    public abstract event Action OnStarted;
    public abstract event Action OnMissionPointReached;
    public abstract event Action OnFinished;
    public abstract void Start();
}

[Serializable]
public struct MissionLink
{
    public MissionConfig nextMission;
    public float delayBeforeStart;
}
public interface IMission
{
    event Action OnStarted;
    event Action OnMissionPointReached;
    event Action OnFinished;
    void Start();
}