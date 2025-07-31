using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MissionData
{
    public string missionName;
    public float startDelay;
    public IMission missionImplementation;
    public List<MissionData> nextMissions = new List<MissionData>();
}